using System;

namespace Unasmsys.Core
{
	public sealed class HexFile : IFile
	{
		private readonly string _hex;
		private readonly int _idx;

		public HexFile(string hex, int idx)
		{
			_hex = hex;
			_idx = idx;
		}

		public string Name
			=> $"hex{_idx}.com";

		public byte[] Bytes
			=> Convert.FromHexString(_hex);
	}
}