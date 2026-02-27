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

        internal static BytePtrArg byte_ptr(Arg a) => new(a);

        internal static WordPtrArg word_ptr(Arg a) => new(a);

        internal static DwordPtrArg dword_ptr(Arg a) => new(a);

        public static Arg[] MaskRegs(byte? b0, byte? b1)
        {
            var w = b0 & 0b0000000_1;
            var r = b1;
            switch (w, r)
            {
                case (0b0, 0b11000000): return [R.al, R.al];
                case (0b0, 0b11011011): return [R.bl, R.bl];
                case (0b0, 0b11001001): return [R.cl, R.cl];
                case (0b0, 0b11010010): return [R.dl, R.dl];
                case (0b1, 0b11000000): return [R.ah, R.ah];
                case (0b1, 0b11011011): return [R.bh, R.bh];
                case (0b1, 0b11001001): return [R.ch, R.ch];
                case (0b1, 0b11010010): return [R.dh, R.dh];
                default: return null!;
            }
        }

        public static Arg GetSegmentRegister(byte? b)
        {
            var end = b & 0b000000_11;
            switch (end)
            {
                case 0b00: return R.es;
                case 0b01: return R.cs;
                case 0b10: return R.ss;
                case 0b11: return R.ds;
                default: return null!;
            }
        }

        public static Arg MaskReg(byte? b, bool is16Bit = true, bool atEnd = true)
        {
            var end = atEnd ? b & 0b_00_000_111 : (b & 0b_00_111_000) >> 3;
            return is16Bit switch
            {
                /* (w = 1) */
                true => end switch
                {
                    0b000 => R.ax, 0b001 => R.cx, 0b010 => R.dx, 0b011 => R.bx,
                    0b100 => R.sp, 0b101 => R.bp, 0b110 => R.si, 0b111 => R.di,
                    _ => null!
                },
                /* (w = 0) */
                false => end switch
                {
                    0b000 => R.al, 0b001 => R.cl, 0b010 => R.dl, 0b011 => R.bl,
                    0b100 => R.ah, 0b101 => R.ch, 0b110 => R.dh, 0b111 => R.bh,
                    _ => null!
                }
            };
        }
    }
}