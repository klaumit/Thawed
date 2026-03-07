using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Generator.Extractors;
using Generator.Tools;
using WE = Generator.Extractors.WinExtractor;
using IE = Generator.Extractors.IcedExtractor;
using NE = Generator.Extractors.NasmExtractor;
using GE = Generator.Extractors.GnuExtractor;
using Sd = System.Collections.Generic.SortedDictionary<string, 
    System.Collections.Generic.IDictionary<string, 
        System.Collections.Generic.ISet<string>>>;
using static Generator.Tools.FileTool;
using static Generator.Tools.ArgTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator.API;
using Generator.Extractors;
using Generator.Tools;
using Iced.Intel;
using static Generator.Tools.JsonTool;
using CF = Iced.Intel.CpuidFeature;
using SD = System.Collections.Generic.SortedDictionary<string, 
    System.Collections.Generic.IDictionary<Iced.Intel.Code, Experimenter.Core.Example>>;

namespace Experimenter.Core
{
    internal static class KodDump
    {
        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } oD)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            var args = ParseDict(o.Misc);
            var count = args.As<int?>("count") ?? 270;
            var rnd = new Random();

            string jf = Path.Combine(oD, "samples.json");
            var dict = FromFile<SD>(jf) ?? new();

            var extractor = new WinExtractor();
            var arrays = CreateRandoms(count, rnd);
            int[] i = [0];
            await foreach (var d in extractor.Decode(arrays))
            {
                Handle(d, dict, i);
            }
            ToFile(jf, dict, format: true);

            Console.WriteLine("Done.");
        }

        private static void Handle(Decoded[] d, SD dict, int[] i)
        {
            var item = d.FirstOrDefault(x => x is { O: 0, L: >= 0 });
            if (item == null)
                return;
            var hex = item.I;
            var data = Convert.FromHexString(hex);
            Console.WriteLine($" #{++i[0]:D3} | {hex} ");
            var text = item.D.Split(' ', 2);
            var op = text[0].TrimOrNull();
            if (IsBad(op))
                return;
            var ag = text.Length == 2 ? text[1].TrimOrNull() : null;
            var got = item.H;
            var decoder = CreateDecoder(data);
            var iN = decoder.Decode();
            if (iN.CodeSize != CodeSize.Code16 || iN.Encoding != EncodingKind.Legacy)
                throw new InvalidOperationException($"{iN} ?!");
            if (iN.IsInvalid)
                return;
            var key1 = iN.Mnemonic.ToString();
            if (!dict.TryGetValue(key1, out var sub))
                dict[key1] = sub = new SortedDictionary<Code, Example>();
            var key2 = iN.Code;
            if (sub.TryGetValue(key2, out _))
                return;
            var iT = iN.ToString();
            Console.WriteLine($"    --> {iT} ");
            var feat = string.Join("|", GetFeatures(iN)).TrimOrNull();
            var pref = string.Join("|", GetPrefixes(iN)).TrimOrNull();
            sub[key2] = new Example { C = feat, H = got, P = pref, M = op, A = ag };
            Console.WriteLine();
        }

        private static IEnumerable<byte[]> CreateRandoms(int count, Random rnd)
        {
            for (var i = 0; i < count; i++)
            {
                var num = rnd.NextInt64();
                var hex = $"{num:X16}";
                var data = Convert.FromHexString(hex);
                yield return data;
            }
        }

        private static Decoder CreateDecoder(byte[] data)
        {
            const ulong ip = 0;
            const DecoderOptions opt = DecoderOptions.NoInvalidCheck;
            return Decoder.Create(16, data, ip, opt);
        }

        private static List<string> GetFeatures(Instruction i)
        {
            var pre = new List<string>();
            foreach (var fet in i.CpuidFeatures)
            {
                var txt = fet switch
                {
                    CF.INTEL8086 or CF.INTEL8086_ONLY => "i8086",
                    CF.INTEL186 => "i186",
                    CF.INTEL286 => "i286",
                    CF.INTEL386 => "i386",
                    CF.INTEL486 => "i486",
                    CF.CMOV => "cmov",
                    CF.FPU => "fpu",
                    CF.MMX => "mmx",
                    CF.MSR => "msr",
                    CF.SSE => "sse",
                    CF.SSE2 => "sse2",
                    CF.SYSCALL => "syscall",
                    _ => throw new ArgumentOutOfRangeException($"{fet} ?!")
                };
                pre.Add(txt);
            }
            return pre;
        }

        private static List<string> GetPrefixes(Instruction i)
        {
            var pre = new List<string>();
            if (i.HasRepPrefix)
                pre.Add(nameof(Assembler.rep));
            if (i.HasRepePrefix)
                pre.Add(nameof(Assembler.repe));
            if (i.HasRepnePrefix)
                pre.Add(nameof(Assembler.repne));
            if (i.HasLockPrefix)
                pre.Add(nameof(Assembler.@lock));
            return pre;
        }

        private static bool IsBad(string? txt)
            => txt is null or "???" or "CS:" or "DS:" or "ES:" or "SS:";
    }
}