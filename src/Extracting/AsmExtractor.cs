using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using CliWrap;
using CliWrap.Buffered;

namespace Extracting
{
	public sealed class AsmExtractor : IExtractor
	{
		private readonly string _tmpDir;

		public AsmExtractor()
		{
			_tmpDir = FileTool.CreateOrGetDir("tmp");
		}

		public async Task<string> Decode(byte[] bytes)
		{
			var tmpBin = await FileTool.WriteNewFile(_tmpDir, bytes);
			List<string> dArgs = ["../../../../../prepared/Unasmsys.exe", tmpBin];

			const string cmd = "wine";
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
			throw new InvalidOperationException("'" + stdOut + "'");
		}
	}
}