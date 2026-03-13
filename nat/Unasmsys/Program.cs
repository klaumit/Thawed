using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unasmsys.Core;
using static Unasmsys.Core.Pipes;
using static Unasmsys.Core.Serv;

namespace Unasmsys
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var mode = args.FirstOrDefault()?.Trim();
			(TextWriter w, IEnumerable<IFile> f) parsed = mode switch
			{
				"-fi" => (Console.Out, args.Skip(1).Select(a => new DiskFile(a))),
				"-hi" => (Console.Out, args.Skip(1).Select((a, i) => new HexFile(a, i))),
				"-bi" => (Console.Out, args.Skip(1).Select((a, i) => new BinFile(a, i))),
				"-si" => (GetBuffered(Console.Out), ReadArgsByInput(Console.In)),
				"-ni" => ReadArgsByNetwork(Console.Out, args.Skip(1).ToArray()),
				_ => throw new InvalidOperationException($"Unknown mode ({mode})!")
			};
			var (@out, files) = parsed;
			foreach (var file in files)
			{
				ProcessFile(file, @out);
				@out.Flush();
			}
		}

		private static void ProcessFile(IFile obj, TextWriter con)
		{
			var file = obj.Name;
			var bytes = obj.Bytes;
			con.WriteLine();
			con.WriteLine($"   [ {file} ]   ");
			foreach (var o in Help.Decode(bytes))
			{
				var line = $"\"{o.Offset:D5}\",\"{o.Count:D2}\",\"{o.Hex}\",\"{o.Dis}\",\"{o.Left:D5}\"";
				con.WriteLine(line);
			}
			con.WriteLine();
		}
	}
}