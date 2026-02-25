using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
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