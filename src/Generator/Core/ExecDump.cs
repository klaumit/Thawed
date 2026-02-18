using System;
using System.Threading.Tasks;
using Generator.Tools;

namespace Generator.Core
{
    internal static class ExecDump
    {
        private static readonly string Nl = Environment.NewLine;

        internal static async Task Run(Options o)
        {
            if (FileTool.CreateOrGetDir(o.OutputDir) is not { } outDir)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            var numbers = IterTool.Iter16Bit();
            const int chunkSize = 200;
            var appS = (o.Misc ?? "").Split(';');

            Console.WriteLine("Done.");
        }
    }
}