using System;
using System.Threading.Tasks;
using Generator.Extractors;
using static Generator.Tools.FileTool;

namespace Generator.Core
{
    internal static class CodeDump
    {
        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } outDir)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            if (CreateOrGetDir(o.InputDir) is not { } inpDir)
            {
                await Console.Error.WriteLineAsync("No input dir given!");
                return;
            }

            Console.WriteLine(" TODO "); // TODO

            // TODO

            Fuzzer.DoAll(a =>
            {
                var bytes = ExecDump.Assemble(a);
                if (bytes == null)
                    return;
                Console.WriteLine(Convert.ToHexString(bytes));
            });
        }
    }
}