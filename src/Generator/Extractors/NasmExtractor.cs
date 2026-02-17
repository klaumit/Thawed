using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CliWrap;
using CliWrap.Buffered;
using Generator.API;
using Generator.Tools;

namespace Generator.Extractors
{
    public sealed class NasmExtractor : IExtractor
    {
        private readonly string _tmpDir = FileTool.CreateOrGetDir("tmp_nsm");

        public async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Wrap(_tmpDir).Chunk(1))
            {
                List<string> dArgs = ["-b", "16", "-p", "intel"];
                Array.ForEach(batch, b => dArgs.Add(b.File));

                const string cmd = "ndisasm";
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
                var size = batch.Single().Size;
                var bits = batch.Single().Bytes;
                yield return ParseNasmOutput(stdOut, size, bits).ToArray();
            }
        }

        private static IEnumerable<Decoded> ParseNasmOutput(string stdOut, int size, byte[] bytes)
        {
            var lines = TextTool.ToLines(stdOut);
            var left = size;
            foreach (var line in lines)
            {
                var cols = TextTool.ToCol(line, ' ', "  ")
                    .Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                var offset = int.Parse(cols[0], NumberStyles.HexNumber);
                var hex = cols[1];
                var count = hex.Length / 2;
                var dis = cols[2];
                left -= count;
                yield return new Decoded(bytes.ToStr(), (short)offset, count, hex, dis, left);
            }
        }
    }
}