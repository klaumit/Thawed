using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Generator.Extractors;
using Generator.Tools;
using WE = Generator.Extractors.WinExtractor;
using IE = Generator.Extractors.IcedExtractor;
using NE = Generator.Extractors.NasmExtractor;
using GE = Generator.Extractors.GnuExtractor;
using Sd = System.Collections.Generic.SortedDictionary<string, 
    System.Collections.Generic.IDictionary<string, 
        System.Collections.Generic.ISet<string>>>;
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

            const string s = " ";
            var sd = new Sd();
            var byteArrays = new List<byte[]>();
            for (var i = 1; i <= count; i++)
            {
                var num = rnd.NextInt64();
                var bits = BitConverter.GetBytes(num).Take(limit).ToArray();
                byteArrays.Add(bits);
            }

            await using var so1 = new StringWriter();
            var e1 = new IE();
            var ex1 = new JsonExtractor<IE>(oD, e1);
            var en1 = FuzzerX.GetName(e1);
            await BinDump.Display(so1, byteArrays, ex1, Filter, false, false, s);
            await so1.FlushAsync();
            ParseOut(sd, en1, so1);

            await using var so2 = new StringWriter();
            var e2 = new GE();
            var ex2 = new JsonExtractor<GE>(oD, e2);
            var en2 = FuzzerX.GetName(e2);
            await BinDump.Display(so2, byteArrays, ex2, Filter, false, false, s);
            await so2.FlushAsync();
            ParseOut(sd, en2, so2);

            await using var so3 = new StringWriter();
            var e3 = new NE();
            var ex3 = new JsonExtractor<NE>(oD, e3);
            var en3 = FuzzerX.GetName(e3);
            await BinDump.Display(so3, byteArrays, ex3, Filter, false, false, s);
            await so3.FlushAsync();
            ParseOut(sd, en3, so3);

            await using var so4 = new StringWriter();
            var e4 = new WE();
            var ex4 = new JsonExtractor<WE>(oD, e4);
            var en4 = FuzzerX.GetName(e4);
            await BinDump.Display(so4, byteArrays, ex4, Filter, false, false, s);
            await so4.FlushAsync();
            ParseOut(sd, en4, so4);

            foreach (var kp1 in sd)
            {
                Console.WriteLine();
                foreach (var kp2 in kp1.Value)
                foreach (var kp3 in kp2.Value)
                {
                    Console.WriteLine($" {kp2.Key,-4} {kp3} ");
                }
            }

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

        private static void ParseOut(Sd dict, string prefix, StringWriter writer)
        {
            var text = writer.ToString();
            foreach (var line in text.Split('\n'))
            {
                var parts = line.Split('|', 2);
                var key = parts[0].Trim();
                if (string.IsNullOrWhiteSpace(key))
                    continue;
                if (!dict.TryGetValue(key, out var sub))
                    dict[key] = sub = new SortedDictionary<string, ISet<string>>();
                if (!sub.TryGetValue(prefix, out var hit))
                    sub[prefix] = hit = new SortedSet<string>();
                hit.Add(line);
            }
        }
    }
}