using System;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public enum entryTypeAttr
    {
        serial,

        invd,

        acc,

        delaysint,

        undef,

        @null,

        nop,

        delaysint_cond
    }
}