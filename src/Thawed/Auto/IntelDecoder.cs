using System;
using Thawed.Auto;
using I = Thawed.InstructH;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed.Auto
{
    /// <summary>
    /// Decoder for Intel
    /// </summary>
    internal sealed class IntelDecoder : IDecoder
    {
        public Instruction? Decode(IByteReader r, bool fail)
        {
            byte b0 = 0;

            var i = (b0 = r.ReadOne()) switch
            {
                0xD4 => I.Aam(),
                0xD5 => I.Aad(),
                0x37 => I.Aaa(),
                0x61 => I.Popa(),
                _ => null
            };

            return fail ? throw new DecodeException(b0) : i;
        }
    }
}