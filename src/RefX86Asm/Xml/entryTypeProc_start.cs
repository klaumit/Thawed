using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class entryTypeProc_start
    {
        private yes_no postField;

        private bool postFieldSpecified;

        private yes_no lat_stepField;

        private bool lat_stepFieldSpecified;

        private string valueField;

        [XmlAttribute]
        public yes_no post
        {
            get { return this.postField; }
            set { this.postField = value; }
        }

        [XmlIgnore]
        public bool postSpecified
        {
            get { return this.postFieldSpecified; }
            set { this.postFieldSpecified = value; }
        }

        [XmlAttribute]
        public yes_no lat_step
        {
            get { return this.lat_stepField; }
            set { this.lat_stepField = value; }
        }

        [XmlIgnore]
        public bool lat_stepSpecified
        {
            get { return this.lat_stepFieldSpecified; }
            set { this.lat_stepFieldSpecified = value; }
        }

        [XmlText(DataType = "integer")]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }
}