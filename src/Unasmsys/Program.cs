using System;
using System.IO;

namespace Unasmsys
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			foreach (var arg in args)
			{
				var file = Path.GetFullPath(arg);
				ProcessFile(file);
			}
		}

		private static void ProcessFile(string file)
		{
			var bytes = File.ReadAllBytes(file);
			foreach (var o in Help.Decode(bytes))
			{
				var line = $"\"{o.Offset:D5}\",\"{o.Count:D2}\",\"{o.Hex}\",\"{o.Dis}\",\"{o.Left:D5}\"";
				Console.WriteLine(line);
			}
		}
	}
}