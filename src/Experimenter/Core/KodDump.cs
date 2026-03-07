using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Experimenter.Models;
using Generator.Extractors;
using Generator.Tools;
using Generator.API;
using Iced.Intel;
using static Generator.Tools.FileTool;
using static Generator.Tools.ArgTool;
using static Generator.Tools.JsonTool;
using CF = Iced.Intel.CpuidFeature;
using ND = Experimenter.Models.Node;
using SD = System.Collections.Generic.SortedDictionary<string, 
    System.Collections.Generic.IDictionary<Iced.Intel.Code, Experimenter.Models.Example>>;

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
            var withNum = args.As<bool?>("num") ?? false;
            var rnd = new Random();

            var slf = Path.Combine(oD, "smpl_list.json");
            var stf = Path.Combine(oD, "smpl_tree.json");
            var dict = FromFile<SD>(slf) ?? new();
            var tree = FromFile<ND>(stf) ?? new();

            var extractor = new WinExtractor();
            var arrays = CreateRandoms(count, rnd);
            arrays = arrays.Concat(FuzzerX.GetAllCandidates(withNum));
            int[] i = [0];
            await foreach (var d in extractor.Decode(arrays))
            {
                if (Handle(d, dict, i))
                    GoFor(d, tree);
            }
            SortMe(tree);
            ToFile(stf, tree, format: true);
            ToFile(slf, dict, format: true);

            Console.WriteLine("Done.");
        }

        private static bool Handle(Decoded[] d, SD dict, int[] i)
        {
            var item = d.FirstOrDefault(x => x is { O: 0, L: >= 0 });
            if (item == null)
                return false;
            var hex = item.I;
            var data = Convert.FromHexString(hex);
            Console.WriteLine($" #{++i[0]:D5} | {hex} ");
            var text = item.D.Split(' ', 2);
            var op = text[0].TrimOrNull();
            if (IsBad(op))
                return false;
            var ag = text.Length == 2 ? text[1].TrimOrNull() : null;
            var got = item.H;
            var iN = Parse16(data);
            var key1 = iN?.Mnemonic.ToString() ?? "_";
            if (!dict.TryGetValue(key1, out var sub))
                dict[key1] = sub = new SortedDictionary<Code, Example>();
            var key2 = iN?.Code ?? default;
            if (sub.TryGetValue(key2, out _))
                return false;
            var iT = iN.ToString();
            Console.WriteLine($"    --> {iT} ");
            sub[key2] = CreateEx(op, ag, got, iN);
            Console.WriteLine();
            return true;
        }

        private static Instruction? Parse16(byte[] data)
        {
            var decoder = CreateDecoder(data);
            var iN = decoder.Decode();
            if (iN.CodeSize != CodeSize.Code16 || iN.Encoding != EncodingKind.Legacy)
                throw new InvalidOperationException($"{iN} ?!");
            if (iN.IsInvalid)
                return null;
            return iN;
        }

        private static Example CreateEx(string? op, string? ag, string got, Instruction? iN)
        {
            var feat = string.Join("|", GetFeatures(iN)).TrimOrNull();
            var pref = string.Join("|", GetPrefixes(iN)).TrimOrNull();
            return new Example { C = feat, H = got, P = pref, M = op, A = ag };
        }

        private static void GoFor(Decoded[] d, ND tree)
        {
            var first = d.FirstOrDefault(x => x is { O: 0, L: >= 0 });
            if (first == null)
                return;
            var gotTxt = first.D.Split(' ', 2);
            var gotOp = gotTxt[0].TrimOrNull();
            var gotAg = gotTxt[1].TrimOrNull();
            if (IsBad(gotOp))
                return;
            var got = first.H;
            var gotHex = Convert.FromHexString(got);
            var gotBin = gotHex.Format('b', "");
            var node = FindNode(tree, gotBin, 8);
            var iN = Parse16(Convert.FromHexString(first.I));
            node.D = CreateEx(gotOp, gotAg, got, iN);
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
            const DecoderOptions opt = DecoderOptions.NoInvalidCheck |
                                       DecoderOptions.NoPause;
            return Decoder.Create(16, data, ip, opt);
        }

        private static List<string> GetFeatures(Instruction? i)
        {
            var pre = new List<string>();
            foreach (var fet in i?.CpuidFeatures ?? [])
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

        private static List<string> GetPrefixes(Instruction? j)
        {
            var pre = new List<string>();
            if (j is { } i)
            {
                if (i.HasRepPrefix)
                    pre.Add(nameof(Assembler.rep));
                if (i.HasRepePrefix)
                    pre.Add(nameof(Assembler.repe));
                if (i.HasRepnePrefix)
                    pre.Add(nameof(Assembler.repne));
                if (i.HasLockPrefix)
                    pre.Add(nameof(Assembler.@lock));
            }
            return pre;
        }

        private static void SortMe(ND tree)
        {
            if (tree.S is not { Count: >= 1 } list)
                return;
            tree.S = list.OrderBy(l => l.H).ToList();
            foreach (var sub in list)
                SortMe(sub);
        }

        private static ND FindNode(ND tree, string hex, int len)
        {
            var current = tree;
            var parts = BitTool.SplitP(hex, len);
            foreach (var part in parts)
            {
                var list = current.S ??= [];
                if (list.FirstOrDefault(l => l.H == part) is var fo
                    && !string.IsNullOrWhiteSpace(fo?.H))
                {
                    current = fo;
                    continue;
                }
                list.Add(current = new ND { H = part });
            }
            return current;
        }

        private static bool IsBad(string? txt)
            => txt is null or "???" or "CS:" or "DS:" or "ES:" or "SS:";
    }
}