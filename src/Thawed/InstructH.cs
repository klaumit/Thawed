using System;
using Thawed.Args;
using R = Thawed.Register;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed
{
    internal static class InstructH
    {
        internal static FarArg far(Arg a) => new(a);

        internal static Arg d(Arg a) => a;

        internal static BracketArg br(Arg a) => new(a);

        internal static BracketPlusArg br_plus(Arg a, Arg b) => new(a, b);

        internal static BracketP2Arg br_plus(Arg a, Arg b, Arg c) => new(a, b, c);

        internal static BytePtrArg byte_ptr(Arg a) => new(a);

        internal static WordPtrArg word_ptr(Arg a) => new(a);

        internal static DwordPtrArg dword_ptr(Arg a) => new(a);

        public static Arg GetEffectiveAddress(byte? b, int disp)
        {
            var end = b & 0b_00000_111;
            switch (end)
            {
                case 0b000: return br_plus(R.bx, R.si, disp);
                case 0b001: return br_plus(R.bx, R.di, disp);
                case 0b010: return br_plus(R.bp, R.si, disp);
                case 0b011: return br_plus(R.bp, R.di, disp);
                case 0b100: return br_plus(R.si, disp);
                case 0b101: return br_plus(R.di, disp);
                case 0b110: return br_plus(R.bp, disp);
                case 0b111: return br_plus(R.bx, disp);
                default: return null!;
            }
        }

        public static (OpMod mod, int reg, int rm)? DecodeModRM(byte? modRM)
        {
            if (modRM is not { } bModRM) return null;
            var mod = (bModRM >> 6) & 0b11;
            var reg = (bModRM >> 3) & 0b111;
            var rm = bModRM & 0b111;
            return ((OpMod)mod, reg, rm);
        }

        public static R MaskSeg(byte? b, bool atEnd = false)
        {
            var end = atEnd ? b & 0b_000_000_11 : (b & 0b_000_11_000) >> 3;
            switch (end)
            {
                case 0b00: return R.es;
                case 0b01: return R.cs;
                case 0b10: return R.ss;
                case 0b11: return R.ds;
                default: return default;
            }
        }

        public static R MaskReg(byte? b, bool is16Bit = true, bool atEnd = true)
        {
            var end = atEnd ? b & 0b_00_000_111 : (b & 0b_00_111_000) >> 3;
            return is16Bit switch
            {
                /* (w = 1) */
                true => end switch
                {
                    0b000 => R.ax, 0b001 => R.cx, 0b010 => R.dx, 0b011 => R.bx,
                    0b100 => R.sp, 0b101 => R.bp, 0b110 => R.si, 0b111 => R.di,
                    _ => default
                },
                /* (w = 0) */
                false => end switch
                {
                    0b000 => R.al, 0b001 => R.cl, 0b010 => R.dl, 0b011 => R.bl,
                    0b100 => R.ah, 0b101 => R.ch, 0b110 => R.dh, 0b111 => R.bh,
                    _ => default
                }
            };
        }

        private static R DecodeReg8(int b)
            => b switch
            {
                0b000 => R.al, 0b001 => R.cl, 0b010 => R.dl, 0b011 => R.bl,
                0b100 => R.ah, 0b101 => R.ch, 0b110 => R.dh, 0b111 => R.bh,
                _ => default
            };

        private static R DecodeReg16(int b)
            => b switch
            {
                0b000 => R.ax, 0b001 => R.cx, 0b010 => R.dx, 0b011 => R.bx,
                0b100 => R.sp, 0b101 => R.bp, 0b110 => R.si, 0b111 => R.di,
                _ => default
            };

        private static R DecodeReg(OpWidth s, int b)
            => s switch
            {
                OpWidth.Bits8 => DecodeReg8(b), OpWidth.Bits16 => DecodeReg16(b),
                _ => default
            };

        public static Arg[]? GetArgs(int d, int w, (OpMod mod, int reg, int rm)? p)
        {
            var (xD, xW) = ((OpDirection)d, (OpWidth)w);
            if (p is var (mod, reg, rm))
            {
                switch (mod)
                {
                    case OpMod.NoDisplacement:
                        break;
                    case OpMod.Bit8Displacement:
                        break;
                    case OpMod.Bit16Displacement:
                        break;
                    case OpMod.RegisterDirect:
                        var dReg = DecodeReg(xW, reg);
                        var dRm = DecodeReg(xW, rm);
                        switch (xD)
                        {
                            case OpDirection.RegIsSrc: return [dRm, dReg];
                            case OpDirection.RegIsDst: return [dReg, dRm];
                        }
                        break;
                }
            }
            return null;
        }
    }

    public enum OpWidth
    {
        Bits8 = 0,
        Bits16 = 1
    }

    public enum OpMod
    {
        NoDisplacement = 0b00,
        Bit8Displacement = 0b01,
        Bit16Displacement = 0b10,
        RegisterDirect = 0b11
    }

    public enum OpDirection
    {
        /// <summary>
        /// REG --> MOD R/M  
        /// </summary>
        RegIsSrc = 0,

        /// <summary>
        /// MOD R/M --> REG
        /// </summary>
        RegIsDst = 1
    }
}