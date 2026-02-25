using System;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    [XmlType(IncludeInSchema = false)]
    public enum ItemsChoiceType
    {
        dst,

        src
    }
}