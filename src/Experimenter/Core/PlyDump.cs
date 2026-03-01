using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Generator.API;
using Generator.Extractors;
using Generator.Tools;
using Thawed;
using WE = Generator.Extractors.WinExtractor;
using static Generator.Tools.FileTool;
using static Generator.Tools.ArgTool;

namespace Experimenter.Core
{
    internal static class PlyDump
    {
        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } outDir)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            var args = ParseDict(o.Misc);
            var count = args.As<int?>("count") ?? 10;

            Console.WriteLine(args);
            Console.WriteLine(JsonTool.ToJson(args));



            Console.WriteLine("Done.");
        }
    }
}