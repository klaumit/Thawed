using System;
using System.IO;
using System.Linq;
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
            var execs = CreateExtractors();
            var tasks = execs.Select(async e => await RunEx(e)).ToArray();
            await Task.WhenAll(tasks);
            Console.WriteLine("Done.");
        }

        private static async Task RunEx(object? obj)
        {
            var exec = (IExtractor)obj!;
            var typ = exec.GetName();

            var fileName = $"{typ}.csv";
            StreamWriter file;
            if (File.Exists(fileName))
            {
                file = File.AppendText(fileName);
                file.AutoFlush = true;
                Console.WriteLine($" # {typ} ->> {fileName}");
            }
            else
            {
                file = File.CreateText(fileName);
                file.AutoFlush = true;
                const string line = $"\"App\",\"Hex\",\"Parsed\"";
                await file.WriteLineAsync(line);
                Console.WriteLine($" # {typ} --> {fileName}");
            }

            var cands = IterTool.Go(0, 2, BitTool.AsShortB).Concat(
                new byte[][] { [90, 0x8B, 0xEC, 47, 63, 23, 38] }).Reverse().ToArray();

            await foreach (var decoded in exec.Decode(cands))
            {
                foreach (var one in decoded)
                {
                    var txt = $"\"{typ}\",\"{one}\"";
                    await file.WriteLineAsync(txt);
                }
            }

            await file.FlushAsync();
        }
    }
}