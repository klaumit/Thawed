using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RefX86Asm.Xml
{
    [Serializable]
    public class entryType
    {
        private byte[] prefField;

        private string opcd_extField;

        private entryTypeSec_opcd sec_opcdField;

        private entryTypeProc_start proc_startField;

        private string proc_endField;

        private bool proc_endFieldSpecified;

        private syntaxType[] syntaxField;

        private entryTypeInstr_ext instr_extField;

        private bool instr_extFieldSpecified;

        private string grp1Field;

        private string[] grp2Field;

        private string[] grp3Field;

        private string test_fField;

        private entryTypeModif_f modif_fField;

        private entryTypeDef_f def_fField;

        private string undef_fField;

        private string f_valsField;

        private string modif_f_fpuField;

        private string def_f_fpuField;

        private string undef_f_fpuField;

        private string f_vals_fpuField;

        private skipme noteField;

        private string doc_part_alias_refField;

        private string part_aliasField;

        private entryTypeMod modField;

        private bool modFieldSpecified;

        private yes_no fpushField;

        private bool fpushFieldSpecified;

        private string fpopField;

        private string mem_formatField;

        private string doc64_refField;

        private string aliasField;

        private string tttnField;

        private string signextField;

        private yes_no particularField;

        private bool particularFieldSpecified;

        private entryTypeDoc docField;

        private bool docFieldSpecified;

        private string doc_refField;

        private yes_no is_docField;

        private bool is_docFieldSpecified;

        private yes_no is_undocField;

        private bool is_undocFieldSpecified;

        private entryTypeRing ringField;

        private bool ringFieldSpecified;

        private entryTypeRing_ref ring_refField;

        private bool ring_refFieldSpecified;

        private string refField;

        private entryTypeMode modeField;

        private bool modeFieldSpecified;

        private string doc1632_refField;

        private yes_no rField;

        private bool rFieldSpecified;

        private entryTypeAttr attrField;

        private bool attrFieldSpecified;

        private yes_no lockField;

        private bool lockFieldSpecified;

        private int directionField;

        private bool directionFieldSpecified;

        private int op_sizeField;

        private bool op_sizeFieldSpecified;

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "hexBinary")]
        public byte[] pref
        {
            get { return this.prefField; }
            set { this.prefField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified, DataType = "integer")]
        public string opcd_ext
        {
            get { return this.opcd_extField; }
            set { this.opcd_extField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public entryTypeSec_opcd sec_opcd
        {
            get { return this.sec_opcdField; }
            set { this.sec_opcdField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public entryTypeProc_start proc_start
        {
            get { return this.proc_startField; }
            set { this.proc_startField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string proc_end
        {
            get { return this.proc_endField; }
            set { this.proc_endField = value; }
        }

        [XmlIgnore]
        public bool proc_endSpecified
        {
            get { return this.proc_endFieldSpecified; }
            set { this.proc_endFieldSpecified = value; }
        }

        [XmlElement("syntax", Form = XmlSchemaForm.Unqualified)]
        public syntaxType[] syntax
        {
            get { return this.syntaxField; }
            set { this.syntaxField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public entryTypeInstr_ext instr_ext
        {
            get { return this.instr_extField; }
            set { this.instr_extField = value; }
        }

        [XmlIgnore]
        public bool instr_extSpecified
        {
            get { return this.instr_extFieldSpecified; }
            set { this.instr_extFieldSpecified = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string grp1
        {
            get { return this.grp1Field; }
            set { this.grp1Field = value; }
        }

        [XmlElement("grp2", Form = XmlSchemaForm.Unqualified)]
        public string[] grp2
        {
            get { return this.grp2Field; }
            set { this.grp2Field = value; }
        }

        [XmlElement("grp3", Form = XmlSchemaForm.Unqualified)]
        public string[] grp3
        {
            get { return this.grp3Field; }
            set { this.grp3Field = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string test_f
        {
            get { return this.test_fField; }
            set { this.test_fField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public entryTypeModif_f modif_f
        {
            get { return this.modif_fField; }
            set { this.modif_fField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public entryTypeDef_f def_f
        {
            get { return this.def_fField; }
            set { this.def_fField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string undef_f
        {
            get { return this.undef_fField; }
            set { this.undef_fField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string f_vals
        {
            get { return this.f_valsField; }
            set { this.f_valsField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string modif_f_fpu
        {
            get { return this.modif_f_fpuField; }
            set { this.modif_f_fpuField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string def_f_fpu
        {
            get { return this.def_f_fpuField; }
            set { this.def_f_fpuField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string undef_f_fpu
        {
            get { return this.undef_f_fpuField; }
            set { this.undef_f_fpuField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string f_vals_fpu
        {
            get { return this.f_vals_fpuField; }
            set { this.f_vals_fpuField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public skipme note
        {
            get { return this.noteField; }
            set { this.noteField = value; }
        }

        [XmlAttribute]
        public string doc_part_alias_ref
        {
            get { return this.doc_part_alias_refField; }
            set { this.doc_part_alias_refField = value; }
        }

        [XmlAttribute]
        public string part_alias
        {
            get { return this.part_aliasField; }
            set { this.part_aliasField = value; }
        }

        [XmlAttribute]
        public entryTypeMod mod
        {
            get { return this.modField; }
            set { this.modField = value; }
        }

        [XmlIgnore]
        public bool modSpecified
        {
            get { return this.modFieldSpecified; }
            set { this.modFieldSpecified = value; }
        }

        [XmlAttribute]
        public yes_no fpush
        {
            get { return this.fpushField; }
            set { this.fpushField = value; }
        }

        [XmlIgnore]
        public bool fpushSpecified
        {
            get { return this.fpushFieldSpecified; }
            set { this.fpushFieldSpecified = value; }
        }

        [XmlAttribute]
        public string fpop
        {
            get { return this.fpopField; }
            set { this.fpopField = value; }
        }

        [XmlAttribute]
        public string mem_format
        {
            get { return this.mem_formatField; }
            set { this.mem_formatField = value; }
        }

        [XmlAttribute]
        public string doc64_ref
        {
            get { return this.doc64_refField; }
            set { this.doc64_refField = value; }
        }

        [XmlAttribute]
        public string alias
        {
            get { return this.aliasField; }
            set { this.aliasField = value; }
        }

        [XmlAttribute]
        public string tttn
        {
            get { return this.tttnField; }
            set { this.tttnField = value; }
        }

        [XmlAttribute("sign-ext")]
        public string signext
        {
            get { return this.signextField; }
            set { this.signextField = value; }
        }

        [XmlAttribute]
        public yes_no particular
        {
            get { return this.particularField; }
            set { this.particularField = value; }
        }

        [XmlIgnore]
        public bool particularSpecified
        {
            get { return this.particularFieldSpecified; }
            set { this.particularFieldSpecified = value; }
        }

        [XmlAttribute]
        public entryTypeDoc doc
        {
            get { return this.docField; }
            set { this.docField = value; }
        }

        [XmlIgnore]
        public bool docSpecified
        {
            get { return this.docFieldSpecified; }
            set { this.docFieldSpecified = value; }
        }

        [XmlAttribute]
        public string doc_ref
        {
            get { return this.doc_refField; }
            set { this.doc_refField = value; }
        }

        [XmlAttribute]
        public yes_no is_doc
        {
            get { return this.is_docField; }
            set { this.is_docField = value; }
        }

        [XmlIgnore]
        public bool is_docSpecified
        {
            get { return this.is_docFieldSpecified; }
            set { this.is_docFieldSpecified = value; }
        }

        [XmlAttribute]
        public yes_no is_undoc
        {
            get { return this.is_undocField; }
            set { this.is_undocField = value; }
        }

        [XmlIgnore]
        public bool is_undocSpecified
        {
            get { return this.is_undocFieldSpecified; }
            set { this.is_undocFieldSpecified = value; }
        }

        [XmlAttribute]
        public entryTypeRing ring
        {
            get { return this.ringField; }
            set { this.ringField = value; }
        }

        [XmlIgnore]
        public bool ringSpecified
        {
            get { return this.ringFieldSpecified; }
            set { this.ringFieldSpecified = value; }
        }

        [XmlAttribute]
        public entryTypeRing_ref ring_ref
        {
            get { return this.ring_refField; }
            set { this.ring_refField = value; }
        }

        [XmlIgnore]
        public bool ring_refSpecified
        {
            get { return this.ring_refFieldSpecified; }
            set { this.ring_refFieldSpecified = value; }
        }

        [XmlAttribute]
        public string @ref
        {
            get { return this.refField; }
            set { this.refField = value; }
        }

        [XmlAttribute]
        public entryTypeMode mode
        {
            get { return this.modeField; }
            set { this.modeField = value; }
        }

        [XmlIgnore]
        public bool modeSpecified
        {
            get { return this.modeFieldSpecified; }
            set { this.modeFieldSpecified = value; }
        }

        [XmlAttribute]
        public string doc1632_ref
        {
            get { return this.doc1632_refField; }
            set { this.doc1632_refField = value; }
        }

        [XmlAttribute]
        public entryTypeAttr attr
        {
            get { return this.attrField; }
            set { this.attrField = value; }
        }

        [XmlIgnore]
        public bool attrSpecified
        {
            get { return this.attrFieldSpecified; }
            set { this.attrFieldSpecified = value; }
        }

        [XmlAttribute]
        public yes_no @lock
        {
            get { return this.lockField; }
            set { this.lockField = value; }
        }

        [XmlIgnore]
        public bool lockSpecified
        {
            get { return this.lockFieldSpecified; }
            set { this.lockFieldSpecified = value; }
        }

        [XmlAttribute]
        public int direction
        {
            get { return this.directionField; }
            set { this.directionField = value; }
        }

        [XmlIgnore]
        public bool directionSpecified
        {
            get { return this.directionFieldSpecified; }
            set { this.directionFieldSpecified = value; }
        }

        [XmlAttribute]
        public int op_size
        {
            get { return this.op_sizeField; }
            set { this.op_sizeField = value; }
        }

        [XmlIgnore]
        public bool op_sizeSpecified
        {
            get { return this.op_sizeFieldSpecified; }
            set { this.op_sizeFieldSpecified = value; }
        }

        [XmlAttribute]
        public yes_no r
        {
            get { return this.rField; }
            set { this.rField = value; }
        }

        [XmlIgnore]
        public bool rSpecified
        {
            get { return this.rFieldSpecified; }
            set { this.rFieldSpecified = value; }
        }
    }
}