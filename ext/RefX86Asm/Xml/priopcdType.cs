using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    public class priopcdType
    {
        private string proc_startField;

        private bool proc_startFieldSpecified;

        private entryType[] entryField;

        private byte[] valueField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string proc_start
        {
            get { return this.proc_startField; }
            set { this.proc_startField = value; }
        }

        [XmlIgnore]
        public bool proc_startSpecified
        {
            get { return this.proc_startFieldSpecified; }
            set { this.proc_startFieldSpecified = value; }
        }

        [XmlElement("entry", Form = XmlSchemaForm.Unqualified)]
        public entryType[] entry
        {
            get { return this.entryField; }
            set { this.entryField = value; }
        }

        [XmlAttribute(DataType = "hexBinary")]
        public byte[] value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
    }
}