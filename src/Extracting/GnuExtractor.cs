using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;

namespace Extracting
{
    public sealed class GnuExtractor : IExtractor
    {
        private readonly string _tmpDir;

        public GnuExtractor()
        {
            _tmpDir = FileTool.CreateOrGetDir("tmp");
        }

        public async Task<object> Decode(byte[] bytes)
        {
            var tmpBin = await FileTool.WriteNewFile(_tmpDir, bytes);
            List<string> dArgs = ["-D", "-Mintel,i8086", "-b", "binary", "-m", "i386", "-z", tmpBin];

            const string cmd = "objdump";
            var dumpCmd = await Cli.Wrap(cmd)
                .WithArguments(dArgs)
                .WithWorkingDirectory(_tmpDir)
                .WithValidation(CommandResultValidation.None)
                .ExecuteBufferedAsync();

            File.Delete(tmpBin);
            var error = dumpCmd.StandardError;
            if (!string.IsNullOrWhiteSpace(error) || dumpCmd.ExitCode != 0)
                throw new InvalidOperationException($"[{dumpCmd.ExitCode}] {error}");

            var stdOut = dumpCmd.StandardOutput;
            var txt = stdOut.Split("0:", 2).Last()
                .Split('\n', 2).First().Split((char)0x9, 3)[2];

            return TextTool.CleanUp(txt);
        }
    }
}