using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class entryTypeDef_f
    {
        private string condField;

        private string valueField;

        [XmlAttribute]
        public string cond
        {
            get { return this.condField; }
            set { this.condField = value; }
        }

        [XmlText]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }
}