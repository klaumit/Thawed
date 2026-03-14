using System.Threading.Tasks;
using CommandLine;
using Generator.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using Generator.API;
using Generator.Extractors;
using Generator.Tools;
using System;
using System.Linq;
using System.Threading.Tasks;
using Generator.API;
using Generator.Extractors;
using Generator.Tools;

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
				else if (o.TryDoc)
				{
					await DocDump.Run(o);
				}
				else if (o.TryCheck)
				{
					await DbgDump.Run(o);
				}
				else if (o.TryRandom)
				{
					await RndDump.Run(o);
				}
				else if (o.TryDecode)
				{
					await ExecDump.Run(o);
				}
			});
		}
	}
}