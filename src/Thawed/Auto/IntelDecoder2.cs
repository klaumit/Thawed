using I = Thawed.Auto.Instruct;
using R = Thawed.Register;
using static Thawed.InstructH;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed.Auto
{
    /// <summary>
    /// Decoder for Intel
    /// </summary>
    internal sealed class IntelDecoder2 : IDecoder
    {
        public Instruction? Decode(IByteReader r, bool fail)
        {
            byte? b0 = 0;

            Instruction? i = null;

            switch (b0 = r.ReadByte())
            {
                default: i = null; break;
            }

            return fail ? throw new DecodeException(b0) : i;
        }
    }
}