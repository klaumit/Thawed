using I = Thawed.Instruction;
using O = Thawed.Auto.Opcode;
using A = Thawed.Args.Arg;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed.Auto
{
    internal static class Instruct
    {
        /// <summary>
        /// ASCII adjust for add
        /// <remarks>AAA</remarks>
        /// </summary>
        internal static I Aaa()
        {
            return new I(O.Aaa);
        }
        
        /// <summary>
        /// ASCII adjust for divide
        /// <remarks>AAD</remarks> 
        /// </summary>
        internal static I? Aad(byte? v)
        {
            return v is 0b00001010 ? new I(O.Aad, v) : null;
        }
        
        /// <summary>
        /// ASCII adjust for multiply
        /// <remarks>AAM</remarks>
        /// </summary>
        internal static I? Aam(byte? v)
        {
            return v is 0b00001010 ? new I(O.Aam, v) : null;
        }
        
        /// <summary>
        /// ASCII adjust for subtract
        /// <remarks>AAS</remarks>
        /// </summary>
        internal static I Aas()
        {
            return new I(O.Aas);
        }
        
        internal static I Adc(params A[] args)
        {
            return new I(O.Adc, args);
        }
        
        internal static I Add(params A[] args)
        {
            return new I(O.Add, args);
        }
        
        internal static I And(params A[] args)
        {
            return new I(O.And, args);
        }
        
        internal static I Bound(params A[] args)
        {
            return new I(O.Bound, args);
        }
        
        /// <summary>
        /// Call direct within segment
        /// <remarks>CALL</remarks>
        /// </summary>
        internal static I? Call(byte? low, byte? high)
        {
            return low is { } l && high is { } h ? new I(O.Call, l, h) : null;
        }
        
        /// <summary>
        /// Convert byte to word
        /// <remarks>CBW</remarks>
        /// </summary>
        internal static I Cbw()
        {
            return new I(O.Cbw);
        }
        
        /// <summary>
        /// Clear carry
        /// </summary>
        internal static I Clc()
        {
            return new I(O.Clc);
        }
        
        /// <summary>
        /// Clear direction
        /// </summary>
        internal static I Cld()
        {
            return new I(O.Cld);
        }
        
        /// <summary>
        /// Clear interrupt
        /// </summary>
        internal static I Cli()
        {
            return new I(O.Cli);
        }
        
        /// <summary>
        /// Complement carry
        /// </summary>
        internal static I Cmc()
        {
            return new I(O.Cmc);
        }
        
        internal static I Cmp(params A[] args)
        {
            return new I(O.Cmp, args);
        }
        
        /// <summary>
        /// Compare byte
        /// <remarks>CMPSB</remarks>
        /// </summary>
        internal static I Cmpsb()
        {
            return new I(O.Cmpsb);
        }
        
        /// <summary>
        /// Compare word
        /// <remarks>CMPSW</remarks>
        /// </summary>
        internal static I Cmpsw()
        {
            return new I(O.Cmpsw);
        }
        
        /// <summary>
        /// CS: override
        /// <remarks>CS</remarks>
        /// </summary>
        internal static I Cs()
        {
            return new I(O.Cs);
        }
        
        /// <summary>
        /// Convert word to double word
        /// <remarks>CWD</remarks>
        /// </summary>
        internal static I Cwd()
        {
            return new I(O.Cwd);
        }
        
        /// <summary>
        /// Decimal adjust for add
        /// <remarks>DAA</remarks>
        /// </summary>
        internal static I Daa()
        {
            return new I(O.Daa);
        }
        
        /// <summary>
        /// Decimal adjust for subtract
        /// <remarks>DAS</remarks>
        /// </summary>
        internal static I Das()
        {
            return new I(O.Das);
        }
        
        internal static I Dec(params A[] args)
        {
            return new I(O.Dec, args);
        }
        
        internal static I Div(params A[] args)
        {
            return new I(O.Div, args);
        }
        
        /// <summary>
        /// DS: override
        /// <remarks>DS</remarks>
        /// </summary>
        internal static I Ds()
        {
            return new I(O.Ds);
        }
        
        /// <summary>
        /// Enter procedure
        /// <remarks>ENTER</remarks>
        /// </summary>
        internal static I? Enter(byte? low, byte? high, byte? ext)
        {
            return low is { } l && high is { } h && ext is { } e
                ? new I(O.Enter, l, h, e)
                : null;
        }
        
        /// <summary>
        /// ES: override
        /// <remarks>ES</remarks>
        /// </summary>
        internal static I Es()
        {
            return new I(O.Es);
        }
        
        /// <summary>
        /// Halt
        /// </summary>
        internal static I Hlt()
        {
            return new I(O.Hlt);
        }
        
        internal static I Idiv(params A[] args)
        {
            return new I(O.Idiv, args);
        }
        
        internal static I Imul(params A[] args)
        {
            return new I(O.Imul, args);
        }
        
        internal static I In(params A[] args)
        {
            return new I(O.In, args);
        }
        
        internal static I Inc(params A[] args)
        {
            return new I(O.Inc, args);
        }
        
        /// <summary>
        /// Input byte from DX port
        /// <remarks>INSB</remarks>
        /// </summary>
        internal static I Insb()
        {
            return new I(O.Insb);
        }
        
        /// <summary>
        /// Input word from DX port
        /// <remarks>INSW</remarks>
        /// </summary>
        internal static I Insw()
        {
            return new I(O.Insw);
        }
        
        /// <summary>
        /// Interrupt with type specified
        /// <remarks>INT</remarks>
        /// </summary>
        internal static I? Int(byte? v)
        {
            return v is {} b ? new I(O.Int, b) : null;
        }
        
        /// <summary>
        /// Interrupt type 3
        /// <remarks>INT3</remarks>
        /// </summary>
        internal static I Int3()
        {
            return new I(O.Int3);
        }
        
        /// <summary>
        /// Interrupt on overflow
        /// <remarks>INTO</remarks>
        /// </summary>
        internal static I Into()
        {
            return new I(O.Into);
        }
        
        /// <summary>
        /// Interrupt return
        /// <remarks>IRET</remarks>
        /// </summary>
        internal static I Iret()
        {
            return new I(O.Iret);
        }
        
        /// <summary>
        /// Jump on not below or equal/above
        /// <remarks>JNBE/JA</remarks> 
        /// </summary>
        internal static I? Ja(byte? v)
        {
            return v is {} b? new I(O.Ja, b) : null;
        }
        
        /// <summary>
        /// Jump on below/not above or equal
        /// <remarks>JB/JNAE</remarks>
        /// </summary>
        internal static I? Jb(byte? v)
        {
            return v is {} b? new I(O.Jb, b) : null;
        }
        
        /// <summary>
        /// Jump on below or equal/not above
        /// <remarks>JBE/JNA</remarks>
        /// </summary>
        internal static I? Jbe(byte? v)
        {
            return v is {} b? new I(O.Jbe, b) : null;
        }
        
        /// <summary>
        /// Jump on CX zero
        /// <remarks>JCXZ</remarks>
        /// </summary>
        internal static I? Jcxz(byte? v)
        {
            return v is {} b? new I(O.Jcxz, b) : null;
        }
        
        /// <summary>
        /// Jump on not less or equal/greater
        /// <remarks>JNLE/JG</remarks>
        /// </summary>
        internal static I? Jg(byte? v)
        {
            return v is {} b ? new I(O.Jg, b) : null;
        }
        
        /// <summary>
        /// Jump on not less/greater or equal
        /// <remarks>JNL/JGE</remarks>
        /// </summary>
        internal static I? Jge(byte? v)
        {
            return v is {} b ? new I(O.Jge, b) : null;
        }
        
        /// <summary>
        /// Jump on less/not greater or equal
        /// </summary>
        /// <remarks>JL/JNGE</remarks>
        internal static I? Jl(byte? v)
        {
            return v is {} b ? new I(O.Jl, b) : null;
        }
        
        /// <summary>
        /// Jump on less or equal/not greater
        /// <remarks>JLE/JNG</remarks>
        /// </summary>
        internal static I? Jle(byte? v)
        {
            return v is { } b ? new I(O.Jle, b) : null;
        }

        /// <summary>
        /// Unconditional jump short/long
        /// <remarks>JMP</remarks>
        /// </summary>
        internal static I? Jmp(byte? low)
        {
            return low is { } l ? new I(O.Jmp, l) : null;
        }

        /// <summary>
        /// Unconditional jump direct within segment
        /// <remarks>JMP</remarks>
        /// </summary>
        internal static I? Jmp(byte? low, byte? high)
        {
            return low is { } l && high is { } h ? new I(O.Jmp, l, h) : null;
        }
        
        /// <summary>
        /// Jump on not below/above or equal
        /// <remarks>JNB/JAE</remarks>
        /// </summary>
        internal static I? Jnb(byte? v)
        {
            return v is { } b ? new I(O.Jnb, b) : null;
        }
        
        /// <summary>
        /// Jump on not overflow
        /// <remarks>JNO</remarks>
        /// </summary>
        internal static I? Jno(byte? v)
        {
            return v is { } b ? new I(O.Jno, b) : null;
        }
        
        /// <summary>
        /// Jump on not sign
        /// <remarks>JNS</remarks>
        /// </summary>
        internal static I? Jns(byte? v)
        {
            return v is { } b ? new I(O.Jns, b) : null;
        }
        
        /// <summary>
        /// Jump on not equal/not zero
        /// <remarks>JNE/JNZ</remarks>
        /// </summary>
        internal static I? Jnz(byte? v)
        {
            return v is { } b ? new I(O.Jnz, b) : null;
        }
        
        /// <summary>
        /// Jump on overflow
        /// <remarks>JO</remarks>
        /// </summary>
        internal static I? Jo(byte? v)
        {
            return v is { } b ? new I(O.Jo, b) : null;
        }
        
        /// <summary>
        /// Jump on parity/parity even
        /// <remarks>JP/JPE</remarks>
        /// </summary>
        internal static I? Jpe(byte? v)
        {
            return v is { } b ? new I(O.Jpe, b) : null;
        }
        
        /// <summary>
        /// Jump on not par/par odd
        /// <remarks>JNP/JPO</remarks>
        /// </summary>
        internal static I? Jpo(byte? v)
        {
            return v is { } b ? new I(O.Jpo, b) : null;
        }
        
        /// <summary>
        /// Jump on sign
        /// <remarks>JS</remarks>
        /// </summary>
        internal static I? Js(byte? v)
        {
            return v is { } b ? new I(O.Js, b) : null;
        }
        
        /// <summary>
        /// Jump on equal/zero
        /// <remarks>JE/JZ</remarks>
        /// </summary>
        internal static I? Jz(byte? v)
        {
            return v is { } b ? new I(O.Jz, b) : null;
        }
        
        /// <summary>
        /// Load AH with flags
        /// <remarks>LAHF</remarks>
        /// </summary>
        internal static I Lahf()
        {
            return new I(O.Lahf);
        }
        
        internal static I Lds(params A[] args)
        {
            return new I(O.Lds, args);
        }
        
        internal static I Lea(params A[] args)
        {
            return new I(O.Lea, args);
        }
        
        /// <summary>
        /// Leave procedure
        /// <remarks>LEAVE</remarks>
        /// </summary>
        internal static I Leave()
        {
            return new I(O.Leave);
        }
        
        internal static I Les(params A[] args)
        {
            return new I(O.Les, args);
        }
        
        /// <summary>
        /// Bus lock prefix
        /// <remarks>LOCK</remarks>
        /// </summary>
        internal static I Lock()
        {
            return new I(O.Lock);
        }
        
        /// <summary>
        /// Load byte to AL
        /// <remarks>LODSB</remarks>
        /// </summary>
        internal static I Lodsb()
        {
            return new I(O.Lodsb);
        }
        
        /// <summary>
        /// Load word to AX
        /// <remarks>LODSW</remarks>
        /// </summary>
        internal static I Lodsw()
        {
            return new I(O.Lodsw);
        }
        
        /// <summary>
        /// Loop CX times
        /// <remarks>LOOP</remarks>
        /// </summary>
        internal static I? Loop(byte? v)
        {
            return v is {} b ? new I(O.Loop, b) : null;
        }
        
        /// <summary>
        /// Loop while not zero/equal
        /// <remarks>LOOPNZ/LOOPNE</remarks>
        /// </summary>
        internal static I? Loopnz(byte? v)
        {
            return v is {} b ? new I(O.Loopnz, b) : null;
        }
        
        /// <summary>
        /// Loop while zero/equal
        /// <remarks>LOOPZ/LOOPE</remarks>
        /// </summary>
        internal static I? Loopz(byte? v)
        {
            return v is {} b? new I(O.Loopz, b) : null;
        }
        
        internal static I Mov(params A[] args)
        {
            return new I(O.Mov, args);
        }
        
        /// <summary>
        /// Move byte
        /// <remarks>MOVSB</remarks>
        /// </summary>
        internal static I Movsb()
        {
            return new I(O.Movsb);
        }
        
        /// <summary>
        /// Move word
        /// <remarks>MOVSW</remarks>
        /// </summary>
        internal static I Movsw()
        {
            return new I(O.Movsw);
        }
        
        internal static I Mul(params A[] args)
        {
            return new I(O.Mul, args);
        }
        
        internal static I Neg(params A[] args)
        {
            return new I(O.Neg, args);
        }
        
        /// <summary>
        /// No operation
        /// </summary>
        internal static I Nop()
        {
            return new I(O.Nop);
        }
        
        internal static I Not(params A[] args)
        {
            return new I(O.Not, args);
        }
        
        internal static I Or(params A[] args)
        {
            return new I(O.Or, args);
        }
        
        internal static I Out(params A[] args)
        {
            return new I(O.Out, args);
        }
        
        /// <summary>
        /// Output byte to DX port
        /// <remarks>OUTSB</remarks>
        /// </summary>
        internal static I Outsb()
        {
            return new I(O.Outsb);
        }
        
        /// <summary>
        /// Output word to DX port
        /// <remarks>OUTSW</remarks>
        /// </summary>
        internal static I Outsw()
        {
            return new I(O.Outsw);
        }
        
        internal static I Pop(params A[] args)
        {
            return new I(O.Pop, args);
        }
        
        /// <summary>
        /// Pop all
        /// <remarks>POPA</remarks>
        /// </summary>
        internal static I Popa()
        {
            return new I(O.Popa);
        }
        
        /// <summary>
        /// Pop flags
        /// <remarks>POPF</remarks>
        /// </summary>
        internal static I Popf()
        {
            return new I(O.Popf);
        }
        
        internal static I Push(params A[] args)
        {
            return new I(O.Push, args);
        }
        
        /// <summary>
        /// Push all
        /// <remarks>PUSHA</remarks>
        /// </summary>
        internal static I Pusha()
        {
            return new I(O.Pusha);
        }
        
        /// <summary>
        /// Push flags
        /// <remarks>PUSHF</remarks>
        /// </summary>
        internal static I Pushf()
        {
            return new I(O.Pushf);
        }
        
        internal static I Rcl(params A[] args)
        {
            return new I(O.Rcl, args);
        }
        
        internal static I Rcr(params A[] args)
        {
            return new I(O.Rcr, args);
        }
        
        internal static I Repe(params A[] args)
        {
            return new I(O.Repe, args);
        }
        
        internal static I Repne(params A[] args)
        {
            return new I(O.Repne, args);
        }
        
        /// <summary>
        /// Return from call within segment
        /// </summary>
        internal static I Ret()
        {
            return new I(O.Ret);
        }
        
        /// <summary>
        /// Return from call within segment adding imm to SP
        /// </summary>
        internal static I? Ret(byte? low, byte? high)
        {
            return low is { } l && high is { } h ? new I(O.Ret, l, h) : null;
        }
        
        /// <summary>
        /// Return from call within intersegment
        /// </summary>
        internal static I Retf()
        {
            return new I(O.Retf);
        }
        
        /// <summary>
        /// Return from call within intersegment adding imm to SP
        /// </summary>
        internal static I? Retf(byte? low, byte? high)
        {
            return low is {} l && high is { } h ? new I(O.Retf, l, h) : null;
        }
        
        internal static I Rol(params A[] args)
        {
            return new I(O.Rol, args);
        }
        
        internal static I Ror(params A[] args)
        {
            return new I(O.Ror, args);
        }
        
        /// <summary>
        /// Store AH into flags
        /// <remarks>SAHF</remarks>
        /// </summary>
        internal static I Sahf()
        {
            return new I(O.Sahf);
        }
        
        internal static I Sar(params A[] args)
        {
            return new I(O.Sar, args);
        }
        
        internal static I Sbb(params A[] args)
        {
            return new I(O.Sbb, args);
        }
        
        /// <summary>
        /// Scan byte
        /// <remarks>SCASB</remarks>
        /// </summary>
        internal static I Scasb()
        {
            return new I(O.Scasb);
        }
        
        /// <summary>
        /// Scan word
        /// <remarks>SCASW</remarks>
        /// </summary>
        internal static I Scasw()
        {
            return new I(O.Scasw);
        }
        
        internal static I Shl(params A[] args)
        {
            return new I(O.Shl, args);
        }
        
        internal static I Shr(params A[] args)
        {
            return new I(O.Shr, args);
        }
        
        /// <summary>
        /// SS: override
        /// <remarks>SS</remarks>
        /// </summary>
        internal static I Ss()
        {
            return new I(O.Ss);
        }
        
        /// <summary>
        /// Set carry
        /// </summary>
        internal static I Stc()
        {
            return new I(O.Stc);
        }
        
        /// <summary>
        /// Set direction
        /// </summary>
        internal static I Std()
        {
            return new I(O.Std);
        }
        
        /// <summary>
        /// Set interrupt
        /// </summary>
        internal static I Sti()
        {
            return new I(O.Sti);
        }
        
        /// <summary>
        /// Store byte from AL
        /// <remarks>STOSB</remarks>
        /// </summary>
        internal static I Stosb()
        {
            return new I(O.Stosb);
        }
        
        /// <summary>
        /// Store word from AX
        /// <remarks>STOSW</remarks>
        /// </summary>
        internal static I Stosw()
        {
            return new I(O.Stosw);
        }
        
        internal static I Sub(params A[] args)
        {
            return new I(O.Sub, args);
        }
        
        internal static I Test(params A[] args)
        {
            return new I(O.Test, args);
        }
        
        /// <summary>
        /// Wait
        /// </summary>
        internal static I Wait()
        {
            return new I(O.Wait);
        }
        
        internal static I Xchg(params A[] args)
        {
            return new I(O.Xchg, args);
        }
        
        /// <summary>
        /// Translate byte to AL
        /// <remarks>XLAT/XLATB</remarks>
        /// </summary>
        internal static I Xlat()
        {
            return new I(O.Xlat);
        }
        
        internal static I Xor(params A[] args)
        {
            return new I(O.Xor, args);
        }
    }
}
