using System;
using System.Runtime.InteropServices;
using static Unasmsys.Def;

// ReSharper disable IdentifierTypo

namespace Unasmsys
{
	internal static class Api
	{
		[DllImport("unasmsys_win32", CallingConvention = Cc, CharSet = A)]
		internal static extern int Unasm1Line(IntPtr outStrBuffer, short offset, IntPtr codePtr);
	}
}