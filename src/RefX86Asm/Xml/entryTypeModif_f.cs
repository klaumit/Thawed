using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class entryTypeModif_f
    {
        private yes_no condField;

        private bool condFieldSpecified;

        private string valueField;

        [XmlAttribute]
        public yes_no cond
        {
            get { return this.condField; }
            set { this.condField = value; }
        }

        [XmlIgnore]
        public bool condSpecified
        {
            get { return this.condFieldSpecified; }
            set { this.condFieldSpecified = value; }
        }

        [XmlText]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }
}