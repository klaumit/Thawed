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
        internal static FarArg far(R r)
        {
            return new FarArg(r);
        }
    }
}