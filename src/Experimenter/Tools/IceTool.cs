using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Generator.Tools
{
    public static class IceTool
    {
        internal static Instruction? Parse16(byte[] data)
        {
            var decoder = CreateDecoder(data);
            var iN = decoder.Decode();
            if (iN.CodeSize != CodeSize.Code16)
                throw new InvalidOperationException($"{iN} ?!");
            if (iN.IsInvalid)
                return null;
            return iN;
        }

        private static Decoder CreateDecoder(byte[] data)
        {
            const ulong ip = 0;
            const DecoderOptions opt = DecoderOptions.NoInvalidCheck |
                                       DecoderOptions.NoPause;
            return Decoder.Create(16, data, ip, opt);
        }

        internal static List<string> GetFeatures(Instruction? i)
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
                    _ => $"{fet}"
                    // _ => throw new ArgumentOutOfRangeException($"{fet} ?!")
                };
                pre.Add(txt);
            }
            return pre;
        }

        internal static List<string> GetPrefixes(Instruction? j)
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
    }
}