using CommandLine;

// ReSharper disable ClassNeverInstantiated.Global

namespace Experimenter.Core
{
	public class Options
	{
		[Option('b', "bin", HelpText = "Print binary codes.")]
		public bool TryBinary { get; set; }

		[Option('o', "output", HelpText = "Set output directory.")]
		public string? OutputDir { get; set; }
	}
}