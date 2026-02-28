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
    internal sealed class IntelDecoder : IDecoder
    {
        public Instruction? Decode(IByteReader r, bool fail)
        {
            byte? b0 = 0;
            byte? b1 = 0;
            byte? b2 = 0;
            byte? b3 = 0;
            Instruction? i = null;

            switch (b0 = r.ReadByte())
            {
                // Prefixes
                case 0b00101110: i = I.Cs(); break;
                case 0b00111110: i = I.Ds(); break;
                case 0b00100110: i = I.Es(); break;
                case 0b00110110: i = I.Ss(); break;
                case 0b11110000: i = I.Lock(); break;
                case 0b11110011: i = I.Repe(); break;
                case 0b11110010: i = I.Repne(); break;
                // No arguments
                case 0b11111000: i = I.Clc(); break;
                case 0b11110101: i = I.Cmc(); break;
                case 0b11111001: i = I.Stc(); break;
                case 0b11111100: i = I.Cld(); break;
                case 0b11111101: i = I.Std(); break;
                case 0b11111010: i = I.Cli(); break;
                case 0b11111011: i = I.Sti(); break;
                case 0b11110100: i = I.Hlt(); break;
                case 0b10011011: i = I.Wait(); break;
                case 0b10010000: i = I.Nop(); break;
                case 0b11000011: i = I.Ret(); break;
                case 0b11001011: i = I.Retf(); break;
                case 0b01100000: i = I.Pusha(); break;
                case 0b10011100: i = I.Pushf(); break;
                case 0b01100001: i = I.Popa(); break;
                case 0b10011101: i = I.Popf(); break;
                case 0b10011110: i = I.Sahf(); break;
                case 0b10011111: i = I.Lahf(); break;
                case 0b11010111: i = I.Xlat(); break;
                case 0b11001111: i = I.Iret(); break;
                case 0b11001110: i = I.Into(); break;
                case 0b11001100: i = I.Int3(); break;
                case 0b10011000: i = I.Cbw(); break;
                case 0b10011001: i = I.Cwd(); break;
                case 0b00110111: i = I.Aaa(); break;
                case 0b00100111: i = I.Daa(); break;
                case 0b00111111: i = I.Aas(); break;
                case 0b00101111: i = I.Das(); break;
                case 0b11001001: i = I.Leave(); break;
                case 0b01101100: i = I.Insb(); break;
                case 0b01101101: i = I.Insw(); break;
                case 0b01101110: i = I.Outsb(); break;
                case 0b01101111: i = I.Outsw(); break;
                case 0b10101100: i = I.Lodsb(); break;
                case 0b10101101: i = I.Lodsw(); break;
                case 0b10101010: i = I.Stosb(); break;
                case 0b10101011: i = I.Stosw(); break;
                case 0b10101110: i = I.Scasb(); break;
                case 0b10101111: i = I.Scasw(); break;
                case 0b10100110: i = I.Cmpsb(); break;
                case 0b10100111: i = I.Cmpsw(); break;
                case 0b10100100: i = I.Movsb(); break;
                case 0b10100101: i = I.Movsw(); break;
                // One argument
                case 0b11010100: i = I.Aam(b1 = r.ReadByte()); break;
                case 0b11010101: i = I.Aad(b1 = r.ReadByte()); break;
                case 0b11001101: i = I.Int(b1 = r.ReadByte()); break;
                case 0b01110100: i = I.Jz(b1 = r.ReadByte()); break;
                case 0b01111100: i = I.Jl(b1 = r.ReadByte()); break;
                case 0b01111110: i = I.Jle(b1 = r.ReadByte()); break;
                case 0b01110010: i = I.Jb(b1 = r.ReadByte()); break;
                case 0b01110110: i = I.Jbe(b1 = r.ReadByte()); break;
                case 0b01111010: i = I.Jpe(b1 = r.ReadByte()); break;
                case 0b01110000: i = I.Jo(b1 = r.ReadByte()); break;
                case 0b01111000: i = I.Js(b1 = r.ReadByte()); break;
                case 0b01110101: i = I.Jnz(b1 = r.ReadByte()); break;
                case 0b01111101: i = I.Jge(b1 = r.ReadByte()); break;
                case 0b01111111: i = I.Jg(b1 = r.ReadByte()); break;
                case 0b01110011: i = I.Jnb(b1 = r.ReadByte()); break;
                case 0b01110111: i = I.Ja(b1 = r.ReadByte()); break;
                case 0b01111011: i = I.Jpo(b1 = r.ReadByte()); break;
                case 0b01110001: i = I.Jno(b1 = r.ReadByte()); break;
                case 0b01111001: i = I.Jns(b1 = r.ReadByte()); break;
                case 0b11100011: i = I.Jcxz(b1 = r.ReadByte()); break;
                case 0b11100010: i = I.Loop(b1 = r.ReadByte()); break;
                case 0b11100001: i = I.Loopz(b1 = r.ReadByte()); break;
                case 0b11100000: i = I.Loopnz(b1 = r.ReadByte()); break;
                case 0b11101011: i = I.Jmp(b1 = r.ReadByte()); break;
                case 0b00010100: i = I.AdcAx(b1 = r.ReadByte()); break;
                case 0b00100100: i = I.AndAx(b1 = r.ReadByte()); break;
                case 0b10101000: i = I.TestAx(b1 = r.ReadByte()); break;
                case 0b00001100: i = I.OrAx(b1 = r.ReadByte()); break;
                case 0b00110100: i = I.XorAx(b1 = r.ReadByte()); break;
                case 0b00101100: i = I.SubAx(b1 = r.ReadByte()); break;
                case 0b00011100: i = I.SbbAx(b1 = r.ReadByte()); break;
                case 0b00111100: i = I.CmpAx(b1 = r.ReadByte()); break;
                case 0b00000100: i = I.AddAx(b1 = r.ReadByte()); break;
                // Two arguments
                case 0b11000010: i = I.Ret(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b11001010: i = I.Retf(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b11101000: i = I.Call(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b11101001: i = I.Jmp(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b00010101: i = I.AdcAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b00100101: i = I.AndAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b10101001: i = I.TestAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b00001101: i = I.OrAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b00110101: i = I.XorAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b00101101: i = I.SubAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b00011101: i = I.SbbAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b00111101: i = I.CmpAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                case 0b00000101: i = I.AddAx(b1 = r.ReadByte(), b2 = r.ReadByte()); break;
                // Three arguments
                case 0b11001000: i = I.Enter(b1 = r.ReadByte(), b2 = r.ReadByte(), b3 = r.ReadByte()); break;
            }
            
            if (i != null) 
                return i;
            
            int? i0 = null;
            switch (i0 = b0 & 0b11111_000)
            {
                // One register
                case 0b01000_000: i = I.Inc(MaskReg(b0)); break;
                case 0b01011_000: i = I.Pop(MaskReg(b0)); break;
                case 0b01001_000: i = I.Dec(MaskReg(b0)); break;
                case 0b01010_000: i = I.Push(MaskReg(b0)); break;
                case 0b10010_000: i = I.Xchg(MaskReg(b0)); break;
            }
            
            if (i != null) 
                return i;

            switch (i0 = b0 & 0b111_00_111)
            {
                // Middle register
                case 0b000_00_111: i = I.PopSr(MaskSeg(b0)); break;
                case 0b000_00_110: i = I.PushSr(MaskSeg(b0)); break;
            }
            

            
            

            // TODO
            
                /*                
                // More?
                default:
                    if (i == null)
                        switch (i0 = b0 & 0b1111111_0)
                        {
                            case 0b00000000: i = I.Add(MaskRegs(b0, b1 = r.ReadByte())); break;
                            case 0b00001000: i = I.Or(MaskRegs(b0, b1 = r.ReadByte())); break;
                            case 0b00010000: i = I.Adc(MaskRegs(b0, b1 = r.ReadByte())); break;
                            case 0b00011000: i = I.Sbb(MaskRegs(b0, b1 = r.ReadByte())); break;
                            case 0b00100000: i = I.And(MaskRegs(b0, b1 = r.ReadByte())); break;
                            case 0b00110000: i = I.Xor(MaskRegs(b0, b1 = r.ReadByte())); break;
                            case 0b00111000: i = I.Cmp(MaskRegs(b0, b1 = r.ReadByte())); break;
                        }
                    if (i == null)
                        Console.WriteLine($" {i0:b8} ");
                    break;
                    */

            return fail ? throw new DecodeException(b0, b1, b2, b3) : i;
        }
    }
}