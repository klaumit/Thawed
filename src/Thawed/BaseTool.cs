using System.Linq;

namespace Thawed
{
	internal static class BaseTool
	{
		private static string ToHexString(byte b) => $"{b:X2}";
		internal static string ToHexString(this byte[] bytes) => string.Join("", bytes.Select(ToHexString));

		private static string ToHexString(byte? b) => b == null ? "__" : $"{b:X2}";
		internal static string ToHexString(this byte?[] bytes) => string.Join("", bytes.Select(ToHexString));

		public static string ToSymbol(this OpWidth val)
			=> val switch
			{
				OpWidth.Bits8 => "D8", OpWidth.Bits16 => "D16", _ => "DA"
			};

		public static string ToSymbol(this Register val)
		{
			var txt = val.ToString().ToUpperInvariant();
			switch (val)
			{
				case Register.cs:
				case Register.ds:
				case Register.es:
				case Register.ss:
					txt += ":";
					break;
			}
			return txt;
		}

		public static byte? ReadByte(this IByteReader reader)
		{
			var res = reader.ReadOne();
			return res == -1 ? null : (byte)res;
		}
	}
}