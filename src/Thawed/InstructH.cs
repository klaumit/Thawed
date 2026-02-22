using Thawed.Args;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed
{
    internal static class InstructH
    {
        internal static FarArg far(Arg a) => new(a);

        internal static Arg d(Arg a) => a;

        internal static Arg br(Arg a) => a;

        internal static Arg br_plus(Arg a, Arg b) => a;

        internal static Arg byte_ptr(Arg a) => a;

        internal static Arg word_ptr(Arg a) => a;

        internal static Arg dword_ptr(Arg a) => a;
    }
}