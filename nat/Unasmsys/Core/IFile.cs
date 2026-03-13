using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Unasmsys.Core
{
	internal interface IFile
	{
		string Name { get; }
		byte[] Bytes { get; }
	}

	internal interface IExFile : IFile
	{
		TextWriter Out { get; }
	}

	internal static class Absolute
	{
		private sealed class ExFile : IExFile
		{
			private readonly IFile _file;

			public ExFile(IFile file, TextWriter writer)
			{
				_file = file;
				Out = writer;
			}

			public string Name => _file.Name;
			public byte[] Bytes => _file.Bytes;
			public TextWriter Out { get; }
		}

		public static IEnumerable<IExFile> Wrap(this TextWriter writer, IEnumerable<IFile> files)
			=> files.Select(f => new ExFile(f, writer));
	}
}