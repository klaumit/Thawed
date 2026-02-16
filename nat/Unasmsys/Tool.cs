using System;
using System.Runtime.InteropServices;

namespace Unasmsys
{
	internal static class Tool
	{
		internal static string FromAnsi(IntPtr textBuff, int len = 128)
		{
			var text = Marshal.PtrToStringAnsi(textBuff, len);
			var parts = text.Split('\0', 2);
			return parts[0];
		}

		internal static string ReadHex(IntPtr ptr, int count, int off)
		{
			var array = ReadBytes(ptr, count, off);
			return Convert.ToHexString(array);
		}

		private static byte[] ReadBytes(IntPtr ptr, int count, int off)
		{
			var array = new byte[count];
			for (var i = 0; i < count; i++)
				array[i] = Marshal.ReadByte(ptr, off + i);
			return array;
		}
	}
}