using System;
using Thawed.Args;
using Thawed.Auto;
using System;
using Thawed.Auto;
using I = Thawed.Auto.Instruct;
using R = Thawed.Register;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed
{
    internal static class InstructH
    {
        internal static FarArg far(Arg a)
        {
            return new FarArg(a);
        }
        
        internal static Arg d(Arg a)
        {
            return null;
        }

        internal static Arg br(Arg a)
        {
            return null;
        }

        internal static Arg br_plus(Arg a, Arg b)
        {
            return null;
        }

        internal static Arg byte_ptr(Arg a)
        {
            return null;
        }

        internal static Arg word_ptr(Arg a)
        {
            return null;
        }
        
        internal static Arg dword_ptr(Arg a)
        {
            return null;
        }
    }
}