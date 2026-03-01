using System.Threading.Tasks;
using CommandLine;
using Generator.Core;
using xxx;

namespace Generator
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            var parser = Parser.Default;
            await parser.ParseArguments<Options>(args).WithParsedAsync(async o =>
            {
                if (o.TryBinary)
                {
                    await BinDump.Run(o);
                }
            });
        }
    }
}