using System;
using System.Collections.Generic;
using System.Linq;
using CliWrap;
using CliWrap.Buffered;
using Generator.API;

namespace Generator.Extractors
{
    public sealed class WinHiExtractor : WinExtractor
    {
        public int ArgCount { get; set; } = 1000;

        public override async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Chunk(ArgCount))
            {
                List<string> dArgs = [ExePath, "-hi"];
                Array.ForEach(batch, b => dArgs.Add(Convert.ToHexString(b)));

                const string cmd = "wine";
                var dumpCmd = await Cli.Wrap(cmd)
                    .WithArguments(dArgs)
                    .WithValidation(CommandResultValidation.None)
                    .ExecuteBufferedAsync();

                var error = dumpCmd.StandardError;
                if (!string.IsNullOrWhiteSpace(error) || dumpCmd.ExitCode != 0)
                {
                    // throw new InvalidOperationException($"[{dumpCmd.ExitCode}] {error}");
                    yield return [];
                }

                var stdOut = dumpCmd.StandardOutput;
                var bytes = batch.Select(b => b).ToArray();
                foreach (var step in ParseWinOutput(stdOut, bytes))
                    yield return step;
            }
        }
    }
}