using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class x86reference
    {
        private opcodeType onebyteField;

        private opcodeType twobyteField;

        private gennotesTypeGen_note[] gen_notesField;

        private ringnotesTypeRing_note[] ring_notesField;

        private string versionField;

        [XmlElement("one-byte", Form = XmlSchemaForm.Unqualified)]
        public opcodeType onebyte
        {
            get { return this.onebyteField; }
            set { this.onebyteField = value; }
        }

        [XmlElement("two-byte", Form = XmlSchemaForm.Unqualified)]
        public opcodeType twobyte
        {
            get { return this.twobyteField; }
            set { this.twobyteField = value; }
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("gen_note", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public gennotesTypeGen_note[] gen_notes
        {
            get { return this.gen_notesField; }
            set { this.gen_notesField = value; }
        }

        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("ring_note", Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public ringnotesTypeRing_note[] ring_notes
        {
            get { return this.ring_notesField; }
            set { this.ring_notesField = value; }
        }

        [XmlAttribute]
        public string version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
        }
    }
}