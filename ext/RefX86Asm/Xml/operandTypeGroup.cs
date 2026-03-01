using System;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public enum operandTypeGroup
    {
        gen,

        x87fpu,

        seg,

        systabp,

        ctrl,

        msr,

        xmm,

        mmx,

        debug,

        xcr
    }
}