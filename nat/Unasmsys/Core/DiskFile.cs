using System.IO;

namespace Unasmsys.Core
{
	internal sealed class DiskFile : IFile
	{
		private readonly string _file;

		internal DiskFile(string file)
		{
			_file = file;
		}

		public string Name
			=> Path.GetFullPath(_file);

		public byte[] Bytes
			=> File.ReadAllBytes(_file);
	}
}