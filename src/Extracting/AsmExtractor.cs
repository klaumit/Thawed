using System.Runtime.InteropServices;

namespace Extracting
{
	public sealed class AsmExtractor : IExtractor
	{
		public Task<string> Decode(byte[] bytes)
		{
			var res = DecodeSync(bytes);
			return Task.FromResult(res);
		}

		private static string DecodeSync(byte[] bytes)
		{
			const short offset = 0;
			var codePtr = Marshal.AllocHGlobal(bytes.Length);
			Marshal.Copy(bytes, 0, codePtr, bytes.Length);

			const int bufferSize = 256;
			var buffer = Marshal.AllocHGlobal(bufferSize);
			try
			{
				var count = Unasm1Line(buffer, offset, codePtr);
				var dis = FromAnsi(buffer);
				_ = ReadHex(codePtr, count);

				if (count > bytes.Length)
					return "___";

				var txt = TextTool.CleanUp(dis);
				return txt.Trim();
			}
			finally
			{
				Marshal.FreeHGlobal(buffer);
				Marshal.FreeHGlobal(codePtr);
			}
		}

		private static string FromAnsi(IntPtr textBuff, int len = 128)
		{
			var text = Marshal.PtrToStringAnsi(textBuff, len);
			var parts = text.Split('\0', 2);
			return parts[0];
		}

		private static string ReadHex(IntPtr ptr, int count)
		{
			var array = ReadBytes(ptr, count);
			return Convert.ToHexString(array);
		}

		private static byte[] ReadBytes(IntPtr ptr, int count)
		{
			var array = new byte[count];
			for (var i = 0; i < count; i++)
				array[i] = Marshal.ReadByte(ptr, i);
			return array;
		}

		private const CallingConvention Cc = CallingConvention.StdCall;
		private const CharSet A = CharSet.Ansi;

		[DllImport("unasmsys", CallingConvention = Cc, CharSet = A)]
		private static extern int Unasm1Line(IntPtr outStrBuffer, short offset, IntPtr codePtr);
	}
}