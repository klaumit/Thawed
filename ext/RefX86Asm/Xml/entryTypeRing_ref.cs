using System;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public enum entryTypeRing_ref
    {
        cr4_tsd,

        cr4_pce,

        rflags_iopl
    }
}