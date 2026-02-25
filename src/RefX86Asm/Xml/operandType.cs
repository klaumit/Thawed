using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    public class operandType
    {
        private string aField;

        private string tField;

        private string[] textField;

        private string nrField;

        private operandTypeGroup groupField;

        private bool groupFieldSpecified;

        private string typeField;

        private yes_no dependField;

        private bool dependFieldSpecified;

        private AddressType addressField;

        private bool addressFieldSpecified;

        private yes_no displayedField;

        private bool displayedFieldSpecified;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string a
        {
            get { return this.aField; }
            set { this.aField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string t
        {
            get { return this.tField; }
            set { this.tField = value; }
        }

        [XmlText]
        public string[] Text
        {
            get { return this.textField; }
            set { this.textField = value; }
        }

        [XmlAttribute]
        public string nr
        {
            get { return this.nrField; }
            set { this.nrField = value; }
        }

        [XmlAttribute]
        public operandTypeGroup group
        {
            get { return this.groupField; }
            set { this.groupField = value; }
        }

        [XmlIgnore]
        public bool groupSpecified
        {
            get { return this.groupFieldSpecified; }
            set { this.groupFieldSpecified = value; }
        }

        [XmlAttribute]
        public string type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        [XmlAttribute]
        public yes_no depend
        {
            get { return this.dependField; }
            set { this.dependField = value; }
        }

        [XmlIgnore]
        public bool dependSpecified
        {
            get { return this.dependFieldSpecified; }
            set { this.dependFieldSpecified = value; }
        }

        [XmlAttribute]
        public AddressType address
        {
            get { return this.addressField; }
            set { this.addressField = value; }
        }

        [XmlIgnore]
        public bool addressSpecified
        {
            get { return this.addressFieldSpecified; }
            set { this.addressFieldSpecified = value; }
        }

        [XmlAttribute]
        public yes_no displayed
        {
            get { return this.displayedField; }
            set { this.displayedField = value; }
        }

        [XmlIgnore]
        public bool displayedSpecified
        {
            get { return this.displayedFieldSpecified; }
            set { this.displayedFieldSpecified = value; }
        }
    }
}