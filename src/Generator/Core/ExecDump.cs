using System;
using System.Threading.Tasks;
using Generator.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Extractors;
using Generator.API;
using Generator.Tools;

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
            const int chunkSize = 200;
            var appS = (o.Misc ?? "").Split(';');

            var extractors = CreateExtractors(appS);
            await Task.WhenAll(
                extractors.Select(async e => await Run(e, chunkSize, numbers, outDir))
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

        private static async Task Run(IExtractor exec, int chunkLen, int[] numbers, string outDir)
        {
            var typ = exec.GetName();
            var fileName = Path.Combine(outDir, $"{typ}.csv");
            var known = new SortedSet<string>();
            var file = await CreateOrReadFile(typ, fileName, known);





            
            





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
    }
}