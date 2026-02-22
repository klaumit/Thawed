using System;
using Thawed.Auto;
using I = Thawed.Instruction;
using H = Thawed.InstructH;
using O = Thawed.Auto.Opcode;
using A = Thawed.Args.Arg;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed.Auto
{
    internal static class Instruct
    {
        internal static I Aaa(params A[] args)
        {
            return new I(O.Aaa, args);
        }
        
        internal static I Aad(params A[] args)
        {
            return new I(O.Aad, args);
        }
        
        internal static I Aam(params A[] args)
        {
            return new I(O.Aam, args);
        }
        
        internal static I Aas(params A[] args)
        {
            return new I(O.Aas, args);
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
        
        internal static I Call(params A[] args)
        {
            return new I(O.Call, args);
        }
        
        internal static I Cbw(params A[] args)
        {
            return new I(O.Cbw, args);
        }
        
        internal static I Clc(params A[] args)
        {
            return new I(O.Clc, args);
        }
        
        internal static I Cld(params A[] args)
        {
            return new I(O.Cld, args);
        }
        
        internal static I Cli(params A[] args)
        {
            return new I(O.Cli, args);
        }
        
        internal static I Cmc(params A[] args)
        {
            return new I(O.Cmc, args);
        }
        
        internal static I Cmp(params A[] args)
        {
            return new I(O.Cmp, args);
        }
        
        internal static I Cmpsb(params A[] args)
        {
            return new I(O.Cmpsb, args);
        }
        
        internal static I Cmpsw(params A[] args)
        {
            return new I(O.Cmpsw, args);
        }
        
        internal static I Cs(params A[] args)
        {
            return new I(O.Cs, args);
        }
        
        internal static I Cwd(params A[] args)
        {
            return new I(O.Cwd, args);
        }
        
        internal static I Daa(params A[] args)
        {
            return new I(O.Daa, args);
        }
        
        internal static I Das(params A[] args)
        {
            return new I(O.Das, args);
        }
        
        internal static I Dec(params A[] args)
        {
            return new I(O.Dec, args);
        }
        
        internal static I Div(params A[] args)
        {
            return new I(O.Div, args);
        }
        
        internal static I Ds(params A[] args)
        {
            return new I(O.Ds, args);
        }
        
        internal static I Enter(params A[] args)
        {
            return new I(O.Enter, args);
        }
        
        internal static I Es(params A[] args)
        {
            return new I(O.Es, args);
        }
        
        internal static I Hlt(params A[] args)
        {
            return new I(O.Hlt, args);
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
        
        internal static I Insb(params A[] args)
        {
            return new I(O.Insb, args);
        }
        
        internal static I Insw(params A[] args)
        {
            return new I(O.Insw, args);
        }
        
        internal static I Int(params A[] args)
        {
            return new I(O.Int, args);
        }
        
        internal static I Int3(params A[] args)
        {
            return new I(O.Int3, args);
        }
        
        internal static I Into(params A[] args)
        {
            return new I(O.Into, args);
        }
        
        internal static I Iret(params A[] args)
        {
            return new I(O.Iret, args);
        }
        
        internal static I Ja(params A[] args)
        {
            return new I(O.Ja, args);
        }
        
        internal static I Jbe(params A[] args)
        {
            return new I(O.Jbe, args);
        }
        
        internal static I Jc(params A[] args)
        {
            return new I(O.Jc, args);
        }
        
        internal static I Jcxz(params A[] args)
        {
            return new I(O.Jcxz, args);
        }
        
        internal static I Jg(params A[] args)
        {
            return new I(O.Jg, args);
        }
        
        internal static I Jge(params A[] args)
        {
            return new I(O.Jge, args);
        }
        
        internal static I Jl(params A[] args)
        {
            return new I(O.Jl, args);
        }
        
        internal static I Jle(params A[] args)
        {
            return new I(O.Jle, args);
        }
        
        internal static I Jmp(params A[] args)
        {
            return new I(O.Jmp, args);
        }
        
        internal static I Jnc(params A[] args)
        {
            return new I(O.Jnc, args);
        }
        
        internal static I Jno(params A[] args)
        {
            return new I(O.Jno, args);
        }
        
        internal static I Jnp(params A[] args)
        {
            return new I(O.Jnp, args);
        }
        
        internal static I Jns(params A[] args)
        {
            return new I(O.Jns, args);
        }
        
        internal static I Jnz(params A[] args)
        {
            return new I(O.Jnz, args);
        }
        
        internal static I Jo(params A[] args)
        {
            return new I(O.Jo, args);
        }
        
        internal static I Jp(params A[] args)
        {
            return new I(O.Jp, args);
        }
        
        internal static I Js(params A[] args)
        {
            return new I(O.Js, args);
        }
        
        internal static I Jz(params A[] args)
        {
            return new I(O.Jz, args);
        }
        
        internal static I Lahf(params A[] args)
        {
            return new I(O.Lahf, args);
        }
        
        internal static I Lds(params A[] args)
        {
            return new I(O.Lds, args);
        }
        
        internal static I Lea(params A[] args)
        {
            return new I(O.Lea, args);
        }
        
        internal static I Leave(params A[] args)
        {
            return new I(O.Leave, args);
        }
        
        internal static I Les(params A[] args)
        {
            return new I(O.Les, args);
        }
        
        internal static I Lock(params A[] args)
        {
            return new I(O.Lock, args);
        }
        
        internal static I Lodsb(params A[] args)
        {
            return new I(O.Lodsb, args);
        }
        
        internal static I Lodsw(params A[] args)
        {
            return new I(O.Lodsw, args);
        }
        
        internal static I Loop(params A[] args)
        {
            return new I(O.Loop, args);
        }
        
        internal static I Loope(params A[] args)
        {
            return new I(O.Loope, args);
        }
        
        internal static I Loopne(params A[] args)
        {
            return new I(O.Loopne, args);
        }
        
        internal static I Mov(params A[] args)
        {
            return new I(O.Mov, args);
        }
        
        internal static I Movsb(params A[] args)
        {
            return new I(O.Movsb, args);
        }
        
        internal static I Movsw(params A[] args)
        {
            return new I(O.Movsw, args);
        }
        
        internal static I Mul(params A[] args)
        {
            return new I(O.Mul, args);
        }
        
        internal static I Neg(params A[] args)
        {
            return new I(O.Neg, args);
        }
        
        internal static I Nop(params A[] args)
        {
            return new I(O.Nop, args);
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
        
        internal static I Outsb(params A[] args)
        {
            return new I(O.Outsb, args);
        }
        
        internal static I Outsw(params A[] args)
        {
            return new I(O.Outsw, args);
        }
        
        internal static I Pop(params A[] args)
        {
            return new I(O.Pop, args);
        }
        
        internal static I Popa(params A[] args)
        {
            return new I(O.Popa, args);
        }
        
        internal static I Popf(params A[] args)
        {
            return new I(O.Popf, args);
        }
        
        internal static I Push(params A[] args)
        {
            return new I(O.Push, args);
        }
        
        internal static I Pusha(params A[] args)
        {
            return new I(O.Pusha, args);
        }
        
        internal static I Pushf(params A[] args)
        {
            return new I(O.Pushf, args);
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
        
        internal static I Ret(params A[] args)
        {
            return new I(O.Ret, args);
        }
        
        internal static I Retf(params A[] args)
        {
            return new I(O.Retf, args);
        }
        
        internal static I Rol(params A[] args)
        {
            return new I(O.Rol, args);
        }
        
        internal static I Ror(params A[] args)
        {
            return new I(O.Ror, args);
        }
        
        internal static I Sahf(params A[] args)
        {
            return new I(O.Sahf, args);
        }
        
        internal static I Sar(params A[] args)
        {
            return new I(O.Sar, args);
        }
        
        internal static I Sbb(params A[] args)
        {
            return new I(O.Sbb, args);
        }
        
        internal static I Scasb(params A[] args)
        {
            return new I(O.Scasb, args);
        }
        
        internal static I Scasw(params A[] args)
        {
            return new I(O.Scasw, args);
        }
        
        internal static I Shl(params A[] args)
        {
            return new I(O.Shl, args);
        }
        
        internal static I Shr(params A[] args)
        {
            return new I(O.Shr, args);
        }
        
        internal static I Ss(params A[] args)
        {
            return new I(O.Ss, args);
        }
        
        internal static I Stc(params A[] args)
        {
            return new I(O.Stc, args);
        }
        
        internal static I Std(params A[] args)
        {
            return new I(O.Std, args);
        }
        
        internal static I Sti(params A[] args)
        {
            return new I(O.Sti, args);
        }
        
        internal static I Stosb(params A[] args)
        {
            return new I(O.Stosb, args);
        }
        
        internal static I Stosw(params A[] args)
        {
            return new I(O.Stosw, args);
        }
        
        internal static I Sub(params A[] args)
        {
            return new I(O.Sub, args);
        }
        
        internal static I Test(params A[] args)
        {
            return new I(O.Test, args);
        }
        
        internal static I Wait(params A[] args)
        {
            return new I(O.Wait, args);
        }
        
        internal static I Xchg(params A[] args)
        {
            return new I(O.Xchg, args);
        }
        
        internal static I Xlat(params A[] args)
        {
            return new I(O.Xlat, args);
        }
        
        internal static I Xor(params A[] args)
        {
            return new I(O.Xor, args);
        }
    }
}
