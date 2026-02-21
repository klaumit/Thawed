using System.Collections.Generic;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Thawed.Auto
{
    public enum Opcode
    {
        None = 0,
        
        /// <summary>
        /// ASCII Adjust After Addition
        /// <remarks>Numeric</remarks>
        /// </summary>
        Aaa,
        
        /// <summary>
        /// ASCII Adjust AX Before Division
        /// <remarks>Numeric</remarks>
        /// </summary>
        Aad,
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// <remarks>Numeric</remarks>
        /// </summary>
        Aam,
        
        /// <summary>
        /// ASCII Adjust AL After Subtraction
        /// <remarks>Numeric</remarks>
        /// </summary>
        Aas,
        
        /// <summary>
        /// Add With Carry
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Adc,
        
        /// <summary>
        /// Add
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Add,
        
        /// <summary>
        /// Logical AND
        /// <remarks>Bitwise</remarks>
        /// </summary>
        And,
        
        /// <summary>
        /// Check Index Against Bounds
        /// <remarks>Interrupt</remarks>
        /// </summary>
        Bound,
        
        /// <summary>
        /// Call Procedure
        /// <remarks>Jump</remarks>
        /// </summary>
        Call,
        
        /// <summary>
        /// Convert Byte to Word
        /// <remarks>Numeric</remarks>
        /// </summary>
        Cbw,
        
        /// <summary>
        /// Clear Carry Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        Clc,
        
        /// <summary>
        /// Clear Direction Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        Cld,
        
        /// <summary>
        /// Clear Interrupt Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        Cli,
        
        /// <summary>
        /// Complement Carry Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        Cmc,
        
        /// <summary>
        /// Compare Two Operands
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Cmp,
        
        /// <summary>
        /// Compare String Operands
        /// <remarks>String</remarks>
        /// </summary>
        Cmpsb,
        
        /// <summary>
        /// Compare String Operands
        /// <remarks>String</remarks>
        /// </summary>
        Cmpsw,
        
        /// <summary>
        /// Code Segment Register
        /// <remarks>Prefix</remarks>
        /// </summary>
        Cs,
        
        /// <summary>
        /// Convert Word to Doubleword
        /// <remarks>Numeric</remarks>
        /// </summary>
        Cwd,
        
        /// <summary>
        /// Decimal Adjust AL After Addition
        /// <remarks>Numeric</remarks>
        /// </summary>
        Daa,
        
        /// <summary>
        /// Decimal Adjust AL After Subtraction
        /// <remarks>Numeric</remarks>
        /// </summary>
        Das,
        
        /// <summary>
        /// Decrement by 1
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Dec,
        
        /// <summary>
        /// Unsigned Divide
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Div,
        
        /// <summary>
        /// Data Segment Register
        /// <remarks>Prefix</remarks>
        /// </summary>
        Ds,
        
        /// <summary>
        /// Make Stack Frame for Params
        /// <remarks>Other</remarks>
        /// </summary>
        Enter,
        
        /// <summary>
        /// Extra Segment Register
        /// <remarks>Prefix</remarks>
        /// </summary>
        Es,
        
        /// <summary>
        /// Halt
        /// <remarks>Interrupt</remarks>
        /// </summary>
        Hlt,
        
        /// <summary>
        /// Signed Divide
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Idiv,
        
        /// <summary>
        /// Signed Multiply
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Imul,
        
        /// <summary>
        /// Input From Port
        /// <remarks>Ports</remarks>
        /// </summary>
        In,
        
        /// <summary>
        /// Increment by 1
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Inc,
        
        /// <summary>
        /// Input from Port to String
        /// <remarks>Ports</remarks>
        /// </summary>
        Insb,
        
        /// <summary>
        /// Input from Port to String
        /// <remarks>Ports</remarks>
        /// </summary>
        Insw,
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>Interrupt</remarks>
        /// </summary>
        Int,
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>Interrupt</remarks>
        /// </summary>
        Into,
        
        /// <summary>
        /// Interrupt Return
        /// <remarks>Interrupt</remarks>
        /// </summary>
        Iret,
        
        /// <summary>
        /// Jump If Above
        /// <remarks>Branch</remarks>
        /// </summary>
        Ja,
        
        /// <summary>
        /// Jump If Below or Equal
        /// <remarks>Branch</remarks>
        /// </summary>
        Jbe,
        
        /// <summary>
        /// Jump If Carry
        /// <remarks>Branch</remarks>
        /// </summary>
        Jc,
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// <remarks>Branch</remarks>
        /// </summary>
        Jcxz,
        
        /// <summary>
        /// Jump If Greater
        /// <remarks>Branch</remarks>
        /// </summary>
        Jg,
        
        /// <summary>
        /// Jump If Greater or Equal
        /// <remarks>Branch</remarks>
        /// </summary>
        Jge,
        
        /// <summary>
        /// Jump If Less
        /// <remarks>Branch</remarks>
        /// </summary>
        Jl,
        
        /// <summary>
        /// Jump If Less or Equal
        /// <remarks>Branch</remarks>
        /// </summary>
        Jle,
        
        /// <summary>
        /// Unconditional Jump
        /// <remarks>Jump</remarks>
        /// </summary>
        Jmp,
        
        /// <summary>
        /// Jump If Not Carry
        /// <remarks>Branch</remarks>
        /// </summary>
        Jnc,
        
        /// <summary>
        /// Jump If Not Overflow
        /// <remarks>Branch</remarks>
        /// </summary>
        Jno,
        
        /// <summary>
        /// Jump If Not Parity
        /// <remarks>Branch</remarks>
        /// </summary>
        Jnp,
        
        /// <summary>
        /// Jump If Not Sign
        /// <remarks>Branch</remarks>
        /// </summary>
        Jns,
        
        /// <summary>
        /// Jump If Not Zero
        /// <remarks>Branch</remarks>
        /// </summary>
        Jnz,
        
        /// <summary>
        /// Jump If Overflow
        /// <remarks>Branch</remarks>
        /// </summary>
        Jo,
        
        /// <summary>
        /// Jump If Parity
        /// <remarks>Branch</remarks>
        /// </summary>
        Jp,
        
        /// <summary>
        /// Jump If Sign
        /// <remarks>Branch</remarks>
        /// </summary>
        Js,
        
        /// <summary>
        /// Jump If Zero
        /// <remarks>Branch</remarks>
        /// </summary>
        Jz,
        
        /// <summary>
        /// Load Status Flags Into AH Register
        /// <remarks>Flags</remarks>
        /// </summary>
        Lahf,
        
        /// <summary>
        /// Load Far Pointer
        /// <remarks>Memory</remarks>
        /// </summary>
        Lds,
        
        /// <summary>
        /// Load Effective Address
        /// <remarks>Memory</remarks>
        /// </summary>
        Lea,
        
        /// <summary>
        /// High Level Procedure Exit
        /// <remarks>Other</remarks>
        /// </summary>
        Leave,
        
        /// <summary>
        /// Load Far Pointer
        /// <remarks>Memory</remarks>
        /// </summary>
        Les,
        
        /// <summary>
        /// Assert LOCK Signal Prefix
        /// <remarks>Other</remarks>
        /// </summary>
        Lock,
        
        /// <summary>
        /// Load String
        /// <remarks>String</remarks>
        /// </summary>
        Lodsb,
        
        /// <summary>
        /// Load String
        /// <remarks>String</remarks>
        /// </summary>
        Lodsw,
        
        /// <summary>
        /// Loop According to ECX Counter
        /// <remarks>Loop</remarks>
        /// </summary>
        Loop,
        
        /// <summary>
        /// Loop While Equal
        /// <remarks>Loop</remarks>
        /// </summary>
        Loope,
        
        /// <summary>
        /// Loop While Not Equal
        /// <remarks>Loop</remarks>
        /// </summary>
        Loopne,
        
        /// <summary>
        /// Move
        /// <remarks>Memory</remarks>
        /// </summary>
        Mov,
        
        /// <summary>
        /// Move Data From String to String
        /// <remarks>String</remarks>
        /// </summary>
        Movsb,
        
        /// <summary>
        /// Move Data From String to String
        /// <remarks>String</remarks>
        /// </summary>
        Movsw,
        
        /// <summary>
        /// Unsigned Multiply
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Mul,
        
        /// <summary>
        /// Two's Complement Negation
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Neg,
        
        /// <summary>
        /// No Operation
        /// <remarks>Other</remarks>
        /// </summary>
        Nop,
        
        /// <summary>
        /// One's Complement Negation
        /// <remarks>Bitwise</remarks>
        /// </summary>
        Not,
        
        /// <summary>
        /// Logical Inclusive OR
        /// <remarks>Bitwise</remarks>
        /// </summary>
        Or,
        
        /// <summary>
        /// Output to Port
        /// <remarks>Ports</remarks>
        /// </summary>
        Out,
        
        /// <summary>
        /// Output String to Port
        /// <remarks>Ports</remarks>
        /// </summary>
        Outsb,
        
        /// <summary>
        /// Output String to Port
        /// <remarks>Ports</remarks>
        /// </summary>
        Outsw,
        
        /// <summary>
        /// Pop Value From the Stack
        /// <remarks>Stack</remarks>
        /// </summary>
        Pop,
        
        /// <summary>
        /// Pop All General Registers
        /// <remarks>Stack</remarks>
        /// </summary>
        Popa,
        
        /// <summary>
        /// Pop Stack Into EFLAGS
        /// <remarks>Stack</remarks>
        /// </summary>
        Popf,
        
        /// <summary>
        /// Push Word Onto the Stack
        /// <remarks>Stack</remarks>
        /// </summary>
        Push,
        
        /// <summary>
        /// Push All General Registers
        /// <remarks>Stack</remarks>
        /// </summary>
        Pusha,
        
        /// <summary>
        /// Push EFLAGS Onto Stack
        /// <remarks>Stack</remarks>
        /// </summary>
        Pushf,
        
        /// <summary>
        /// Rotate Through Carry Left
        /// <remarks>Shift</remarks>
        /// </summary>
        Rcl,
        
        /// <summary>
        /// Rotate Through Carry Right
        /// <remarks>Shift</remarks>
        /// </summary>
        Rcr,
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// <remarks>String</remarks>
        /// </summary>
        Rep,
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// <remarks>String</remarks>
        /// </summary>
        Repne,
        
        /// <summary>
        /// Return From Procedure
        /// <remarks>Jump</remarks>
        /// </summary>
        Ret,
        
        /// <summary>
        /// Return From Far Procedure
        /// <remarks>Jump</remarks>
        /// </summary>
        Retf,
        
        /// <summary>
        /// Rotate Left
        /// <remarks>Shift</remarks>
        /// </summary>
        Rol,
        
        /// <summary>
        /// Rotate Right
        /// <remarks>Shift</remarks>
        /// </summary>
        Ror,
        
        /// <summary>
        /// Store AH Into Flags
        /// <remarks>Flags</remarks>
        /// </summary>
        Sahf,
        
        /// <summary>
        /// Shift Arithmetic Right
        /// <remarks>Shift</remarks>
        /// </summary>
        Sar,
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Sbb,
        
        /// <summary>
        /// Scan String
        /// <remarks>String</remarks>
        /// </summary>
        Scasb,
        
        /// <summary>
        /// Scan String
        /// <remarks>String</remarks>
        /// </summary>
        Scasw,
        
        /// <summary>
        /// Shift Logical Left
        /// <remarks>Shift</remarks>
        /// </summary>
        Shl,
        
        /// <summary>
        /// Shift Logical Right
        /// <remarks>Shift</remarks>
        /// </summary>
        Shr,
        
        /// <summary>
        /// Stack Segment Register
        /// <remarks>Prefix</remarks>
        /// </summary>
        Ss,
        
        /// <summary>
        /// Set Carry Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        Stc,
        
        /// <summary>
        /// Set Direction Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        Std,
        
        /// <summary>
        /// Set Interrupt Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        Sti,
        
        /// <summary>
        /// Store String
        /// <remarks>String</remarks>
        /// </summary>
        Stosb,
        
        /// <summary>
        /// Store String
        /// <remarks>String</remarks>
        /// </summary>
        Stosw,
        
        /// <summary>
        /// Subtract
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        Sub,
        
        /// <summary>
        /// Logical Compare
        /// <remarks>Bitwise</remarks>
        /// </summary>
        Test,
        
        /// <summary>
        /// Wait
        /// <remarks>Other</remarks>
        /// </summary>
        Wait,
        
        /// <summary>
        /// Exchange Register/Memory
        /// <remarks>Memory</remarks>
        /// </summary>
        Xchg,
        
        /// <summary>
        /// Table Lookup Translation
        /// <remarks>Memory</remarks>
        /// </summary>
        Xlat,
        
        /// <summary>
        /// Logical Exclusive OR
        /// <remarks>Bitwise</remarks>
        /// </summary>
        Xor
    }
    
    public static class OpcodeExt
    {
        public static string ToName(this Opcode code) => _names[code];
        
        private static readonly Dictionary<Opcode, string> _names = new()
        {
            { Opcode.Aaa, "AAA" },
            { Opcode.Aad, "AAD" },
            { Opcode.Aam, "AAM" },
            { Opcode.Aas, "AAS" },
            { Opcode.Adc, "ADC" },
            { Opcode.Add, "ADD" },
            { Opcode.And, "AND" },
            { Opcode.Bound, "BOUND" },
            { Opcode.Call, "CALL" },
            { Opcode.Cbw, "CBW" },
            { Opcode.Clc, "CLC" },
            { Opcode.Cld, "CLD" },
            { Opcode.Cli, "CLI" },
            { Opcode.Cmc, "CMC" },
            { Opcode.Cmp, "CMP" },
            { Opcode.Cmpsb, "CMPSB" },
            { Opcode.Cmpsw, "CMPSW" },
            { Opcode.Cs, "CS" },
            { Opcode.Cwd, "CWD" },
            { Opcode.Daa, "DAA" },
            { Opcode.Das, "DAS" },
            { Opcode.Dec, "DEC" },
            { Opcode.Div, "DIV" },
            { Opcode.Ds, "DS" },
            { Opcode.Enter, "ENTER" },
            { Opcode.Es, "ES" },
            { Opcode.Hlt, "HLT" },
            { Opcode.Idiv, "IDIV" },
            { Opcode.Imul, "IMUL" },
            { Opcode.In, "IN" },
            { Opcode.Inc, "INC" },
            { Opcode.Insb, "INSB" },
            { Opcode.Insw, "INSW" },
            { Opcode.Int, "INT" },
            { Opcode.Into, "INTO" },
            { Opcode.Iret, "IRET" },
            { Opcode.Ja, "JA" },
            { Opcode.Jbe, "JBE" },
            { Opcode.Jc, "JC" },
            { Opcode.Jcxz, "JCXZ" },
            { Opcode.Jg, "JG" },
            { Opcode.Jge, "JGE" },
            { Opcode.Jl, "JL" },
            { Opcode.Jle, "JLE" },
            { Opcode.Jmp, "JMP" },
            { Opcode.Jnc, "JNC" },
            { Opcode.Jno, "JNO" },
            { Opcode.Jnp, "JNP" },
            { Opcode.Jns, "JNS" },
            { Opcode.Jnz, "JNZ" },
            { Opcode.Jo, "JO" },
            { Opcode.Jp, "JP" },
            { Opcode.Js, "JS" },
            { Opcode.Jz, "JZ" },
            { Opcode.Lahf, "LAHF" },
            { Opcode.Lds, "LDS" },
            { Opcode.Lea, "LEA" },
            { Opcode.Leave, "LEAVE" },
            { Opcode.Les, "LES" },
            { Opcode.Lock, "LOCK" },
            { Opcode.Lodsb, "LODSB" },
            { Opcode.Lodsw, "LODSW" },
            { Opcode.Loop, "LOOP" },
            { Opcode.Loope, "LOOPE" },
            { Opcode.Loopne, "LOOPNE" },
            { Opcode.Mov, "MOV" },
            { Opcode.Movsb, "MOVSB" },
            { Opcode.Movsw, "MOVSW" },
            { Opcode.Mul, "MUL" },
            { Opcode.Neg, "NEG" },
            { Opcode.Nop, "NOP" },
            { Opcode.Not, "NOT" },
            { Opcode.Or, "OR" },
            { Opcode.Out, "OUT" },
            { Opcode.Outsb, "OUTSB" },
            { Opcode.Outsw, "OUTSW" },
            { Opcode.Pop, "POP" },
            { Opcode.Popa, "POPA" },
            { Opcode.Popf, "POPF" },
            { Opcode.Push, "PUSH" },
            { Opcode.Pusha, "PUSHA" },
            { Opcode.Pushf, "PUSHF" },
            { Opcode.Rcl, "RCL" },
            { Opcode.Rcr, "RCR" },
            { Opcode.Rep, "REP" },
            { Opcode.Repne, "REPNE" },
            { Opcode.Ret, "RET" },
            { Opcode.Retf, "RETF" },
            { Opcode.Rol, "ROL" },
            { Opcode.Ror, "ROR" },
            { Opcode.Sahf, "SAHF" },
            { Opcode.Sar, "SAR" },
            { Opcode.Sbb, "SBB" },
            { Opcode.Scasb, "SCASB" },
            { Opcode.Scasw, "SCASW" },
            { Opcode.Shl, "SHL" },
            { Opcode.Shr, "SHR" },
            { Opcode.Ss, "SS" },
            { Opcode.Stc, "STC" },
            { Opcode.Std, "STD" },
            { Opcode.Sti, "STI" },
            { Opcode.Stosb, "STOSB" },
            { Opcode.Stosw, "STOSW" },
            { Opcode.Sub, "SUB" },
            { Opcode.Test, "TEST" },
            { Opcode.Wait, "WAIT" },
            { Opcode.Xchg, "XCHG" },
            { Opcode.Xlat, "XLAT" },
            { Opcode.Xor, "XOR" }
        };
    }
}
