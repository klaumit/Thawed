using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
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