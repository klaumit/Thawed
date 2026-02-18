using System.Threading.Tasks;
using CommandLine;
using Generator.Core;

namespace Generator
{
	internal static class Program
	{
		private static async Task Main(string[] args)
		{
			var parser = Parser.Default;
			await parser.ParseArguments<Options>(args).WithParsedAsync(async o =>
			{
				if (o.TryCoder)
				{
					await CodeDump.Run(o);
				}
				else if (o.TryDecode)
				{
					await ExecDump.Run(o);
				}
			});
		}
	}
}