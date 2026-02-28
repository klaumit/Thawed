using System;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly JsonExtractor WinC = new(Win);

        private static async Task Main(string[] args)
        // private static void Main(string[] args)
        {
            var decoder = Decoders.GetDecoder();
            var reader = new ArrayReader([]);
            var byteArrays = FuzzerX.GetAllCandidates();
            await foreach (var lines in WinC.Decode(byteArrays))
            // foreach (var lines in WinC.All)
            {
                foreach (var line in lines)
                {
                    if (line.O != 0) continue;
                    var bytes = Convert.FromHexString(line.H);
                    if (line.D.Contains("???")) continue;
                    var parts = line.D.Split("  ", 2);
                    var op = parts[0].Trim();
                    var ag = parts[1].Trim();
                    var bin = bytes.Format('b');
                    var oct = bytes.Format('o');
                    var hex = bytes.Format('h');
                    reader.Reset(bytes);
                    var ins = decoder.Decode(reader, false);
                    var iPt = $"{ins}".Split(" ", 2);
                    var pp = iPt[0];
                    var pg = iPt.Length == 2 ? iPt[1] : "";
                    var sx = $"{op,-5} | {ag}";
                    var tx = $"{pp,-5} | {pg}";
                    if (sx.Equals(tx)) continue;
                    var dbg = $" \t=> {tx}";
                    Console.WriteLine($" {bin} | {oct} | {hex} | {sx} {dbg}");
                }
            }
            WinC.Dispose();
        }
    }
}