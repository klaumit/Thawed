using System;
using Thawed.Auto;
using I = Thawed.Auto.Instruct;

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
                0x37 => I.Aaa(),
                0x3F => I.Aas(),
                0x98 => I.Cbw(),
                0xF8 => I.Clc(),
                0xFC => I.Cld(),
                0xFA => I.Cli(),
                0xF5 => I.Cmc(),
                0xA6 => I.Cmpsb(),
                0xA7 => I.Cmpsw(),
                0x2E => I.Cs(),
                0x99 => I.Cwd(),
                0x27 => I.Daa(),
                0x2F => I.Das(),
                0x3E => I.Ds(),
                0x26 => I.Es(),
                0xF4 => I.Hlt(),
                0xEC => I.In(),
                0xED => I.In(),
                0x6C => I.Insb(),
                0x6D => I.Insw(),
                0xCC => I.Int(),
                0xCE => I.Into(),
                0xCF => I.Iret(),
                0x9F => I.Lahf(),
                0xC9 => I.Leave(),
                0xF0 => I.Lock(),
                0xAC => I.Lodsb(),
                0xAD => I.Lodsw(),
                0xA4 => I.Movsb(),
                0xA5 => I.Movsw(),
                0x90 => I.Nop(),
                0xEE => I.Out(),
                0xEF => I.Out(),
                0x6E => I.Outsb(),
                0x6F => I.Outsw(),
                0x61 => I.Popa(),
                0x9D => I.Popf(),
                0x60 => I.Pusha(),
                0x9C => I.Pushf(),
                0xC3 => I.Ret(),
                0xCB => I.Retf(),
                0x9E => I.Sahf(),
                0xAE => I.Scasb(),
                0xAF => I.Scasw(),
                0x36 => I.Ss(),
                0xF9 => I.Stc(),
                0xFD => I.Std(),
                0xFB => I.Sti(),
                0xAA => I.Stosb(),
                0xAB => I.Stosw(),
                0x9B => I.Wait(),
                0xD7 => I.Xlat(),
                _ => null
            };
            
            return fail ? throw new DecodeException(b0) : i;
        }
    }
}
