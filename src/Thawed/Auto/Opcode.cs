using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Thawed.Auto
{
    public enum Opcode
    {
        None = 0,
        
        Aaa,
        
        Aad,
        
        Aam,
        
        Aas,
        
        Adc,
        
        Add,
        
        And,
        
        Bound,
        
        Call,
        
        Cbw,
        
        Clc,
        
        Cld,
        
        Cli,
        
        Cmc,
        
        Cmp,
        
        Cmpsb,
        
        Cmpsw,
        
        Cs,
        
        Cwd,
        
        Daa,
        
        Das,
        
        Dec,
        
        Div,
        
        Ds,
        
        Enter,
        
        Es,
        
        Hlt,
        
        Idiv,
        
        Imul,
        
        In,
        
        Inc,
        
        Insb,
        
        Insw,
        
        Int,
        
        Into,
        
        Iret,
        
        Ja,
        
        Jbe,
        
        Jc,
        
        Jcxz,
        
        Jg,
        
        Jge,
        
        Jl,
        
        Jle,
        
        Jmp,
        
        Jnc,
        
        Jno,
        
        Jnp,
        
        Jns,
        
        Jnz,
        
        Jo,
        
        Jp,
        
        Js,
        
        Jz,
        
        Lahf,
        
        Lds,
        
        Lea,
        
        Leave,
        
        Les,
        
        Lock,
        
        Lodsb,
        
        Lodsw,
        
        Loop,
        
        Loope,
        
        Loopne,
        
        Mov,
        
        Movsb,
        
        Movsw,
        
        Mul,
        
        Neg,
        
        Nop,
        
        Not,
        
        Or,
        
        Out,
        
        Outsb,
        
        Outsw,
        
        Pop,
        
        Popa,
        
        Popf,
        
        Push,
        
        Pusha,
        
        Pushf,
        
        Rcl,
        
        Rcr,
        
        Rep,
        
        Repne,
        
        Ret,
        
        Retf,
        
        Rol,
        
        Ror,
        
        Sahf,
        
        Sar,
        
        Sbb,
        
        Scasb,
        
        Scasw,
        
        Shl,
        
        Shr,
        
        Ss,
        
        Stc,
        
        Std,
        
        Sti,
        
        Stosb,
        
        Stosw,
        
        Sub,
        
        Test,
        
        Wait,
        
        Xchg,
        
        Xlat,
        
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
