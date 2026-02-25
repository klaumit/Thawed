using System;
using System.Xml.Serialization;

namespace x86refLib.Xml
{
    [Serializable]
    [XmlType(AnonymousType = true)]
    public class ringnotesTypeRing_note
    {
        private string idField;

        [XmlAttribute]
        public string id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
    }
}