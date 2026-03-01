using System;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class syntaxTypeMnem
    {
        private yes_no sugField;

        private bool sugFieldSpecified;

        private string valueField;

        [XmlAttribute]
        public yes_no sug
        {
            get { return this.sugField; }
            set { this.sugField = value; }
        }

        [XmlIgnore]
        public bool sugSpecified
        {
            get { return this.sugFieldSpecified; }
            set { this.sugFieldSpecified = value; }
        }

        [XmlText]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }
}