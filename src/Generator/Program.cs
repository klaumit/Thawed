using System;
using System.Threading.Tasks;
using Extracting.Extractors;
using Extracting.API;
using Generator.Tools;

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
                for (var i = 0; i < 2; i++)
                {
                    var bytes = BitConverter.GetBytes((short)i);
                    // var hex = Convert.ToHexStringLower(bytes);
                    var txt = await exec.Decode(bytes);

                    // line = $"\"{typ}\",\"0x{hex}\",\"{txt}\"";
                    // await file.WriteLineAsync(line);
                    // Console.WriteLine(line);

                    Console.WriteLine(JsonTool.ToJson(txt));
                }
            }
        }
    }
}