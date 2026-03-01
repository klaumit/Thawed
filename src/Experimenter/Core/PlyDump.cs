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
            var cntSp = $"{count}".Length;
            var rnd = new Random();

            var byteArrays = new List<byte[]>();
            for (var i = 1; i <= count; i++)
            {
                var idx = $"{i}".PadLeft(cntSp, '0');
                var num = rnd.NextInt64();
                var bits = BitConverter.GetBytes(num);
                Console.WriteLine($" #{idx} {Convert.ToHexString(bits)}");
                byteArrays.Add(bits);
            }

            var ex = new IcedExtractor();
            await BinDump.Display(Console.Out, byteArrays, ex);

            Console.WriteLine("Done.");
        }
    }
}