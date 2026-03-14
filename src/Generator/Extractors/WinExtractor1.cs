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
    public sealed class WinFiExtractor : WinBaseExtractor, IExtractor
    {
        private readonly string _tmpDir = FileTool.CreateOrGetDir("tmp_win")!;

        public int ArgCount { get; set; } = 1000;
        public char ArgPrefix { get; set; } = 'a';

        public override async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Wrap(_tmpDir, ArgPrefix).Chunk(ArgCount))
            {
                List<string> dArgs = [_exePath, "-fi"];
                Array.ForEach(batch, b => dArgs.Add(Path.GetRelativePath(_tmpDir, b.File)));

                const string cmd = "wine";
                var dumpCmd = await Cli.Wrap(cmd)
                    .WithArguments(dArgs)
                    .WithWorkingDirectory(_tmpDir)
                    .WithValidation(CommandResultValidation.None)
                    .ExecuteBufferedAsync();

                Array.ForEach(batch, b => b.Dispose());

                var error = dumpCmd.StandardError;
                if (!string.IsNullOrWhiteSpace(error) || dumpCmd.ExitCode != 0)
                {
                    // throw new InvalidOperationException($"[{dumpCmd.ExitCode}] {error}");
                    yield return [];
                }

                var stdOut = dumpCmd.StandardOutput;
                var bytes = batch.Select(b => b.Bytes).ToArray();
                foreach (var step in ParseWinOutput(stdOut, bytes))
                    yield return step;
            }
        }
    }
}