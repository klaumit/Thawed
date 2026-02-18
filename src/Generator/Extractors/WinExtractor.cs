using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CliWrap;
using CliWrap.Buffered;
using Generator.API;
using Generator.Tools;

namespace Generator.Extractors
{
    public sealed class WinExtractor : IExtractor
    {
        private readonly string _tmpDir = FileTool.CreateOrGetDir("tmp_win")!;
        private readonly string _exePath = FindExe();

        public async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Wrap(_tmpDir).Chunk(200))
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
                var bytes = batch.Select(b => b.Bytes).ToArray();
                foreach (var step in ParseWinOutput(stdOut, bytes))
                    yield return step;
            }
        }

        private static IEnumerable<Decoded[]> ParseWinOutput(string stdOut, byte[][] bytes)
        {
            var lines = TextTool.ToLines(stdOut);
            const string sep = "[ ";
            List<Decoded>? list = null;
            var i = -1;
            foreach (var line in lines)
            {
                if (line.StartsWith(sep) && line.Split(sep, 2) is { Length: 2 } pt)
                {
                    i++;
                    if (list != null)
                        yield return list.ToArray();
                    list = new List<Decoded>();
                    continue;
                }
                if (ParseLine(line, bytes[i]) is not { } res)
                    continue;
                list!.Add(res);
            }
            if (list is { Count: >= 1 })
                yield return list.ToArray();
        }

        private static Decoded? ParseLine(string one, byte[] bytes)
        {
            var parts = TextTool.ToCol(one);
            if (parts.Length != 5)
                return null;
            var offset = short.Parse(parts[0]);
            var count = int.Parse(parts[1]);
            var hex = parts[2];
            var dis = parts[3];
            var left = int.Parse(parts[4]);
            return new Decoded(bytes.ToStr(), offset, count, hex, dis, left);
        }

        private static string FindExe()
        {
            var exeDir = FileTool.GetPath<WinExtractor>();
            var srcDir = Path.Combine(exeDir, "..", "..", "..", "..", "..");
            return Path.GetFullPath(Path.Combine(srcDir, "nat", "prepared", "Unasmsys.exe"));
        }
    }
}