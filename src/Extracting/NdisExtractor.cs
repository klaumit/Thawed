using CliWrap;
using CliWrap.Buffered;

namespace Extracting
{
	public sealed class NdisExtractor : IExtractor
    {
        private readonly string _tmpDir;

        public NdisExtractor()
        {
            _tmpDir = FileTool.CreateOrGetDir("tmp");
        }

        public async Task<string> Decode(byte[] bytes)
        {
            var tmpBin = await FileTool.WriteNewFile(_tmpDir, bytes);
            List<string> dArgs = ["-b", "16", "-p", "intel", tmpBin];

            const string cmd = "ndisasm";
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
            var txt = stdOut.Split("  ", 3).Last()
                .Split('\n', 2)[0];

            return txt.Trim();
        }
    }
}