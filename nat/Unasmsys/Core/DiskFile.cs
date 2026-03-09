using System.IO;

namespace Unasmsys.Core
{
	public sealed class DiskFile : IFile
	{
		private readonly string _file;

		public DiskFile(string file)
		{
			_file = file;
		}

		public string Name
			=> Path.GetFullPath(_file);

		public byte[] Bytes
			=> File.ReadAllBytes(_file);
	}
}