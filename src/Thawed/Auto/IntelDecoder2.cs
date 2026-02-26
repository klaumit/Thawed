using System;
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
                // No arguments
                case 0b00100111: i = I.Daa(); break;
                case 0b00101111: i = I.Das(); break;
                case 0b00110111: i = I.Aaa(); break;
                case 0b00111111: i = I.Aas(); break;
                case 0b01100000: i = I.Pusha(); break;
                case 0b01100001: i = I.Popa(); break;
                case 0b01101100: i = I.Insb(); break;
                case 0b01101101: i = I.Insw(); break;
                case 0b01101110: i = I.Outsb(); break;
                case 0b01101111: i = I.Outsw(); break;
                case 0b10010000: i = I.Nop(); break;
                case 0b10011000: i = I.Cbw(); break;
                case 0b10011001: i = I.Cwd(); break;
                case 0b10011011: i = I.Wait(); break;
                case 0b10011100: i = I.Pushf(); break;
                case 0b10011101: i = I.Popf(); break;
                case 0b10011110: i = I.Sahf(); break;
                case 0b10011111: i = I.Lahf(); break;
                case 0b10100100: i = I.Movsb(); break;
                case 0b10100101: i = I.Movsw(); break;
                case 0b10100110: i = I.Cmpsb(); break;
                case 0b10100111: i = I.Cmpsw(); break;
                case 0b10101010: i = I.Stosb(); break;
                case 0b10101011: i = I.Stosw(); break;
                case 0b10101100: i = I.Lodsb(); break;
                case 0b10101101: i = I.Lodsw(); break;
                case 0b10101110: i = I.Scasb(); break;
                case 0b10101111: i = I.Scasw(); break;
                case 0b11000011: i = I.Ret(); break;
                case 0b11001001: i = I.Leave(); break;
                case 0b11001011: i = I.Retf(); break;
                case 0b11001100: i = I.Int3(); break;
                case 0b11001110: i = I.Into(); break;
                case 0b11001111: i = I.Iret(); break;
                case 0b11010111: i = I.Xlat(); break;
                case 0b11110100: i = I.Hlt(); break;
                case 0b11110101: i = I.Cmc(); break;
                case 0b11111000: i = I.Clc(); break;
                case 0b11111001: i = I.Stc(); break;
                case 0b11111010: i = I.Cli(); break;
                case 0b11111011: i = I.Sti(); break;
                case 0b11111100: i = I.Cld(); break;
                case 0b11111101: i = I.Std(); break;
                // Special one
                case 0b00011110: i = I.Push(R.ds); break;
                case 0b00011111: i = I.Pop(R.ds); break;
                case 0b01000011: i = I.Inc(R.bx); break;
                // More?
                default:
                    int? i0 = null;
                    switch (i0 = b0 & 0b11111_000)
                    {
                        case 0b01001000: i = I.Dec(MaskReg(b0)); break;
                        case 0b01010000: i = I.Push(MaskReg(b0)); break;
                        case 0b01011000: i = I.Pop(MaskReg(b0)); break;
                        default: Console.WriteLine($" {i0:b8} "); break;
                    }
                    break;
            }

            return fail ? throw new DecodeException(b0) : i;
        }
    }
}