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

        internal static BracketP1Arg br_plus(Arg a, Arg b) => new(a, b);

        internal static BracketP2Arg br_plus(Arg a, Arg b, Arg c) => new(a, b, c);

        internal static BytePtrArg byte_ptr(Arg a) => new(a);

        internal static WordPtrArg word_ptr(Arg a) => new(a);

        internal static DwordPtrArg dword_ptr(Arg a) => new(a);
        
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

        private static R DecodeReg(OpWidth w, int b)
            => w switch
            {
                OpWidth.Bits8 => DecodeReg8(b), OpWidth.Bits16 => DecodeReg16(b),
                _ => default
            };

        private static Arg? DecodeEffNo(int b) 
            => b switch
            {
                0b000 => br_plus(R.bx, R.si), 0b001 => br_plus(R.bx, R.di),
                0b010 => br_plus(R.bp, R.si), 0b011 => br_plus(R.bp, R.di),
                0b100 => br(R.si), 0b101 => br(R.di), 0b110 => OpWidth.None,
                0b111 => br(R.bx), _ => null
            };

        private static Arg? DecodeEff8(int b) 
            => b switch
            {
                0b000 => br_plus(R.bx, R.si, OpWidth.Bits8), 0b001 => br_plus(R.bx, R.di, OpWidth.Bits8),
                0b010 => br_plus(R.bp, R.si, OpWidth.Bits8), 0b011 => br_plus(R.bp, R.di, OpWidth.Bits8),
                0b100 => br_plus(R.si, OpWidth.Bits8), 0b101 => br_plus(R.di, OpWidth.Bits8),
                0b110 => br_plus(R.bp, OpWidth.Bits8), 0b111 => br_plus(R.bx, OpWidth.Bits8), _ => null
            };

        private static Arg? DecodeEff16(int b) 
            => b switch
            {
                0b000 => br_plus(R.bx, R.si, OpWidth.Bits16), 0b001 => br_plus(R.bx, R.di, OpWidth.Bits16),
                0b010 => br_plus(R.bp, R.si, OpWidth.Bits16), 0b011 => br_plus(R.bp, R.di, OpWidth.Bits16),
                0b100 => br_plus(R.si, OpWidth.Bits16), 0b101 => br_plus(R.di, OpWidth.Bits16),
                0b110 => br_plus(R.bp, OpWidth.Bits16), 0b111 => br_plus(R.bx, OpWidth.Bits16),
                _ => null
            };

        private static Arg? DecodeEff(OpMod m, int b)
            => m switch
            {
                OpMod.NoDisplacement => DecodeEffNo(b), OpMod.Bit8Displace => DecodeEff8(b), 
                OpMod.Bit16Displace => DecodeEff16(b), _ => null
            };

        private static Arg? DecodeRm(OpMod m, OpWidth w, int b)
            => m switch
            {
                OpMod.NoDisplacement or OpMod.Bit8Displace or OpMod.Bit16Displace => DecodeEff(m, b),
                OpMod.RegisterDirect => DecodeReg(w, b), _ => null
            };

        public static Arg[]? GetArgs(int d, int w, (OpMod mod, int reg, int rm)? p, params byte?[] data)
        {
            var (xD, xW) = ((OpDirection)d, (OpWidth)w);
            if (p is var (mod, reg, rm))
            {
                var dReg = DecodeReg(xW, reg);
                var dRm = DecodeRm(mod, xW, rm)!;
                if (data is { Length: >= 1 })
                    dRm = FixData(dRm, data);
                switch (xD)
                {
                    case OpDirection.RegIsSrc: return [dRm, dReg];
                    case OpDirection.RegIsDst: return [dReg, dRm];
                    default: throw new ArgumentOutOfRangeException();
                }
            }
            return null;
        }

        private static Arg? FixData(Arg arg, byte?[] data)
        {
            if (arg is BracketP1Arg { Val2: DispArg d2 } b1
                && ToNumber(data, d2.Val) is { } n2)
            {
                b1.Val2 = n2;
            }
            else if (arg is BracketP2Arg { Val3: DispArg d3 } b2
                     && ToNumber(data, d3.Val) is { } n3)
            {
                b2.Val3 = n3;
            }
            return arg;
        }

        private static Arg? ToNumber(byte?[] data, OpWidth w)
        {
            Arg? res = null;
            switch (data.Length)
            {
                case 1: res = data[0]; break;
                default: throw new InvalidOperationException($"{w} | {data.ToHexString()}");
            }
            return res;
        }
    }

    public enum OpWidth
    {
        Bits8 = 0,
        Bits16 = 1,
        None
    }

    public enum OpMod
    {
        NoDisplacement = 0b00,
        Bit8Displace = 0b01,
        Bit16Displace = 0b10,
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