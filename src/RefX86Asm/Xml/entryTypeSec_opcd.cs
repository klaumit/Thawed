using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class entryTypeSec_opcd
    {
        private yes_no escapeField;

        private bool escapeFieldSpecified;

        private byte[] valueField;

        [XmlAttribute]
        public yes_no escape
        {
            get { return this.escapeField; }
            set { this.escapeField = value; }
        }

        [XmlIgnore]
        public bool escapeSpecified
        {
            get { return this.escapeFieldSpecified; }
            set { this.escapeFieldSpecified = value; }
        }

        [XmlText(DataType = "hexBinary")]
        public byte[] Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }
}