using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public enum entryTypeMode
    {
        e,

        p,

        s
    }
}