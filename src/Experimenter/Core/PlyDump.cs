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

            var args = ArgTool.ParseDict(o.Misc);

            Console.WriteLine(args);
            Console.WriteLine(JsonTool.ToJson(args));
            
            

            Console.WriteLine("Done.");
        }
    }
}