using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var limit = args.As<int?>("limit") ?? 8;
            var only = args.As<int?>("only");
            var rnd = new Random();

            var byteArrays = new List<byte[]>();
            for (var i = 1; i <= count; i++)
            {
                var num = rnd.NextInt64();
                var bits = BitConverter.GetBytes(num).Take(limit).ToArray();
                byteArrays.Add(bits);
            }

            var ex = new IcedExtractor();
            await BinDump.Display(Console.Out, byteArrays, ex, Filter);

            Console.WriteLine("Done.");
            return;

            bool Filter(string h)
            {
                var hex = h.Replace(" ", "");
                var ic = hex.Length / 2;
                return only == null || only == ic;
            }
        }
    }
}