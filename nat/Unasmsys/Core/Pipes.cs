using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Unasmsys.Core
{
	internal static class Pipes
	{
		private sealed class BuffWriter : StringWriter
		{
			private readonly TextWriter _writer;

			public BuffWriter(TextWriter writer)
			{
				_writer = writer;
			}

			public override void Flush()
			{
				base.Flush();
				var bld = GetStringBuilder();
				var text = bld.ToString();
				bld.Clear();
				_writer.WriteLine(text);
				_writer.Flush();
			}
		}

		public static TextWriter GetBuffered(TextWriter writer) => new BuffWriter(writer);

		private static IEnumerable<IFile>? ReadArgsByInput(string? line)
		{
			if (string.IsNullOrWhiteSpace(line))
				return null;
			var parts = line.Split(' ');
			if (parts.Length < 2)
				return null;
			var mode = parts[0];
			var args = parts.Skip(1);
			IEnumerable<IFile> res = mode switch
			{
				"f" => args.Select(a => new DiskFile(a)),
				"h" => args.Select((a, i) => new HexFile(a, i)),
				"b" => args.Select((a, i) => new BinFile(a, i)),
				_ => throw new InvalidOperationException($"Unknown mode ({mode})!")
			};
			return res;
		}

		public static IEnumerable<IFile> ReadArgsByInput(TextReader reader)
		{
			string? line;
			while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
				if (ReadArgsByInput(line) is { } files)
					foreach (var file in files)
						yield return file;
		}
	}
}