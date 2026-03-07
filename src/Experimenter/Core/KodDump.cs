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
using NDC = Experimenter.Models.NodeC;
using NDS = Experimenter.Models.NodeD;
using IDC = System.Collections.Concurrent.ConcurrentDictionary<string,
    System.Collections.Concurrent.ConcurrentDictionary<Iced.Intel.Code, Experimenter.Models.Example>>;
using IDS = System.Collections.Generic.SortedDictionary<string, 
    System.Collections.Generic.SortedDictionary<Iced.Intel.Code, Experimenter.Models.Example>>;

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
            var withFuzz = args.As<bool?>("fuzz") ?? false;
            var withNum = args.As<bool?>("num") ?? false;
            var withCnt = args.As<bool?>("iter") ?? false;
            var ib = args.As<int?>("len") ?? 1;
            var rnd = new Random();

            var slf = Path.Combine(oD, "smpl_list.json");
            var stf = Path.Combine(oD, "smpl_tree.json");
            var dict = FromFile<IDC>(slf) ?? new();
            var tree = FromFile<NDC>(stf) ?? new();

            var arrays = rnd.IterRandom(count);
            if (withFuzz)
                arrays = arrays.Concat(FuzzerX.GetAllCandidates(withNum));
            if (withCnt)
                arrays = arrays.Concat(IterTool.IterArray(ib));
            int[] i = [0];

            const int pktSize = 1355;
            var maxCpus = Environment.ProcessorCount / 3;
            Console.WriteLine($"Starting with {maxCpus} CPUs and {pktSize} args per chunk...");

            var tasks = arrays.Chunk(pktSize).AsParallel()
                .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .WithMergeOptions(ParallelMergeOptions.NotBuffered)
                .WithDegreeOfParallelism(maxCpus)
                .Select((ba, id) => DecodeBinary(ba, id, dict, tree, i));

            var res = await Task.WhenAll(tasks);
            var sum = res.Sum();

            ToFile(stf, Prepare(tree), format: true);
            ToFile(slf, Prepare(dict), format: true);
            Console.WriteLine($"Done with {sum} results (in {res.Length} chunks of {pktSize} args)!");
        }

        private static async Task<int> DecodeBinary(byte[][] arrays, int id, IDC dict, NDC tree, int[] ix)
        {
            var tId = Environment.CurrentManagedThreadId;
            var tPre = (char)('A' + tId);
            if (tPre > 'Z') tPre = (char)('a' + (tPre - 'Z'));
            var argCnt = arrays.Length;
            Console.WriteLine($" * p{id:D2} t{tId:D2} '{tPre}' a{argCnt:D5} ");

            var i = 0;
            var ex = new WinExtractor { ArgCount = argCnt, ArgPrefix = tPre };
            await foreach (var d in ex.Decode(arrays))
            {
                i++;
                if (Handle(d, dict, ix))
                    GoFor(d, tree);
            }
            return i;
        }

        private static bool Handle(Decoded[] d, IDC dict, int[] i)
        {
            var item = d.FirstOrDefault(x => x is { O: 0, L: >= 0 });
            if (item == null)
                return false;
            var hex = item.I;
            var data = Convert.FromHexString(hex);
            Console.WriteLine($"    #{++i[0]:D5} | {hex} ");
            var text = item.D.Split(' ', 2);
            var op = text[0].TrimOrNull();
            if (IsBad(op))
                return false;
            var ag = text.Length == 2 ? text[1].TrimOrNull() : null;
            var got = item.H;
            var iN = Parse16(data);
            var key1 = iN?.Mnemonic.ToString() ?? "_";
            if (!dict.TryGetValue(key1, out var sub))
                dict[key1] = sub = new();
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
            if (iN.CodeSize != CodeSize.Code16)
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

        private static void GoFor(Decoded[] d, NDC tree)
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
                    _ => fet
                    // _ => throw new ArgumentOutOfRangeException($"{fet} ?!")
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

        private static IDS Prepare(IDC dict)
        {
            var res = new IDS();
            foreach (var (key, val) in dict)
                res[key] = PrepareSub(val);
            return res;
        }

        private static SortedDictionary<Code, Example> PrepareSub(IDictionary<Code, Example> dict)
        {
            var res = new SortedDictionary<Code, Example>();
            foreach (var (key, val) in dict)
                res[key] = val;
            return res;
        }

        private static NDS Prepare(NDC tree)
        {
            var res = new NDS { H = tree.H, D = tree.D };
            if (tree.S is { Count: >= 1 } list)
                res.S = [..list.OrderBy(l => l.H).Select(Prepare)];
            return res;
        }

        private static NDC FindNode(NDC tree, string hex, int len)
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
                list.Add(current = new NDC { H = part });
            }
            return current;
        }

        private static bool IsBad(string? txt)
            => txt is null or "???" or "CS:" or "DS:" or "ES:" or "SS:";
    }
}