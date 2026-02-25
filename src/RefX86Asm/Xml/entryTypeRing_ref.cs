using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
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