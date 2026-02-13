using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Unasmsys
{
	internal static class Help
	{
		internal static IEnumerable<Decoded> Decode(byte[] bytes)
		{
			short offset = 0;
			const short mode = 0;
			var codePtr = Marshal.AllocHGlobal(bytes.Length);
			Marshal.Copy(bytes, 0, codePtr, bytes.Length);

			const int bufferSize = 256;
			var buffer = Marshal.AllocHGlobal(bufferSize);
			try
			{
				var left = bytes.Length;
				while (left >= 1)
				{
					var count = Api.Unasm1Line(buffer, mode, codePtr + offset);
					var dis = Tool.FromAnsi(buffer);
					var hex = Tool.ReadHex(codePtr, count, offset);
					left -= count;

					yield return new Decoded(offset, count, hex, dis, left);
					offset = (short)(offset + count);
				}
			}
			finally
			{
				Marshal.FreeHGlobal(buffer);
				Marshal.FreeHGlobal(codePtr);
			}
		}
	}
}