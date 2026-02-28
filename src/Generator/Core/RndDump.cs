using System;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Generator.Extractors;
using System.Threading.Channels;
using static Generator.Tools.FileTool;
using static Generator.Tools.JsonTool;
using D = System.Collections.Concurrent.ConcurrentDictionary<string, string>;
using S = System.Collections.Generic.SortedDictionary<string, string>;

namespace Generator.Core
{
    internal static class RndDump
    {
        private const int Bytes = 8 * 4;
        private static readonly Random Rnd = new();

        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } outDir)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            var hexFile = Path.Combine(outDir, "hex_results.json");
            var binFile = Path.Combine(outDir, "bin_results.json");
            var dict = FromFile<D>(hexFile) ?? new D();

            var channel = Channel.CreateUnbounded<byte[]>();
            var writer = channel.Writer;
            var reader = channel.Reader;

            await Task.WhenAll(Produce(), Consume());
            Console.WriteLine("Done.");
            return;

            async Task Consume()
            {
                var extractor = new WinExtractor();

                await foreach (var buffer in reader.ReadAllAsync())
                {
                    var skip = IsInDict(dict, buffer);
                    if (skip)
                        continue;
                    try
                    {
                        await foreach (var d in extractor.Decode([buffer]))
                        {
                            foreach (var o in d)
                            {
                                if (o.O == 0)
                                {
                                    var txt = o.D.Trim();
                                    if (txt.Equals("???"))
                                        continue;
                                    if (txt.Length == 3 && txt.EndsWith(':'))
                                        continue;
                                    dict[o.H] = txt;
                                    Console.WriteLine($"    {o.H,-(7 * 2)} =>   {txt}");
                                    continue;
                                }
                                var rest = GetRandomArray(Convert.FromHexString(o.H));
                                _ = Task.Run(async () => await writer.WriteAsync(rest));
                            }
                        }
                        ToFile(hexFile, ToHexD(dict), format: true);
                        ToFile(binFile, ToBinD(dict), format: true);
                    }
                    catch (InvalidOperationException)
                    {
                        _ = Task.Run(async () => await writer.WriteAsync(buffer));
                    }
                }
            }

            async Task Produce()
            {
                foreach (var item in FuzzerX.GetAllCandidates())
                {
                    var array = GetRandomArray(item);
                    await writer.WriteAsync(array);
                }
                for (var i = 0; i < 200; i++)
                {
                    var array = GetRandomArray();
                    await writer.WriteAsync(array);

                    await Task.Delay(100);
                }
                writer.Complete();
            }
        }

        private static string ToBinStr(byte[] buf, string sep = " ")
        {
            return string.Join(sep, buf.Select(b => $"{b:B8}"));
        }

        private static byte[] GetRandomArray(byte[]? src = null)
        {
            var dst = new byte[Bytes];
            Rnd.NextBytes(dst);
            if (src != null)
                Array.Copy(src, 0, dst, 0, src.Length);
            return dst;
        }

        private static bool IsInDict(D dict, byte[] buffer)
        {
            var allHex = Convert.ToHexString(buffer);
            return dict.Keys.Any(k => allHex.StartsWith(k));
        }

        private static S ToHexD(D raw)
        {
            var dict = new S(raw);
            return dict;
        }

        private static S ToBinD(D raw)
        {
            var dict = new S();
            foreach (var pair in raw)
            {
                var buf = Convert.FromHexString(pair.Key);
                var bin = ToBinStr(buf);
                dict[bin] = pair.Value;
            }
            return dict;
        }
    }
}