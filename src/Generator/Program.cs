using System;
using System.Linq;
using System.Threading.Tasks;
using Extracting.Extractors;
using Extracting.API;
using Extracting.Tools;
using Generator.Tools;
using static Extracting.Tools.IterTool;

namespace Generator
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            IExtractor[] execs = [ /*new GnuExtractor(), new WinExtractor(),*/ new IcedExtractor(), new NasmExtractor()];
            foreach (var exec in execs)
            {
                var typ = exec.GetType().Name.Replace(nameof(IExtractor).Trim('I'), "");
                Console.WriteLine($" # {typ}");
                
                // await using var file = File.CreateText($"{typ}.csv");
                // file.AutoFlush = true;
                // var line = $"\"App\",\"Hex\",\"Parsed\"";
                // await file.WriteLineAsync(line);

                var bb = Go(0, 2, BitTool.AsShortB).Concat(
                    new byte[][] { [90, 0x8B, 0xEC, 47, 63, 23, 38] }).Reverse().ToArray();

                await foreach (var bx in exec.Decode(bb))
                {
                    Console.WriteLine(JsonTool.ToJson(bx));
                }

                //foreach (var bytes in bb)
                //{
                // var hex = Convert.ToHexStringLower(bytes);
                //var txt = await exec.Decode(bytes);

                // line = $"\"{typ}\",\"0x{hex}\",\"{txt}\"";
                // await file.WriteLineAsync(line);
                // Console.WriteLine(line);
                //}
            }
        }
    }
}