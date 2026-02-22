using System.Linq;

namespace Thawed
{
	internal static class BaseTool
	{
		private static string ToHexString(byte b)
		{
			return $"{b:X2}";
		}

		internal static string ToHexString(this byte[] bytes)
		{
			return string.Join("", bytes.Select(ToHexString));
		}

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
	}
}