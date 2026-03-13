using System;
using System.Linq;
using Unasmsys.Core;
using static Unasmsys.Core.Pipes;
using static Unasmsys.Core.Serv;
using C = System.Console;

namespace Unasmsys
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var mode = args.FirstOrDefault()?.Trim();
			var files = mode switch
			{
				"-fi" => C.Out.Wrap(args.Skip(1).Select(a => new DiskFile(a))),
				"-hi" => C.Out.Wrap(args.Skip(1).Select((a, i) => new HexFile(a, i))),
				"-bi" => C.Out.Wrap(args.Skip(1).Select((a, i) => new BinFile(a, i))),
				"-si" => GetBuffered(C.Out).Wrap(ReadArgsByInput(C.In)),
				"-ni" => ReadArgsByNetwork(C.Out, args.Skip(1).ToArray()),
				_ => throw new InvalidOperationException($"Unknown mode ({mode})!")
			};
			foreach (var file in files)
			{
				ProcessFile(file);
				file.Out.Flush();
			}
		}

		private static void ProcessFile(IExFile obj)
		{
			var con = obj.Out;
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