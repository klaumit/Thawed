using System;
using System.Linq;

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
	}
}