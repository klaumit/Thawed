using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
			});
		}
	}
}