using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator.Extractors;
using Generator.Tools;
using Iced.Intel;
using Thawed;
using WE = Generator.Extractors.WinExtractor;

namespace Crppy
{
    internal static class Program
    {
        private static readonly WE Win = new();
        private static readonly JsonExtractor<WE> WinC = new();

        private static async Task Main2(string[] args)
        {
            var dict = new SortedDictionary<string, byte[]>();
            Fuzzer.DoAll(a =>
            {
                Action<Assembler> b1 = x => a(x.@lock);
                Action<Assembler> b2 = x => a(x.repe);
                Action<Assembler> b3 = x => a(x.repne);
                foreach (var aa in new[] { b1, b2, b3 })
                {
                    if (FuzzerX.Assemble(aa) is not { } bits)
                        return;
                    dict[Convert.ToHexString(bits)] = bits;
                }
            });
            await Display(dict.Values.ToArray());
        }

        private static async Task Main(string[] args)
        {
            var byteArrays = FuzzerX.GetAllCandidates(false);
            await Display(byteArrays);
        }

        private static async Task Display(IEnumerable<byte[]> byteArrays)
        {
            var decoder = Decoders.GetDecoder();
            var reader = new ArrayReader([]);
            await foreach (var lines in WinC.Decode(byteArrays))
            {
                foreach (var line in lines)
                {
                    if (line.O != 0) continue;
                    var bytes = Convert.FromHexString(line.H);
                    // if (bytes.Length >= 3) continue;
                    if (line.D.Contains("???")) continue;
                    var parts = line.D.Split(" ", 2);
                    var op = parts[0].Trim();
                    var ag = parts.Length == 2 ? parts[1].Trim() : "";
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