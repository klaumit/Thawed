using System.Linq;
using Thawed.Args;
using Thawed.Auto;

// ReSharper disable NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract

namespace Thawed
{
    public sealed class Instruction
    {
        public Opcode Code { get; }
        public Arg[] Args { get; }

        public Instruction(Opcode code, params Arg[] args)
        {
            Code = code;
            Args = args;
        }

        public override string ToString()
        {
            var argT = string.Join(",", (Args ?? []).Select(a => a?.ToString()));
            var txt = $"{Code.ToName()} {argT}".Trim();
            if (Args is { Length: 1 } && txt.EndsWith(":")) txt = txt.TrimEnd(':');
            return txt;
        }
    }
}