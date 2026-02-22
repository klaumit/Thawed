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
			return string.Join(" ", bytes.Select(ToHexString));
		}
	}
}