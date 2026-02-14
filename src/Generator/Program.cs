using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extracting.Extractors;
using Extracting.API;
using Extracting.Tools;

namespace Generator
{
    internal static class Program
    {
        private static IExtractor[] CreateExtractors()
            => [new IcedExtractor(), new NasmExtractor(), new WinExtractor(), new GnuExtractor()];

        private static async Task Main(string[] args)
        {
            await Task.WhenAll(CreateExtractors().Select(async e => await RunEx(e)));
            Console.WriteLine("Done.");
        }

        private static async Task RunEx(object? obj)
        {
            var exec = (IExtractor)obj!;
            var typ = exec.GetName();

            var fileName = $"{typ}.csv";
            var known = new SortedSet<string>();
            StreamWriter file;
            if (File.Exists(fileName))
            {
                await FindOldHex(fileName, known);
                file = File.AppendText(fileName);
                file.AutoFlush = true;
                Console.WriteLine($" # {typ} ->> {fileName}");
            }
            else
            {
                file = File.CreateText(fileName);
                file.AutoFlush = true;
                var head = new[] { "App", "Offset", "Count", "Hex", "Op", "Arg", "Left" };
                var line = string.Join(",", head.Select(h => $"\"{h}\""));
                await file.WriteLineAsync(line);
                Console.WriteLine($" # {typ} --> {fileName}");
            }

            var cands = GetCands();
            var maybe = Filter(cands, known);

            await foreach (var decoded in exec.Decode(maybe))
            {
                foreach (var o in decoded)
                {
                    var tp = o.Dis.Split(' ', 2);
                    var he = o.Hex;
                    var op = tp[0].Trim();
                    var ar = tp.Length == 2 ? tp[1].Trim() : string.Empty;
                    he = he.ToUpper();
                    op = op.ToUpper();
                    ar = ar.ToUpper();
                    var fld = new[] { typ, $"{o.Offset:D5}", $"{o.Count:D2}", he, op, ar, $"{o.Left:D2}" };
                    var txt = string.Join(",", fld.Select(f => $"\"{f}\""));
                    await file.WriteLineAsync(txt);
                }
            }

            await file.FlushAsync();
        }

        private static IEnumerable<byte[]> GetCands()
        {
            return IterTool.Go(0, 2, BitTool.AsShortB).Concat(
                new byte[][] { [90, 0x8B, 0xEC, 47, 63, 23, 38] }).Reverse();
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

        private static async Task FindOldHex(string fileName, ISet<string> set)
        {
            var oldLines = await File.ReadAllLinesAsync(fileName, Encoding.UTF8);
            foreach (var oldLine in oldLines.Skip(1))
            {
                var cols = TextTool.ToCol(oldLine);
                var hex = cols[3].ToUpper();
                set.Add(hex);
            }
        }
    }
}