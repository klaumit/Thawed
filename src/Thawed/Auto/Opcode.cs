using System.Collections.Generic;
using O = Thawed.OpMeta;

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
        [O("AAA", "37", "00110111")]
        Aaa,
        
        /// <summary>
        /// ASCII Adjust AX Before Division
        /// <remarks>Numeric</remarks>
        /// </summary>
        [O("AAD imm8", "B5 ii", "11010100 iiiiiiii")]
        Aad,
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// <remarks>Numeric</remarks>
        /// </summary>
        [O("AAM imm8", "B4 ii", "11010100 iiiiiiii")]
        Aam,
        
        /// <summary>
        /// ASCII Adjust AL After Subtraction
        /// <remarks>Numeric</remarks>
        /// </summary>
        [O("AAS", "3F", "00111111")]
        Aas,
        
        /// <summary>
        /// Add With Carry
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("ADC reg8, reg8", "10 /r", "000100.0 11rrrmmm")]
        [O("ADC reg16, reg16", "11 /r", "000100.1 11rrrmmm")]
        [O("ADC mem8, reg8", "10 /r", "00010000 oorrrmmm")]
        [O("ADC mem16, reg16", "11 /r", "00010001 oorrrmmm")]
        [O("ADC reg8, mem8", "12 /r", "00010010 oorrrmmm")]
        [O("ADC reg16, mem16", "13 /r", "00010011 oorrrmmm")]
        [O("ADC AL, imm", "14 ii", "00010100 iiiiiiii")]
        [O("ADC AX, imm", "15 ii ii", "00010101 iiiiiiii iiiiiiii")]
        [O("ADC reg8, imm8", "80 /2 ii", "10000000 11010mmm iiiiiiii")]
        [O("ADC mem8, imm8", "80 /2 ii", "10000000 oo010mmm iiiiiiii")]
        [O("ADC reg16, simm8", "83 /2 ii", "10000011 11010mmm iiiiiiii")]
        [O("ADC mem16, simm8", "83 /2 ii", "10000011 oo010mmm iiiiiiii")]
        [O("ADC reg16, imm16", "81 /2 ii ii", "10000001 11010mmm iiiiiiii iiiiiiii")]
        [O("ADC mem16, imm16", "81 /2 ii ii", "10000001 oo010mmm iiiiiiii iiiiiiii")]
        Adc,
        
        /// <summary>
        /// Add
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("ADD reg8, reg8", "00 /r", "000000.0 11rrrmmm")]
        [O("ADD reg16, reg16", "01 /r", "000000.1 11rrrmmm")]
        [O("ADD mem8, reg8", "00 /r", "00000000 oorrrmmm")]
        [O("ADD mem16, reg16", "01 /r", "00000001 oorrrmmm")]
        [O("ADD reg8, mem8", "02 /r", "00000010 oorrrmmm")]
        [O("ADD reg16, mem16", "03 /r", "00000011 oorrrmmm")]
        [O("ADD AL, imm", "04 ii", "00000100 iiiiiiii")]
        [O("ADD AX, imm", "05 ii ii", "00000101 iiiiiiii iiiiiiii")]
        [O("ADD reg8, imm8", "80 /0 ii", "10000000 11000mmm iiiiiiii")]
        [O("ADD mem8, imm8", "80 /0 ii", "10000000 oo000mmm iiiiiiii")]
        [O("ADD reg16, simm8", "83 /0 ii", "10000011 11000mmm iiiiiiii")]
        [O("ADD mem16, simm8", "83 /0 ii", "10000011 oo000mmm iiiiiiii")]
        [O("ADD reg16, imm16", "81 /0 ii ii", "10000001 11000mmm iiiiiiii iiiiiiii")]
        [O("ADD mem16, imm16", "81 /0 ii ii", "10000001 oo000mmm iiiiiiii iiiiiiii")]
        Add,
        
        /// <summary>
        /// Logical AND
        /// <remarks>Bitwise</remarks>
        /// </summary>
        [O("AND reg8, reg8", "20 /r", "001000.0 11rrrmmm")]
        [O("AND reg16, reg16", "21 /r", "001000.1 11rrrmmm")]
        [O("AND mem8, reg8", "20 /r", "00100000 oorrrmmm")]
        [O("AND mem16, reg16", "21 /r", "00100001 oorrrmmm")]
        [O("AND reg8, mem8", "22 /r", "00100010 oorrrmmm")]
        [O("AND reg16, mem16", "23 /r", "00100011 oorrrmmm")]
        [O("AND AL, imm", "24 ii", "00100100 iiiiiiii")]
        [O("AND AX, imm", "25 ii ii", "00100101 iiiiiiii iiiiiiii")]
        [O("AND reg8, imm8", "80 /4 ii", "10000000 11100mmm iiiiiiii")]
        [O("AND mem8, imm8", "80 /4 ii", "10000000 oo100mmm iiiiiiii")]
        [O("AND reg16, simm8", "83 /4 ii", "10000011 11100mmm iiiiiiii")]
        [O("AND mem16, simm8", "83 /4 ii", "10000011 oo100mmm iiiiiiii")]
        [O("AND reg16, imm16", "81 /4 ii ii", "10000001 11100mmm iiiiiiii iiiiiiii")]
        [O("AND mem16, imm16", "81 /4 ii ii", "10000001 oo100mmm iiiiiiii iiiiiiii")]
        And,
        
        /// <summary>
        /// Check Index Against Bounds
        /// <remarks>Interrupt</remarks>
        /// </summary>
        [O("BOUND reg16, mem16:16", "62 /r", "01100010 oorrrmmm")]
        Bound,
        
        /// <summary>
        /// Call Procedure
        /// <remarks>Jump</remarks>
        /// </summary>
        [O("CALL reg16", "FF /2", "11111111 11010mmm")]
        [O("CALL mem16", "FF /2", "11111111 oo010mmm")]
        [O("CALL mem16:16", "FF /3", "11111111 oo011mmm")]
        [O("CALL rel16", "E8 ii ii", "11101000 iiiiiiii iiiiiiii")]
        [O("CALL ptr16:16", "CA oo oo ss ss", "10011010 oooooooo oooooooo ssssssss ssssssss")]
        Call,
        
        /// <summary>
        /// Convert Byte to Word
        /// <remarks>Numeric</remarks>
        /// </summary>
        [O("CBW", "98", "10011000")]
        Cbw,
        
        /// <summary>
        /// Clear Carry Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("CLC", "F8", "11111000")]
        Clc,
        
        /// <summary>
        /// Clear Direction Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("CLD", "FC", "11111100")]
        Cld,
        
        /// <summary>
        /// Clear Interrupt Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("CLI", "FA", "11111010")]
        Cli,
        
        /// <summary>
        /// Complement Carry Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("CMC", "F5", "11110101")]
        Cmc,
        
        /// <summary>
        /// Compare Two Operands
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("CMP reg8, reg8", "38 /r", "001110.0 11rrrmmm")]
        [O("CMP reg16, reg16", "39 /r", "001110.1 11rrrmmm")]
        [O("CMP mem8, reg8", "38 /r", "00111000 oorrrmmm")]
        [O("CMP mem16, reg16", "39 /r", "00111001 oorrrmmm")]
        [O("CMP reg8, mem8", "3A /r", "00111010 oorrrmmm")]
        [O("CMP reg16, mem16", "3B /r", "00111011 oorrrmmm")]
        [O("CMP AL, imm", "3C ii", "00111100 iiiiiiii")]
        [O("CMP AX, imm", "3D ii ii", "00111101 iiiiiiii iiiiiiii")]
        [O("CMP reg8, imm8", "80 /7 ii", "10000000 11111mmm iiiiiiii")]
        [O("CMP mem8, imm8", "80 /7 ii", "10000000 oo111mmm iiiiiiii")]
        [O("CMP reg16, simm8", "83 /7 ii", "10000011 11111mmm iiiiiiii")]
        [O("CMP mem16, simm8", "83 /7 ii", "10000011 oo111mmm iiiiiiii")]
        [O("CMP reg16, imm16", "81 /7 ii ii", "10000001 11111mmm iiiiiiii iiiiiiii")]
        [O("CMP mem16, imm16", "81 /7 ii ii", "10000001 oo111mmm iiiiiiii iiiiiiii")]
        Cmp,
        
        /// <summary>
        /// Compare String Operands
        /// <remarks>String</remarks>
        /// </summary>
        [O("CMPSB", "A6", "10100110")]
        Cmpsb,
        
        /// <summary>
        /// Compare String Operands
        /// <remarks>String</remarks>
        /// </summary>
        [O("CMPSW", "A7", "10100111")]
        Cmpsw,
        
        /// <summary>
        /// Code Segment Register
        /// <remarks>Prefix</remarks>
        /// </summary>
        [O("CS", "2E", "00101110")]
        Cs,
        
        /// <summary>
        /// Convert Word to Doubleword
        /// <remarks>Numeric</remarks>
        /// </summary>
        [O("CWD", "99", "10011001")]
        Cwd,
        
        /// <summary>
        /// Decimal Adjust AL After Addition
        /// <remarks>Numeric</remarks>
        /// </summary>
        [O("DAA", "27", "00100111")]
        Daa,
        
        /// <summary>
        /// Decimal Adjust AL After Subtraction
        /// <remarks>Numeric</remarks>
        /// </summary>
        [O("DAS", "2F", "00101111")]
        Das,
        
        /// <summary>
        /// Decrement by 1
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("DEC reg16", "4x", "01001rrr")]
        [O("DEC reg8", "FE /1", "11111110 11001mmm")]
        [O("DEC mem8", "FE /1", "11111110 oo001mmm")]
        [O("DEC mem16", "FF /1", "11111111 oo001mmm")]
        Dec,
        
        /// <summary>
        /// Unsigned Divide
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("DIV mem8", "F6 /6", "11110110 oo110mmm")]
        [O("DIV reg8", "F6 /6", "11111110 11110mmm")]
        [O("DIV reg16", "F7 /6", "11111111 11110mmm")]
        [O("DIV mem16", "F7 /6", "11111111 oo110mmm")]
        Div,
        
        /// <summary>
        /// Data Segment Register
        /// <remarks>Prefix</remarks>
        /// </summary>
        [O("DS", "3E", "00111110")]
        Ds,
        
        /// <summary>
        /// Make Stack Frame for Params
        /// <remarks>Other</remarks>
        /// </summary>
        [O("ENTER imm16, imm8", "C8 ii ii jj", "11001000 iiiiiiii iiiiiiii jjjjjjjj")]
        Enter,
        
        /// <summary>
        /// Extra Segment Register
        /// <remarks>Prefix</remarks>
        /// </summary>
        [O("ES", "26", "00100110")]
        Es,
        
        /// <summary>
        /// Halt
        /// <remarks>Interrupt</remarks>
        /// </summary>
        [O("HLT", "F4", "11110100")]
        Hlt,
        
        /// <summary>
        /// Signed Divide
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("IDIV mem8", "F6 /7", "11110110 oo111mmm")]
        [O("IDIV reg8", "F6 /7", "11111110 11111mmm")]
        [O("IDIV reg16", "F7 /7", "11111111 11111mmm")]
        [O("IDIV mem16", "F7 /7", "11111111 oo111mmm")]
        Idiv,
        
        /// <summary>
        /// Signed Multiply
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("IMUL mem8", "F6 /5", "11110110 oo101mmm")]
        [O("IMUL reg8", "F6 /5", "11111110 11101mmm")]
        [O("IMUL reg16", "F7 /5", "11111111 11101mmm")]
        [O("IMUL mem16", "F7 /5", "11111111 oo101mmm")]
        [O("IMUL reg16, reg16, simm8", "6B /r ii", "11111111 11rrrmmm iiiiiiii")]
        [O("IMUL reg16, mem16, simm8", "6B /r ii", "11111111 oorrrmmm iiiiiiii")]
        [O("IMUL reg16, reg16, imm16", "69 /r ii ii", "11111111 11rrrmmm iiiiiiii iiiiiiii")]
        [O("IMUL reg16, mem16, imm16", "69 /r ii ii", "11111111 oorrrmmm iiiiiiii iiiiiiii")]
        Imul,
        
        /// <summary>
        /// Input From Port
        /// <remarks>Ports</remarks>
        /// </summary>
        [O("IN AL, DX", "EC", "11101100")]
        [O("IN AX, DX", "ED", "11101101")]
        [O("IN AL, imm8", "E4 ii", "11100100 iiiiiiii")]
        [O("IN AX, imm8", "E5 ii", "11100101 iiiiiiii")]
        In,
        
        /// <summary>
        /// Increment by 1
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("INC reg16", "4x", "01000rrr")]
        [O("INC reg8", "FE /0", "11111110 11000mmm")]
        [O("INC mem8", "FE /0", "11111110 oo000mmm")]
        [O("INC mem16", "FF /0", "11111111 oo000mmm")]
        Inc,
        
        /// <summary>
        /// Input from Port to String
        /// <remarks>Ports</remarks>
        /// </summary>
        [O("INSB", "6C", "01101100")]
        Insb,
        
        /// <summary>
        /// Input from Port to String
        /// <remarks>Ports</remarks>
        /// </summary>
        [O("INSW", "6D", "01101101")]
        Insw,
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>Interrupt</remarks>
        /// </summary>
        [O("INT imm8", "CD ii", "11001101 iiiiiiii")]
        Int,
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>Interrupt</remarks>
        /// </summary>
        [O("INT 3", "CC", "11001100")]
        Int3,
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>Interrupt</remarks>
        /// </summary>
        [O("INTO", "CE", "11001110")]
        Into,
        
        /// <summary>
        /// Interrupt Return
        /// <remarks>Interrupt</remarks>
        /// </summary>
        [O("IRET", "CF", "11001111")]
        Iret,
        
        /// <summary>
        /// Jump If Above
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JA rel8", "77 ii", "01110111 iiiiiiii")]
        Ja,
        
        /// <summary>
        /// Jump If Carry
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JC rel8", "72 ii", "01110010 iiiiiiii")]
        Jb,
        
        /// <summary>
        /// Jump If Below or Equal
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JBE rel8", "76 ii", "01110110 iiiiiiii")]
        Jbe,
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JCXZ rel8", "E3 ii", "11100011 iiiiiiii")]
        Jcxz,
        
        /// <summary>
        /// Jump If Greater
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JG rel8", "7F ii", "01111111 iiiiiiii")]
        Jg,
        
        /// <summary>
        /// Jump If Greater or Equal
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JGE rel8", "7D ii", "01111101 iiiiiiii")]
        Jge,
        
        /// <summary>
        /// Jump If Less
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JL rel8", "7C ii", "01111100 iiiiiiii")]
        Jl,
        
        /// <summary>
        /// Jump If Less or Equal
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JLE rel8", "7E ii", "01111110 iiiiiiii")]
        Jle,
        
        /// <summary>
        /// Unconditional Jump
        /// <remarks>Jump</remarks>
        /// </summary>
        [O("JMP rel8", "EB ii", "11101011 iiiiiiii")]
        [O("JMP reg16", "FF /4", "11111111 11100mmm")]
        [O("JMP mem16", "FF /4", "11111111 oo100mmm")]
        [O("JMP mem16:16", "FF /5", "11111111 oo101mmm")]
        [O("JMP rel16", "E9 ii ii", "11101001 iiiiiiii iiiiiiii")]
        [O("JMP ptr16:16", "EA oo oo ss ss", "11101010 oooooooo oooooooo ssssssss ssssssss")]
        Jmp,
        
        /// <summary>
        /// Jump If Not Carry
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JNC rel8", "73 ii", "01110011 iiiiiiii")]
        Jnb,
        
        /// <summary>
        /// Jump If Not Overflow
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JNO rel8", "71 ii", "01110001 iiiiiiii")]
        Jno,
        
        /// <summary>
        /// Jump If Not Sign
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JNS rel8", "79 ii", "01111001 iiiiiiii")]
        Jns,
        
        /// <summary>
        /// Jump If Not Zero
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JNZ rel8", "75 ii", "01110101 iiiiiiii")]
        Jnz,
        
        /// <summary>
        /// Jump If Overflow
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JO rel8", "70 ii", "01110000 iiiiiiii")]
        Jo,
        
        /// <summary>
        /// Jump If Parity
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JP rel8", "7A ii", "01111010 iiiiiiii")]
        Jpe,
        
        /// <summary>
        /// Jump If Not Parity
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JNP rel8", "7B ii", "01111011 iiiiiiii")]
        Jpo,
        
        /// <summary>
        /// Jump If Sign
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JS rel8", "78 ii", "01111000 iiiiiiii")]
        Js,
        
        /// <summary>
        /// Jump If Zero
        /// <remarks>Branch</remarks>
        /// </summary>
        [O("JZ rel8", "74 ii", "01110100 iiiiiiii")]
        Jz,
        
        /// <summary>
        /// Load Status Flags Into AH Register
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("LAHF", "9F", "10011111")]
        Lahf,
        
        /// <summary>
        /// Load Far Pointer
        /// <remarks>Memory</remarks>
        /// </summary>
        [O("LDS reg16, mem16", "C5 /r", "11000101 oorrrmmm")]
        Lds,
        
        /// <summary>
        /// Load Effective Address
        /// <remarks>Memory</remarks>
        /// </summary>
        [O("LEA reg16, mem16", "8D /r", "10001101 oorrrmmm")]
        Lea,
        
        /// <summary>
        /// High Level Procedure Exit
        /// <remarks>Other</remarks>
        /// </summary>
        [O("LEAVE", "C9", "11001001")]
        Leave,
        
        /// <summary>
        /// Load Far Pointer
        /// <remarks>Memory</remarks>
        /// </summary>
        [O("LES reg16, mem16", "C4 /r", "11000100 oorrrmmm")]
        Les,
        
        /// <summary>
        /// Assert LOCK Signal Prefix
        /// <remarks>Other</remarks>
        /// </summary>
        [O("LOCK", "F0", "11110000")]
        Lock,
        
        /// <summary>
        /// Load String
        /// <remarks>String</remarks>
        /// </summary>
        [O("LODSB", "AC", "10101100")]
        Lodsb,
        
        /// <summary>
        /// Load String
        /// <remarks>String</remarks>
        /// </summary>
        [O("LODSW", "AD", "10101101")]
        Lodsw,
        
        /// <summary>
        /// Loop According to ECX Counter
        /// <remarks>Loop</remarks>
        /// </summary>
        [O("LOOP rel8", "E2 ii", "11100010 iiiiiiii")]
        Loop,
        
        /// <summary>
        /// Loop While Not Equal
        /// <remarks>Loop</remarks>
        /// </summary>
        [O("LOOPNE rel8", "E0 ii", "11100000 iiiiiiii")]
        Loopnz,
        
        /// <summary>
        /// Loop While Equal
        /// <remarks>Loop</remarks>
        /// </summary>
        [O("LOOPE rel8", "E1 ii", "11100001 iiiiiiii")]
        Loopz,
        
        /// <summary>
        /// Move
        /// <remarks>Memory</remarks>
        /// </summary>
        [O("MOV reg8, reg8", "88 /r", "100010.0 11rrrmmm")]
        [O("MOV reg16, reg16", "89 /r", "100010.1 11rrrmmm")]
        [O("MOV mem8, reg8", "88 /r", "10001000 oorrrmmm")]
        [O("MOV mem16, reg16", "89 /r", "10001001 oorrrmmm")]
        [O("MOV reg8, mem8", "8A /r", "10001010 oorrrmmm")]
        [O("MOV reg16, mem16", "8B /r", "10001011 oorrrmmm")]
        [O("MOV reg16, sreg16", "8C /r", "10001100 110rrmmm")]
        [O("MOV mem16, sreg16", "8C /r", "10001100 oo0rrmmm")]
        [O("MOV sreg16, reg16", "8E /r", "10001110 110rrmmm")]
        [O("MOV sreg16, mem16", "8E /r", "10001110 oo0rrmmm")]
        [O("MOV reg8, imm8", "Bx ii", "10110rrr iiiiiiii")]
        [O("MOV AL, ptr16", "A0 ii ii", "10100000 iiiiiiii iiiiiiii")]
        [O("MOV AX, ptr16", "A1 ii ii", "10100001 iiiiiiii iiiiiiii")]
        [O("MOV ptr16, AL", "A2 ii ii", "10100010 iiiiiiii iiiiiiii")]
        [O("MOV ptr16, AX", "A3 ii ii", "10100011 iiiiiiii iiiiiiii")]
        [O("MOV reg16, imm16", "Bx ii", "10111rrr iiiiiiii iiiiiiii")]
        [O("MOV reg8, imm8", "C6 /0 ii", "11000110 11000mmm iiiiiiii")]
        [O("MOV mem8, imm8", "C6 /0 ii", "11000110 oo000mmm iiiiiiii")]
        [O("MOV reg16, imm16", "C7 /0 ii ii", "11000111 11000mmm iiiiiiii iiiiiiii")]
        [O("MOV mem16, imm16", "C7 /0 ii ii", "11000111 oo000mmm iiiiiiii iiiiiiii")]
        Mov,
        
        /// <summary>
        /// Move Data From String to String
        /// <remarks>String</remarks>
        /// </summary>
        [O("MOVSB", "A4", "10100100")]
        Movsb,
        
        /// <summary>
        /// Move Data From String to String
        /// <remarks>String</remarks>
        /// </summary>
        [O("MOVSW", "A5", "10100101")]
        Movsw,
        
        /// <summary>
        /// Unsigned Multiply
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("MUL mem8", "F6 /4", "11110110 oo100mmm")]
        [O("MUL reg8", "F6 /4", "11111110 11100mmm")]
        [O("MUL reg16", "F7 /4", "11111111 11100mmm")]
        [O("MUL mem16", "F7 /4", "11111111 oo100mmm")]
        Mul,
        
        /// <summary>
        /// Two's Complement Negation
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("NEG mem8", "F6 /3", "11110110 oo011mmm")]
        [O("NEG reg8", "F6 /3", "11111110 11011mmm")]
        [O("NEG reg16", "F7 /3", "11111111 11011mmm")]
        [O("NEG mem16", "F7 /3", "11111111 oo011mmm")]
        Neg,
        
        /// <summary>
        /// No Operation
        /// <remarks>Other</remarks>
        /// </summary>
        [O("NOP", "90", "10010000")]
        Nop,
        
        /// <summary>
        /// One's Complement Negation
        /// <remarks>Bitwise</remarks>
        /// </summary>
        [O("NOT mem8", "F6 /2", "11110110 oo010mmm")]
        [O("NOT reg8", "F6 /2", "11111110 11010mmm")]
        [O("NOT reg16", "F7 /2", "11111111 11010mmm")]
        [O("NOT mem16", "F7 /2", "11111111 oo010mmm")]
        Not,
        
        /// <summary>
        /// Logical Inclusive OR
        /// <remarks>Bitwise</remarks>
        /// </summary>
        [O("OR reg8, reg8", "08 /r", "000010.0 11rrrmmm")]
        [O("OR reg16, reg16", "09 /r", "000010.1 11rrrmmm")]
        [O("OR mem8, reg8", "08 /r", "00001000 oorrrmmm")]
        [O("OR mem16, reg16", "09 /r", "00001001 oorrrmmm")]
        [O("OR reg8, mem8", "0A /r", "00001010 oorrrmmm")]
        [O("OR reg16, mem16", "0B /r", "00001011 oorrrmmm")]
        [O("OR AL, imm", "0C ii", "00001100 iiiiiiii")]
        [O("OR AX, imm", "0D ii ii", "00001101 iiiiiiii iiiiiiii")]
        [O("OR reg8, imm8", "80 /6 ii", "10000000 11001mmm iiiiiiii")]
        [O("OR mem8, imm8", "80 /6 ii", "10000000 oo001mmm iiiiiiii")]
        [O("OR reg16, simm8", "83 /6 ii", "10000011 11001mmm iiiiiiii")]
        [O("OR mem16, simm8", "83 /6 ii", "10000011 oo001mmm iiiiiiii")]
        [O("OR reg16, imm16", "81 /6 ii ii", "10000001 11001mmm iiiiiiii iiiiiiii")]
        [O("OR mem16, imm16", "81 /6 ii ii", "10000001 oo001mmm iiiiiiii iiiiiiii")]
        Or,
        
        /// <summary>
        /// Output to Port
        /// <remarks>Ports</remarks>
        /// </summary>
        [O("OUT DX, AL", "EE", "11101110")]
        [O("OUT DX, AX", "EF", "11101111")]
        [O("OUT imm8, AL", "E6 ii", "11100110 iiiiiiii")]
        [O("OUT imm8, AX", "E7 ii", "11100111 iiiiiiii")]
        Out,
        
        /// <summary>
        /// Output String to Port
        /// <remarks>Ports</remarks>
        /// </summary>
        [O("OUTSB", "6E", "01101110")]
        Outsb,
        
        /// <summary>
        /// Output String to Port
        /// <remarks>Ports</remarks>
        /// </summary>
        [O("OUTSW", "6F", "01101111")]
        Outsw,
        
        /// <summary>
        /// Pop Value From the Stack
        /// <remarks>Stack</remarks>
        /// </summary>
        [O("POP sreg16", "xx", "000xx111")]
        [O("POP reg16", "5x", "01011xxx")]
        [O("POP reg16", "8F /0", "10001111 11000mmm")]
        [O("POP mem16", "8F /0", "10001111 oo000mmm")]
        Pop,
        
        /// <summary>
        /// Pop All General Registers
        /// <remarks>Stack</remarks>
        /// </summary>
        [O("POPA", "61", "01100001")]
        Popa,
        
        /// <summary>
        /// Pop Stack Into EFLAGS
        /// <remarks>Stack</remarks>
        /// </summary>
        [O("POPF", "9D", "10011101")]
        Popf,
        
        /// <summary>
        /// Push Word Onto the Stack
        /// <remarks>Stack</remarks>
        /// </summary>
        [O("PUSH sreg16", "xx", "000xx110")]
        [O("PUSH reg16", "5x", "01010xxx")]
        [O("PUSH simm8", "6A ii", "01101010 iiiiiiii")]
        [O("PUSH reg16", "FF /6", "11111111 11110mmm")]
        [O("PUSH mem16", "FF /6", "11111111 oo110mmm")]
        [O("PUSH imm16", "68 ii ii", "01101000 iiiiiiii iiiiiiii")]
        Push,
        
        /// <summary>
        /// Push All General Registers
        /// <remarks>Stack</remarks>
        /// </summary>
        [O("PUSHA", "60", "01100000")]
        Pusha,
        
        /// <summary>
        /// Push EFLAGS Onto Stack
        /// <remarks>Stack</remarks>
        /// </summary>
        [O("PUSHF", "9C", "10011100")]
        Pushf,
        
        /// <summary>
        /// Rotate Through Carry Left
        /// <remarks>Shift</remarks>
        /// </summary>
        [O("RCL reg8, 1", "D0 /2", "11010000 11010rm")]
        [O("RCL mem8, 1", "D0 /2", "11010000 oo010rm")]
        [O("RCL reg16, 1", "D1 /2", "11010001 11010rm")]
        [O("RCL mem16, 1", "D1 /2", "11010001 oo010rm")]
        [O("RCL reg8, CL", "D2 /2", "11010010 11010rm")]
        [O("RCL mem8, CL", "D2 /2", "11010010 oo010rm")]
        [O("RCL reg16, CL", "D3 /2", "11010011 11010rm")]
        [O("RCL mem16, CL", "D3 /2", "11010011 oo010rm")]
        [O("RCL reg8, imm8", "C0 /2 ii", "11000000 11010mmm iiiiiiii")]
        [O("RCL mem8, imm8", "C0 /2 ii", "11000000 oo010mmm iiiiiiii")]
        [O("RCL reg16, imm8", "C1 /2 ii", "11000001 11010mmm iiiiiiii")]
        [O("RCL mem16, imm8", "C1 /2 ii", "11000001 oo010mmm iiiiiiii")]
        Rcl,
        
        /// <summary>
        /// Rotate Through Carry Right
        /// <remarks>Shift</remarks>
        /// </summary>
        [O("RCR reg8, 1", "D0 /3", "11010000 11011rm")]
        [O("RCR mem8, 1", "D0 /3", "11010000 oo011rm")]
        [O("RCR reg16, 1", "D1 /3", "11010001 11011rm")]
        [O("RCR mem16, 1", "D1 /3", "11010001 oo011rm")]
        [O("RCR reg8, CL", "D2 /3", "11010010 11011rm")]
        [O("RCR mem8, CL", "D2 /3", "11010010 oo011rm")]
        [O("RCR reg16, CL", "D3 /3", "11010011 11011rm")]
        [O("RCR mem16, CL", "D3 /3", "11010011 oo011rm")]
        [O("RCR reg8, imm8", "C0 /3 ii", "11000000 11011mmm iiiiiiii")]
        [O("RCR mem8, imm8", "C0 /3 ii", "11000000 oo011mmm iiiiiiii")]
        [O("RCR reg16, imm8", "C1 /3 ii", "11000001 11011mmm iiiiiiii")]
        [O("RCR mem16, imm8", "C1 /3 ii", "11000001 oo011mmm iiiiiiii")]
        Rcr,
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// <remarks>String</remarks>
        /// </summary>
        [O("REP", "F3 /?", "11110011")]
        Repe,
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// <remarks>String</remarks>
        /// </summary>
        [O("REPNE", "F2 /?", "11110010")]
        Repne,
        
        /// <summary>
        /// Return From Procedure
        /// <remarks>Jump</remarks>
        /// </summary>
        [O("RET", "C3", "11000011")]
        [O("RET imm16", "C2 ii ii", "11000010 iiiiiiii iiiiiiii")]
        Ret,
        
        /// <summary>
        /// Return From Far Procedure
        /// <remarks>Jump</remarks>
        /// </summary>
        [O("RETF", "CB", "11001011")]
        [O("RETF imm16", "CA ii ii", "11001010 iiiiiiii iiiiiiii")]
        Retf,
        
        /// <summary>
        /// Rotate Left
        /// <remarks>Shift</remarks>
        /// </summary>
        [O("ROL reg8, 1", "D0 /0", "11010000 11000rm")]
        [O("ROL mem8, 1", "D0 /0", "11010000 oo000rm")]
        [O("ROL reg16, 1", "D1 /0", "11010001 11000rm")]
        [O("ROL mem16, 1", "D1 /0", "11010001 oo000rm")]
        [O("ROL reg8, CL", "D2 /0", "11010010 11000rm")]
        [O("ROL mem8, CL", "D2 /0", "11010010 oo000rm")]
        [O("ROL reg16, CL", "D3 /0", "11010011 11000rm")]
        [O("ROL mem16, CL", "D3 /0", "11010011 oo000rm")]
        [O("ROL reg8, imm8", "C0 /0 ii", "11000000 11000mmm iiiiiiii")]
        [O("ROL mem8, imm8", "C0 /0 ii", "11000000 oo000mmm iiiiiiii")]
        [O("ROL reg16, imm8", "C1 /0 ii", "11000001 11000mmm iiiiiiii")]
        [O("ROL mem16, imm8", "C1 /0 ii", "11000001 oo000mmm iiiiiiii")]
        Rol,
        
        /// <summary>
        /// Rotate Right
        /// <remarks>Shift</remarks>
        /// </summary>
        [O("ROR reg8, 1", "D0 /1", "11010000 11001rm")]
        [O("ROR mem8, 1", "D0 /1", "11010000 oo001rm")]
        [O("ROR reg16, 1", "D1 /1", "11010001 11001rm")]
        [O("ROR mem16, 1", "D1 /1", "11010001 oo001rm")]
        [O("ROR reg8, CL", "D2 /1", "11010010 11001rm")]
        [O("ROR mem8, CL", "D2 /1", "11010010 oo001rm")]
        [O("ROR reg16, CL", "D3 /1", "11010011 11001rm")]
        [O("ROR mem16, CL", "D3 /1", "11010011 oo001rm")]
        [O("ROR reg8, imm8", "C0 /1 ii", "11000000 11001mmm iiiiiiii")]
        [O("ROR mem8, imm8", "C0 /1 ii", "11000000 oo001mmm iiiiiiii")]
        [O("ROR reg16, imm8", "C1 /1 ii", "11000001 11001mmm iiiiiiii")]
        [O("ROR mem16, imm8", "C1 /1 ii", "11000001 oo001mmm iiiiiiii")]
        Ror,
        
        /// <summary>
        /// Store AH Into Flags
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("SAHF", "9E", "10011110")]
        Sahf,
        
        /// <summary>
        /// Shift Arithmetic Right
        /// <remarks>Shift</remarks>
        /// </summary>
        [O("SAR reg8, 1", "D0 /7", "11010000 11111rm")]
        [O("SAR mem8, 1", "D0 /7", "11010000 oo111rm")]
        [O("SAR reg16, 1", "D1 /7", "11010001 11111rm")]
        [O("SAR mem16, 1", "D1 /7", "11010001 oo111rm")]
        [O("SAR reg8, CL", "D2 /7", "11010010 11111rm")]
        [O("SAR mem8, CL", "D2 /7", "11010010 oo111rm")]
        [O("SAR reg16, CL", "D3 /7", "11010011 11111rm")]
        [O("SAR mem16, CL", "D3 /7", "11010011 oo111rm")]
        [O("SAR reg8, imm8", "C0 /7 ii", "11000000 11111mmm iiiiiiii")]
        [O("SAR mem8, imm8", "C0 /7 ii", "11000000 oo111mmm iiiiiiii")]
        [O("SAR reg16, imm8", "C1 /7 ii", "11000001 11111mmm iiiiiiii")]
        [O("SAR mem16, imm8", "C1 /7 ii", "11000001 oo111mmm iiiiiiii")]
        Sar,
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("SBB reg8, reg8", "18 /r", "000110.0 11rrrmmm")]
        [O("SBB reg16, reg16", "19 /r", "000110.1 11rrrmmm")]
        [O("SBB mem8, reg8", "18 /r", "00011000 oorrrmmm")]
        [O("SBB mem16, reg16", "19 /r", "00011001 oorrrmmm")]
        [O("SBB reg8, mem8", "1A /r", "00011010 oorrrmmm")]
        [O("SBB reg16, mem16", "1B /r", "00011011 oorrrmmm")]
        [O("SBB AL, imm", "1C ii", "00011100 iiiiiiii")]
        [O("SBB AX, imm", "1D ii ii", "00011101 iiiiiiii iiiiiiii")]
        [O("SBB reg8, imm8", "80 /3 ii", "10000000 11011mmm iiiiiiii")]
        [O("SBB mem8, imm8", "80 /3 ii", "10000000 oo011mmm iiiiiiii")]
        [O("SBB reg16, simm8", "83 /3 ii", "10000011 11011mmm iiiiiiii")]
        [O("SBB mem16, simm8", "83 /3 ii", "10000011 oo011mmm iiiiiiii")]
        [O("SBB reg16, imm16", "81 /3 ii ii", "10000001 11011mmm iiiiiiii iiiiiiii")]
        [O("SBB mem16, imm16", "81 /3 ii ii", "10000001 oo011mmm iiiiiiii iiiiiiii")]
        Sbb,
        
        /// <summary>
        /// Scan String
        /// <remarks>String</remarks>
        /// </summary>
        [O("SCASB", "AE", "10101110")]
        Scasb,
        
        /// <summary>
        /// Scan String
        /// <remarks>String</remarks>
        /// </summary>
        [O("SCASW", "AF", "10101111")]
        Scasw,
        
        /// <summary>
        /// Shift Logical Left
        /// <remarks>Shift</remarks>
        /// </summary>
        [O("SHL reg8, 1", "D0 /4", "11010000 11100rm")]
        [O("SHL mem8, 1", "D0 /4", "11010000 oo100rm")]
        [O("SHL reg16, 1", "D1 /4", "11010001 11100rm")]
        [O("SHL mem16, 1", "D1 /4", "11010001 oo100rm")]
        [O("SHL reg8, CL", "D2 /4", "11010010 11100rm")]
        [O("SHL mem8, CL", "D2 /4", "11010010 oo100rm")]
        [O("SHL reg16, CL", "D3 /4", "11010011 11100rm")]
        [O("SHL mem16, CL", "D3 /4", "11010011 oo100rm")]
        [O("SHL reg8, imm8", "C0 /4 ii", "11000000 11100mmm iiiiiiii")]
        [O("SHL mem8, imm8", "C0 /4 ii", "11000000 oo100mmm iiiiiiii")]
        [O("SHL reg16, imm8", "C1 /4 ii", "11000001 11100mmm iiiiiiii")]
        [O("SHL mem16, imm8", "C1 /4 ii", "11000001 oo100mmm iiiiiiii")]
        Shl,
        
        /// <summary>
        /// Shift Logical Right
        /// <remarks>Shift</remarks>
        /// </summary>
        [O("SHR reg8, 1", "D0 /5", "11010000 11101rm")]
        [O("SHR mem8, 1", "D0 /5", "11010000 oo101rm")]
        [O("SHR reg16, 1", "D1 /5", "11010001 11101rm")]
        [O("SHR mem16, 1", "D1 /5", "11010001 oo101rm")]
        [O("SHR reg8, CL", "D2 /5", "11010010 11101rm")]
        [O("SHR mem8, CL", "D2 /5", "11010010 oo101rm")]
        [O("SHR reg16, CL", "D3 /5", "11010011 11101rm")]
        [O("SHR mem16, CL", "D3 /5", "11010011 oo101rm")]
        [O("SHR reg8, imm8", "C0 /5 ii", "11000000 11101mmm iiiiiiii")]
        [O("SHR mem8, imm8", "C0 /5 ii", "11000000 oo101mmm iiiiiiii")]
        [O("SHR reg16, imm8", "C1 /5 ii", "11000001 11101mmm iiiiiiii")]
        [O("SHR mem16, imm8", "C1 /5 ii", "11000001 oo101mmm iiiiiiii")]
        Shr,
        
        /// <summary>
        /// Stack Segment Register
        /// <remarks>Prefix</remarks>
        /// </summary>
        [O("SS", "36", "00110110")]
        Ss,
        
        /// <summary>
        /// Set Carry Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("STC", "F9", "11111001")]
        Stc,
        
        /// <summary>
        /// Set Direction Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("STD", "FD", "11111101")]
        Std,
        
        /// <summary>
        /// Set Interrupt Flag
        /// <remarks>Flags</remarks>
        /// </summary>
        [O("STI", "FB", "11111011")]
        Sti,
        
        /// <summary>
        /// Store String
        /// <remarks>String</remarks>
        /// </summary>
        [O("STOSB", "AA", "10101010")]
        Stosb,
        
        /// <summary>
        /// Store String
        /// <remarks>String</remarks>
        /// </summary>
        [O("STOSW", "AB", "10101011")]
        Stosw,
        
        /// <summary>
        /// Subtract
        /// <remarks>Arithmetic</remarks>
        /// </summary>
        [O("SUB reg8, reg8", "28 /r", "001010.0 11rrrmmm")]
        [O("SUB reg16, reg16", "29 /r", "001010.1 11rrrmmm")]
        [O("SUB mem8, reg8", "28 /r", "00101000 oorrrmmm")]
        [O("SUB mem16, reg16", "29 /r", "00101001 oorrrmmm")]
        [O("SUB reg8, mem8", "2A /r", "00101010 oorrrmmm")]
        [O("SUB reg16, mem16", "2B /r", "00101011 oorrrmmm")]
        [O("SUB AL, imm", "28 ii", "00101100 iiiiiiii")]
        [O("SUB AX, imm", "29 ii ii", "00101101 iiiiiiii iiiiiiii")]
        [O("SUB reg8, imm8", "80 /5 ii", "10000000 11101mmm iiiiiiii")]
        [O("SUB mem8, imm8", "80 /5 ii", "10000000 oo101mmm iiiiiiii")]
        [O("SUB reg16, simm8", "83 /5 ii", "10000011 11101mmm iiiiiiii")]
        [O("SUB mem16, simm8", "83 /5 ii", "10000011 oo101mmm iiiiiiii")]
        [O("SUB reg16, imm16", "81 /5 ii ii", "10000001 11101mmm iiiiiiii iiiiiiii")]
        [O("SUB mem16, imm16", "81 /5 ii ii", "10000001 oo101mmm iiiiiiii iiiiiiii")]
        Sub,
        
        /// <summary>
        /// Logical Compare
        /// <remarks>Bitwise</remarks>
        /// </summary>
        [O("TEST reg8, reg8", "84 /r", "10000100 11rrrmmm")]
        [O("TEST mem8, reg8 TEST reg8, mem8", "84 /r", "10000100 oorrrmmm")]
        [O("TEST reg16, reg16", "85 /r", "10000101 11rrrmmm")]
        [O("TEST mem16, reg16 TEST reg16, mem16", "85 /r", "10000101 oorrrmmm")]
        [O("TEST AL, imm", "A8 ii", "10101000 iiiiiiii")]
        [O("TEST AX, imm", "A9 ii ii", "10101001 iiiiiiii iiiiiiii")]
        [O("TEST reg8, imm8", "F6 /0 ii", "11110110 11000mmm iiiiiiii")]
        [O("TEST mem8, imm8", "F6 /0 ii", "11110110 oo000mmm iiiiiiii")]
        [O("TEST reg16, imm16", "F7 /0 ii ii", "11110111 11000mmm iiiiiiii iiiiiiii")]
        [O("TEST mem16, imm16", "F7 /0 ii ii", "11110111 oo000mmm iiiiiiii iiiiiiii")]
        Test,
        
        /// <summary>
        /// Wait
        /// <remarks>Other</remarks>
        /// </summary>
        [O("WAIT", "9B", "10011011")]
        Wait,
        
        /// <summary>
        /// Exchange Register/Memory
        /// <remarks>Memory</remarks>
        /// </summary>
        [O("XCHG AX, reg16 XCHG reg16, AX", "9x", "10010rrr")]
        [O("XCHG reg8, reg8", "86 /r", "10000110 11rrrmmm")]
        [O("XCHG mem8, reg8 XCHG reg8, mem8", "86 /r", "10000110 oorrrmmm")]
        [O("XCHG reg16, reg16", "87 /r", "10000111 11rrrmmm")]
        [O("XCHG mem16, reg16 XCHG reg16, mem16", "87 /r", "10000111 oorrrmmm")]
        Xchg,
        
        /// <summary>
        /// Table Lookup Translation
        /// <remarks>Memory</remarks>
        /// </summary>
        [O("XLAT", "D7", "11010111")]
        Xlat,
        
        /// <summary>
        /// Logical Exclusive OR
        /// <remarks>Bitwise</remarks>
        /// </summary>
        [O("XOR reg8, reg8", "30 /r", "001100.0 11rrrmmm")]
        [O("XOR reg16, reg16", "31 /r", "001100.1 11rrrmmm")]
        [O("XOR mem8, reg8", "30 /r", "00110000 oorrrmmm")]
        [O("XOR mem16, reg16", "31 /r", "00110001 oorrrmmm")]
        [O("XOR reg8, mem8", "32 /r", "00110010 oorrrmmm")]
        [O("XOR reg16, mem16", "33 /r", "00110011 oorrrmmm")]
        [O("XOR AL, imm", "34 ii", "00110100 iiiiiiii")]
        [O("XOR AX, imm", "35 ii ii", "00110101 iiiiiiii iiiiiiii")]
        [O("XOR reg8, imm8", "80 /6 ii", "10000000 11110mmm iiiiiiii")]
        [O("XOR mem8, imm8", "80 /6 ii", "10000000 oo110mmm iiiiiiii")]
        [O("XOR reg16, simm8", "83 /6 ii", "10000011 11110mmm iiiiiiii")]
        [O("XOR mem16, simm8", "83 /6 ii", "10000011 oo110mmm iiiiiiii")]
        [O("XOR reg16, imm16", "81 /6 ii ii", "10000001 11110mmm iiiiiiii iiiiiiii")]
        [O("XOR mem16, imm16", "81 /6 ii ii", "10000001 oo110mmm iiiiiiii iiiiiiii")]
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
            { Opcode.Int3, "INT3" },
            { Opcode.Into, "INTO" },
            { Opcode.Iret, "IRET" },
            { Opcode.Ja, "JA" },
            { Opcode.Jb, "JB" },
            { Opcode.Jbe, "JBE" },
            { Opcode.Jcxz, "JCXZ" },
            { Opcode.Jg, "JG" },
            { Opcode.Jge, "JGE" },
            { Opcode.Jl, "JL" },
            { Opcode.Jle, "JLE" },
            { Opcode.Jmp, "JMP" },
            { Opcode.Jnb, "JNB" },
            { Opcode.Jno, "JNO" },
            { Opcode.Jns, "JNS" },
            { Opcode.Jnz, "JNZ" },
            { Opcode.Jo, "JO" },
            { Opcode.Jpe, "JPE" },
            { Opcode.Jpo, "JPO" },
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
            { Opcode.Loopnz, "LOOPNZ" },
            { Opcode.Loopz, "LOOPZ" },
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
            { Opcode.Repe, "REPE" },
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
