using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator.Extractors;
using Generator.Tools;
using WE = Generator.Extractors.WinExtractor;
using IE = Generator.Extractors.IcedExtractor;
using NE = Generator.Extractors.NasmExtractor;
using GE = Generator.Extractors.GnuExtractor;
using static Generator.Tools.FileTool;
using static Generator.Tools.ArgTool;

namespace Experimenter.Core
{
    internal static class PlyDump
    {
        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } oD)
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

            var co = Console.Out;

            var e1 = new IE();
            var ex1 = new JsonExtractor<IE>(oD, e1);
            Console.WriteLine($" {{ {FuzzerX.GetName(e1)} }} ");
            await BinDump.Display(co, byteArrays, ex1, Filter, false, false);

            var e2 = new GE();
            var ex2 = new JsonExtractor<GE>(oD, e2);
            Console.WriteLine($" {{ {FuzzerX.GetName(e2)} }} ");
            await BinDump.Display(co, byteArrays, ex2, Filter, false, false);

            var e3 = new NE();
            var ex3 = new JsonExtractor<NE>(oD, e3);
            Console.WriteLine($" {{ {FuzzerX.GetName(e3)} }} ");
            await BinDump.Display(co, byteArrays, ex3, Filter, false, false);

            var e4 = new WE();
            var ex4 = new JsonExtractor<WE>(oD, e4);
            Console.WriteLine($" {{ {FuzzerX.GetName(e4)} }} ");
            await BinDump.Display(co, byteArrays, ex4, Filter, false, false);

            Console.WriteLine();
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