using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public enum entryTypeInstr_ext
    {
        sse1,

        mmx,

        sse2,

        sse3,

        ssse3,

        vmx,

        smx,

        sse41,

        sse42,

        lzcnt,

        bmi1
    }
}