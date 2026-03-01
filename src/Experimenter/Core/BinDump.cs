using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Generator.API;
using Generator.Extractors;
using Generator.Tools;
using Thawed;
using WE = Generator.Extractors.WinExtractor;
using static Generator.Tools.FileTool;

namespace Experimenter.Core
{
    internal static class BinDump
    {
        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } outDir)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            var byteArrays = FuzzerX.GetAllCandidates(false);

            // WE Win = new();
            var winC = new JsonExtractor<WE>(outDir);

            var path = Path.Combine(outDir, "dis_log.txt");
            await using var fileD = File.CreateText(path);
            await Display(fileD, byteArrays, winC);

            Console.WriteLine("Done.");
        }

        internal static async Task Display(TextWriter writer, IEnumerable<byte[]> byteArrays,
            IExtractor ex, Func<string, bool>? filter = null)
        {
            var decoder = Decoders.GetDecoder();
            var reader = new ArrayReader([]);
            await foreach (var lines in ex.Decode(byteArrays))
            {
                foreach (var line in lines)
                {
                    if (line.O != 0)
                        continue;
                    var bytes = Convert.FromHexString(line.H);
                    var ld = line.D;
                    if (IsBad(line.D))
                        continue;
                    var parts = ld.Split(" ", 2);
                    var op = parts[0].Trim();
                    var ag = parts.Length == 2 ? parts[1].Trim() : "";
                    var bin = bytes.Format('b');
                    var oct = bytes.Format('o');
                    var hex = bytes.Format('h');
                    reader.Reset(bytes);
                    var ins = decoder.Decode(reader, false);
                    var iPt = $"{ins}".Split(" ", 2);
                    var pp = iPt[0].Trim();
                    var pg = iPt.Length == 2 ? iPt[1].Trim() : "";
                    var sx = $"{op,-5} | {ag}";
                    var tx = $"{pp,-5} | {pg}";
                    if (sx.Equals(tx))
                        continue;
                    if (filter != null && !filter(hex))
                        continue;
                    var sl = $" {bin} | {oct} | {hex} | {sx} \t=> {tx}";
                    await writer.WriteLineAsync(sl);
                    await writer.FlushAsync();
                }
            }
            (ex as IDisposable)?.Dispose();
        }

        private static bool IsBad(string ld)
            => ld.Contains("???") || ld.Contains("(bad)") ||
               ld.Contains(".byte") || ld.Contains("db ");
    }
}