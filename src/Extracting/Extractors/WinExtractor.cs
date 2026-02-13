using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extracting.API;
using Extracting.Tools;
using System;
using CliWrap;
using CliWrap.Buffered;

namespace Extracting.Extractors
{
    public sealed class WinExtractor : IExtractor
    {
        private readonly string _tmpDir = FileTool.CreateOrGetDir("tmp_win");

        public async Task<object> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var batch in byteArrays.Wrap(_tmpDir).Chunk(100))
            {
                List<string> dArgs = ["../../../../../prepared/Unasmsys.exe"];
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

                throw new System.NotImplementedException(dumpCmd.StandardOutput);
            }

            throw new System.NotImplementedException();
        }
    }
}