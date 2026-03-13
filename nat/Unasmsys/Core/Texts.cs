using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Unasmsys.Core
{
	internal static class Texts
	{
		private static string CleanArg(this string txt)
			=> txt.Replace("_", "");

		public static byte[] FromBin(this string txt)
			=> txt.CleanArg().Chunk(8).Select(c => Convert.ToByte(new string(c), 2)).ToArray();

		public static byte[] FromHex(this string txt)
			=> Convert.FromHexString(txt.CleanArg());

		public static IEnumerable<string> TakeWhile(this TextReader reader, Func<string, bool> go)
		{
			while (reader.ReadLine() is { } line)
			{
				yield return line;
				if (!go(line)) break;
			}
		}

		public static string ReadStr(this StreamReader reader, int count)
		{
			var bld = new StringBuilder();
			int last;
			while (!reader.EndOfStream && (last = reader.Read()) != -1)
			{
				bld.Append((char)last);
				if (bld.Length >= count)
					break;
			}
			return bld.ToString();
		}

		public static string? TryReadLine(this TextReader reader)
		{
			try
			{
				return reader.ReadLine();
			}
			catch (ObjectDisposedException)
			{
				return null;
			}
		}
	}
}