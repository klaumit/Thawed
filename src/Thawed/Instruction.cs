using Thawed.Auto;

// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract

namespace Thawed
{
    public sealed class Instruction
    {
        public Opcode Code { get; }

        public Instruction(Opcode code)
        {
            Code = code;
        }

        public override string ToString()
        {
            var txt = $"{Code.ToName()}";
            return txt;
        }
    }
}