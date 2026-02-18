using System;
using System.Threading.Tasks;
using Generator.Tools;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Generator.Extractors;
using Generator.API;

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
            var cands = numbers.Select(BitTool.AsShort).ToArray();
            const int chunkSize = 200;
            var appS = (o.Misc ?? "").Split(';');

            var extractors = CreateExtractors(appS);
            await Task.WhenAll(
                extractors.Select(async e => await Run(e, chunkSize, cands, outDir))
            );

            Console.WriteLine("Done.");
        }

        private static IEnumerable<IExtractor> CreateExtractors(string[] apps)
        {
            foreach (var app in apps)
                yield return CreateExtractor(app);
        }

        private static IExtractor CreateExtractor(string app)
        {
            app = app.ToLowerInvariant();
            switch (app)
            {
                case "gnu": return new GnuExtractor();
                case "iced": return new IcedExtractor();
                case "nasm": return new NasmExtractor();
                case "win": return new WinExtractor();
                default: throw new InvalidOperationException(app);
            }
        }

        private static async Task Run(IExtractor exec, int chunkLen, byte[][] cands, string outDir)
        {
            var typ = exec.GetName();
            var fileName = Path.Combine(outDir, $"{typ}.csv");
            var known = new SortedSet<string>();
            var file = await CreateOrReadFile(typ, fileName, known);

            var maybe = Filter(cands, known);
            await foreach (var decoded in exec.Decode(maybe))
            {
                foreach (var o in decoded)
                {
                    var of = o.Offset;
                    if (of != 0)
                        continue;
                    var tp = o.Dis.Split(' ', 2);
                    var ih = o.Input;
                    var he = o.Hex;
                    var op = tp[0].Trim();
                    var ar = tp.Length == 2 ? tp[1].Trim() : string.Empty;
                    he = he.ToUpper();
                    var fld = new[] { typ, ih, $"{of:D5}", $"{o.Count:D2}", he, op, ar, $"{o.Left:D2}" };
                    var txt = string.Join(",", fld.Select(f => $"\"{f}\""));
                    await file.WriteLineAsync(txt);
                }
                await file.FlushAsync();
            }
            await file.FlushAsync();
        }

        private static async Task<StreamWriter> CreateOrReadFile(string typ, string name, ISet<string> known)
        {
            StreamWriter file;
            if (File.Exists(name))
            {
                await FindOldHex(name, known);
                file = File.AppendText(name);
                file.AutoFlush = true;
                Console.WriteLine($" # {typ,-4} ->> {name}");
            }
            else
            {
                file = File.CreateText(name);
                file.AutoFlush = true;
                var head = new[] { "App", "Input", "Offset", "Count", "Hex", "Op", "Arg", "Left" };
                var line = string.Join(",", head.Select(h => $"\"{h}\""));
                await file.WriteLineAsync(line);
                Console.WriteLine($" # {typ,-4} --> {name}");
            }
            return file;
        }

        private static async Task FindOldHex(string fileName, ISet<string> set)
        {
            var oldLines = await File.ReadAllLinesAsync(fileName, Encoding.UTF8);
            foreach (var oldLine in oldLines.Skip(1))
            {
                var cols = TextTool.ToCol(oldLine);
                var hex = cols[1].ToUpper();
                set.Add(hex);
            }
        }

        private static IEnumerable<byte[]> Filter(IEnumerable<byte[]> all, ISet<string> known)
        {
            foreach (var array in all)
            {
                var hex = Convert.ToHexString(array);
                if (known.Contains(hex))
                    continue;
                yield return array;
            }
        }

        private static IEnumerable<byte[]> GetCands()
        {
            foreach (var b in IterTool.Go(byte.MinValue, byte.MaxValue + 1, BitTool.AsByte))
                yield return b;
            foreach (var b in IterTool.Go(ushort.MinValue, ushort.MaxValue + 1, BitTool.AsShort))
                yield return b;
        }
    }
}