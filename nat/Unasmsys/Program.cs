using System;
using System.Collections.Generic;
using System.Linq;
using Unasmsys.Core;

namespace Unasmsys
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var mode = args.FirstOrDefault()?.Trim();
			IEnumerable<IFile> files = mode switch
			{
				"-fi" => args.Skip(1).Select(a => new DiskFile(a)),
				"-hi" => args.Skip(1).Select((a, i) => new HexFile(a, i)),
				"-bi" => args.Skip(1).Select((a, i) => new BinFile(a, i)),
				_ => throw new InvalidOperationException($"Unknown mode ({mode})!")
			};
			foreach (var file in files)
				ProcessFile(file);
		}

		private static void ProcessFile(IFile obj)
		{
			var file = obj.Name;
			var bytes = obj.Bytes;
			Console.WriteLine();
			Console.WriteLine($"   [ {file} ]   ");
			foreach (var o in Help.Decode(bytes))
			{
				var line = $"\"{o.Offset:D5}\",\"{o.Count:D2}\",\"{o.Hex}\",\"{o.Dis}\",\"{o.Left:D5}\"";
				Console.WriteLine(line);
			}
			Console.WriteLine();
		}
	}
}