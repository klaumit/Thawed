using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    public class syntaxType
    {
        private syntaxTypeMnem mnemField;

        private operandType[] itemsField;

        private ItemsChoiceType[] itemsElementNameField;

        private string modField;

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public syntaxTypeMnem mnem
        {
            get { return this.mnemField; }
            set { this.mnemField = value; }
        }

        [XmlElement("dst", typeof(operandType), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("src", typeof(operandType), Form = XmlSchemaForm.Unqualified)]
        [XmlChoiceIdentifier("ItemsElementName")]
        public operandType[] Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }

        [XmlElement("ItemsElementName")]
        [XmlIgnore]
        public ItemsChoiceType[] ItemsElementName
        {
            get { return this.itemsElementNameField; }
            set { this.itemsElementNameField = value; }
        }

        [XmlAttribute]
        public string mod
        {
            get { return this.modField; }
            set { this.modField = value; }
        }
    }
}