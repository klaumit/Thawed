using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Generator.Core;
using static Generator.Tools.FileTool;
using static Generator.Tools.JsonTool;
using S = System.StringSplitOptions;
using E = System.Linq.Enumerable;
using N = System.Globalization.NumberStyles;
using KV = (string key, string val);

namespace Generator
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
        }
    }
}