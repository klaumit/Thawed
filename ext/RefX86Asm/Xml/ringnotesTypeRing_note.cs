using System;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ringnotesTypeRing_note
    {
        private string idField;

        [XmlAttribute]
        public string id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }
}