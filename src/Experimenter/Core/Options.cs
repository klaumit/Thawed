using CommandLine;

// ReSharper disable ClassNeverInstantiated.Global

namespace Experimenter.Core
{
	public class Options
	{
		[Option('b', "bin", HelpText = "Print binary codes.")]
		public bool TryBinary { get; set; }

		[Option('k', "grp", HelpText = "Group binary codes.")]
		public bool TryGroup { get; set; }

		[Option('p', "play", HelpText = "Play binary codes.")]
		public bool TryPlay { get; set; }

		[Option('m', "misc", HelpText = "Set misc parameters.")]
		public string? Misc { get; set; }

		[Option('o', "output", HelpText = "Set output directory.")]
		public string? OutputDir { get; set; }
	}
}