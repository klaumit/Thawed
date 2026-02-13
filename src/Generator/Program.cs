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
            IExtractor[] execs = [new IcedExtractor(), new GnuExtractor(), new NasmExtractor(), new WinExtractor()];
            foreach (var exec in execs)
            {
                var typ = exec.GetType().Name.Replace(nameof(IExtractor).Trim('I'), "");
                // await using var file = File.CreateText($"{typ}.csv");
                // file.AutoFlush = true;
                // var line = $"\"App\",\"Hex\",\"Parsed\"";
                // await file.WriteLineAsync(line);

                var bb = Go(0, 2, BitTool.AsShortB).ToArray();
                var bx = await exec.Decode(bb);
                
                //foreach (var bytes in bb)
                //{
                    // var hex = Convert.ToHexStringLower(bytes);
                    //var txt = await exec.Decode(bytes);

                    // line = $"\"{typ}\",\"0x{hex}\",\"{txt}\"";
                    // await file.WriteLineAsync(line);
                    // Console.WriteLine(line);

                Console.WriteLine(JsonTool.ToJson(bx));
                //}
            }
        }
    }
}