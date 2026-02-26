using System;
using System.Threading.Tasks;
using Generator.Extractors;
using Generator.Tools;
using Iced.Intel;
using Thawed;

namespace Crppy
{
    internal static class Program
    {
        private static readonly WinExtractor Win = new();

        private static async Task Main(string[] args)
        {
            var decoder = Decoders.GetDecoder();
            var reader = new ArrayReader([]);
            var byteArrays = FuzzerX.AddFuzzy([]);
            await foreach (var lines in Win.Decode(byteArrays))
            {
                foreach (var line in lines)
                {
                    if (line.Offset != 0) continue;
                    var bytes = Convert.FromHexString(line.Hex);
                    if (bytes.Length != 1) continue;
                    if (line.Dis.Contains("???")) continue;
                    var parts = line.Dis.Split("  ", 2);
                    var op = parts[0].Trim();
                    var ag = parts[1].Trim();
                    var bin = bytes.Format('b');
                    var oct = bytes.Format('o');
                    var hex = bytes.Format('h');
                    reader.Reset(bytes);
                    var ins = decoder.Decode(reader, false);
                    var dbg = $" \t=>\t {ins}";
                    Console.WriteLine($" {bin} | {oct} | {hex} | {op,-5} | {ag} {dbg}");
                }
            }
        }
    }
}