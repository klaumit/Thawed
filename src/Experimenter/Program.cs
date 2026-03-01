using System.Threading.Tasks;
using CommandLine;
using Experimenter.Core;

namespace Experimenter
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