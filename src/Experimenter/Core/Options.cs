using CommandLine;

// ReSharper disable ClassNeverInstantiated.Global

namespace Generator.Core
{
	public class Options
	{
		[Option('b', "bin", HelpText = "Print binary codes.")]
		public bool TryBinary { get; set; }
	}
}