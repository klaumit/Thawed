using System.Collections.Generic;
using System.Linq;
using Extracting.API;
using Extracting.Tools;
using System;
using System.IO;
using CliWrap;
using CliWrap.Buffered;
using Unasmsys;

namespace Extracting.Extractors
{
    public sealed class WinExtractor : IExtractor
    {
        private readonly string _tmpDir = FileTool.CreateOrGetDir("tmp_win");
        private readonly string _exePath = FindExe();

        public async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Wrap(_tmpDir).Chunk(100))
            {
                List<string> dArgs = [_exePath];
                Array.ForEach(batch, b => dArgs.Add(b.File));

                const string cmd = "wine";
                var dumpCmd = await Cli.Wrap(cmd)
                    .WithArguments(dArgs)
                    .WithWorkingDirectory(_tmpDir)
                    .WithValidation(CommandResultValidation.None)
                    .ExecuteBufferedAsync();

                Array.ForEach(batch, b => b.Dispose());

                var error = dumpCmd.StandardError;
                if (!string.IsNullOrWhiteSpace(error) || dumpCmd.ExitCode != 0)
                    throw new InvalidOperationException($"[{dumpCmd.ExitCode}] {error}");

                var stdOut = dumpCmd.StandardOutput;
                foreach (var step in ParseWinOutput(stdOut))
                    yield return step;
            }
        }

        private static IEnumerable<Decoded[]> ParseWinOutput(string stdOut)
        {
            var lines = TextTool.ToLines(stdOut);
            const string sep = "[ ";
            List<Decoded>? list = null;
            foreach (var line in lines)
            {
                if (line.StartsWith(sep) && line.Split(sep, 2) is { Length: 2 } pt)
                {
                    if (list != null)
                        yield return list.ToArray();
                    list = new List<Decoded>();
                    continue;
                }
                if (ParseLine(line) is not { } res)
                    continue;
                list!.Add(res);
            }
            if (list is { Count: >= 1 })
                yield return list.ToArray();
        }

        private static Decoded? ParseLine(string one)
        {
            var parts = TextTool.ToCol(one);
            if (parts.Length != 5)
                return null;
            var offset = short.Parse(parts[0]);
            var count = int.Parse(parts[1]);
            var hex = parts[2];
            var dis = parts[3];
            var left = int.Parse(parts[4]);
            return new Decoded(offset, count, hex, dis, left);
        }

        private static string FindExe()
        {
            var exeDir = FileTool.GetPath<WinExtractor>();
            var srcDir = Path.Combine(exeDir, "..", "..", "..", "..");
            return Path.GetFullPath(Path.Combine(srcDir, "prepared", "Unasmsys.exe"));
        }
    }
}