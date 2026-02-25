using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    public class opcodeType
    {
        private priopcdType[] pri_opcdField;

        private XmlAttribute[] anyAttrField;

        [XmlElement("pri_opcd", Form = XmlSchemaForm.Unqualified)]
        public priopcdType[] pri_opcd
        {
            get { return this.pri_opcdField; }
            set { this.pri_opcdField = value; }
        }

        [XmlAnyAttribute]
        public XmlAttribute[] AnyAttr
        {
            get { return this.anyAttrField; }
            set { this.anyAttrField = value; }
        }
    }
}