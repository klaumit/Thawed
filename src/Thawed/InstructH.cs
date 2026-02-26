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

        public static Arg MaskReg(byte? b)
        {
            var end = b & 0b00000_111;
            switch (end)
            {
                case 0b000: return R.ax;
                case 0b001: return R.cx;
                case 0b010: return R.dx;
                case 0b011: return R.bx;
                case 0b100: return R.sp;
                case 0b101: return R.bp;
                case 0b110: return R.si;
                case 0b111: return R.di;
                default: return null!;
            }
        }
    }
}