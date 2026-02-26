using System;
using System.Xml;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace RefX86Asm.Xml
{
    [Serializable]
    public class skipme
    {
        private XmlElement[] anyField;

        private XmlAttribute[] anyAttrField;

        [XmlAnyElement]
        public XmlElement[] Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        [XmlAnyAttribute]
        public XmlAttribute[] AnyAttr
        {
            get { return this.anyAttrField; }
            set { this.anyAttrField = value; }
        }
    }
}