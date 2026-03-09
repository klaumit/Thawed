using System;
using System.Linq;

namespace Unasmsys.Core
{
	internal sealed class BinFile : IFile
	{
		private readonly string _bin;
		private readonly int _idx;

		internal BinFile(string bin, int idx)
		{
			_bin = bin;
			_idx = idx;
		}

		public string Name
			=> $"bin{_idx}.com";

		public byte[] Bytes
			=> _bin.Chunk(8).Select(c => Convert.ToByte(new string(c), 2)).ToArray();
	}
}