using System.Collections.Generic;
using System.Threading.Tasks;
using Extracting.API;
using Extracting.Tools;
using System;
using System.Linq;
using CliWrap;
using CliWrap.Buffered;

namespace Extracting.Extractors
{
    public sealed class GnuExtractor : IExtractor
    {
        private readonly string _tmpDir = FileTool.CreateOrGetDir("tmp_gnu");

        public async Task<object> Decode(IEnumerable<byte[]> byteArrays)
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

                throw new System.NotImplementedException(dumpCmd.StandardOutput);
            }

            throw new System.NotImplementedException();
        }
    }
}