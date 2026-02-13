using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CliWrap;
using CliWrap.Buffered;
using Unasmsys;

namespace Extracting
{
	public sealed class AsmExtractor : IExtractor
	{
		private readonly string _tmpDir;

		public AsmExtractor()
		{
			_tmpDir = FileTool.CreateOrGetDir("tmp");
		}

		public async Task<object> Decode(byte[] bytes)
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

			return ParseLines(dumpCmd.StandardOutput);
		}

		private Dictionary<string, List<Decoded>> ParseLines(string stdOut)
		{
			var stdLin = TextTool.ToLines(stdOut);
			const string sep = "[ ";

			var dict = new Dictionary<string, List<Decoded>>();
			var ptFile = string.Empty;
			foreach (var one in stdLin)
			{
				if (one.StartsWith(sep) && one.Split(sep, 2) is { Length: 2 } pt)
				{
					ptFile = pt.Last().Trim(']', ' ');
					continue;
				}
				if (!dict.TryGetValue(ptFile, out var list))
					dict[ptFile] = list = [];
				if (ParseLine(one) is not { } res)
					continue;
				list.Add(res);
			}
			return dict;
		}

		private static Decoded? ParseLine(string one)
		{
			var parts = TextTool.ToCol(one);
			if (parts.Length != 5)
				return null;
			var offset = short.Parse(parts[0]);
			var count = int.Parse(parts[1]);
			var hex = parts[2];
			var dis = parts[3];
			var left = int.Parse(parts[4]);
			return new Decoded(offset, count, hex, dis, left);
		}
	}
}