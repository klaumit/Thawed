using System;
using System.Collections.Generic;
using System.Linq;
using CliWrap;
using CliWrap.Buffered;
using Generator.API;
using Generator.Tools;

namespace Generator.Extractors
{
    public sealed class GnuExtractor : IExtractor
    {
        private readonly string _tmpDir = FileTool.CreateOrGetDir("tmp_gnu");

        public async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Wrap(_tmpDir).Chunk(100))
            {
                List<string> dArgs = ["-D", "-Mintel,i8086", "-b", "binary", "-m", "i386", "-z"];
                Array.ForEach(batch, b => dArgs.Add(b.File));

                const string cmd = "objdump";
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
                var sizes = batch.Select(b => b.Size).ToArray();
                var arrays = batch.Select(b => b.Bytes).ToArray();
                foreach (var step in ParseGnuOutput(stdOut, arrays, sizes))
                    yield return step;
            }
        }

        private static IEnumerable<Decoded[]> ParseGnuOutput(string stdOut, byte[][] arrays, int[] sizes)
        {
            var lines = TextTool.ToLines(stdOut);
            const string sep = "00000000 <.data>:";
            List<Decoded>? list = null;
            var i = -1;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) ||
                    (line.Contains(':') && line.Contains("file format binary")) ||
                    line.Contains("Disassembly of section"))
                    continue;
                if (line.StartsWith(sep) && line.Split(sep, 2) is { Length: 2 } pt)
                {
                    i++;
                    if (list != null)
                        yield return list.ToArray();
                    list = new List<Decoded>();
                    continue;
                }
                if (ParseLine(line, ref sizes[i], arrays[i]) is not { } res)
                    continue;
                list!.Add(res);
            }
            if (list is { Count: >= 1 })
                yield return list.ToArray();
        }

        private static Decoded? ParseLine(string one, ref int left, byte[] bytes)
        {
            var parts = one.Split((char)9)
                .Select(p => p.Trim()).ToArray();
            if (parts.Length != 3)
                return null;
            var offset = short.Parse(parts[0].TrimEnd(':'));
            var hex = parts[1].Replace(" ", "");
            var dis = parts[2];
            var count = hex.Length / 2;
            left -= count;
            return new Decoded(bytes.ToStr(), offset, count, hex, dis, left);
        }
    }
}