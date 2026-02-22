using System;
using Thawed.Auto;
using I = Thawed.Instruction;
using H = Thawed.InstructH;
using O = Thawed.Auto.Opcode;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed.Auto
{
    internal static class Instruct
    {
        internal static Instruction Aaa()
        {
             // 1
            return new I(O.Aaa);
        }
        
        internal static Instruction Aad()
        {
             // 1
            return new I(O.Aad);
        }
        
        internal static Instruction Aam()
        {
             // 1
            return new I(O.Aam);
        }
        
        internal static Instruction Aas()
        {
             // 1
            return new I(O.Aas);
        }
        
        internal static Instruction Adc()
        {
             // 14
            return new I(O.Adc);
        }
        
        internal static Instruction Add()
        {
             // 14
            return new I(O.Add);
        }
        
        internal static Instruction And()
        {
             // 14
            return new I(O.And);
        }
        
        internal static Instruction Bound()
        {
             // 1
            return new I(O.Bound);
        }
        
        internal static Instruction Call()
        {
             // 5
            return new I(O.Call);
        }
        
        internal static Instruction Cbw()
        {
             // 1
            return new I(O.Cbw);
        }
        
        internal static Instruction Clc()
        {
             // 1
            return new I(O.Clc);
        }
        
        internal static Instruction Cld()
        {
             // 1
            return new I(O.Cld);
        }
        
        internal static Instruction Cli()
        {
             // 1
            return new I(O.Cli);
        }
        
        internal static Instruction Cmc()
        {
             // 1
            return new I(O.Cmc);
        }
        
        internal static Instruction Cmp()
        {
             // 14
            return new I(O.Cmp);
        }
        
        internal static Instruction Cmpsb()
        {
             // 1
            return new I(O.Cmpsb);
        }
        
        internal static Instruction Cmpsw()
        {
             // 1
            return new I(O.Cmpsw);
        }
        
        internal static Instruction Cs()
        {
             // 1
            return new I(O.Cs);
        }
        
        internal static Instruction Cwd()
        {
             // 1
            return new I(O.Cwd);
        }
        
        internal static Instruction Daa()
        {
             // 1
            return new I(O.Daa);
        }
        
        internal static Instruction Das()
        {
             // 1
            return new I(O.Das);
        }
        
        internal static Instruction Dec()
        {
             // 4
            return new I(O.Dec);
        }
        
        internal static Instruction Div()
        {
             // 4
            return new I(O.Div);
        }
        
        internal static Instruction Ds()
        {
             // 1
            return new I(O.Ds);
        }
        
        internal static Instruction Enter()
        {
             // 1
            return new I(O.Enter);
        }
        
        internal static Instruction Es()
        {
             // 1
            return new I(O.Es);
        }
        
        internal static Instruction Hlt()
        {
             // 1
            return new I(O.Hlt);
        }
        
        internal static Instruction Idiv()
        {
             // 4
            return new I(O.Idiv);
        }
        
        internal static Instruction Imul()
        {
             // 8
            return new I(O.Imul);
        }
        
        internal static Instruction In()
        {
             // 4
            return new I(O.In);
        }
        
        internal static Instruction Inc()
        {
             // 4
            return new I(O.Inc);
        }
        
        internal static Instruction Insb()
        {
             // 1
            return new I(O.Insb);
        }
        
        internal static Instruction Insw()
        {
             // 1
            return new I(O.Insw);
        }
        
        internal static Instruction Int()
        {
             // 2
            return new I(O.Int);
        }
        
        internal static Instruction Into()
        {
             // 1
            return new I(O.Into);
        }
        
        internal static Instruction Iret()
        {
             // 1
            return new I(O.Iret);
        }
        
        internal static Instruction Ja()
        {
             // 1
            return new I(O.Ja);
        }
        
        internal static Instruction Jbe()
        {
             // 1
            return new I(O.Jbe);
        }
        
        internal static Instruction Jc()
        {
             // 1
            return new I(O.Jc);
        }
        
        internal static Instruction Jcxz()
        {
             // 1
            return new I(O.Jcxz);
        }
        
        internal static Instruction Jg()
        {
             // 1
            return new I(O.Jg);
        }
        
        internal static Instruction Jge()
        {
             // 1
            return new I(O.Jge);
        }
        
        internal static Instruction Jl()
        {
             // 1
            return new I(O.Jl);
        }
        
        internal static Instruction Jle()
        {
             // 1
            return new I(O.Jle);
        }
        
        internal static Instruction Jmp()
        {
             // 6
            return new I(O.Jmp);
        }
        
        internal static Instruction Jnc()
        {
             // 1
            return new I(O.Jnc);
        }
        
        internal static Instruction Jno()
        {
             // 1
            return new I(O.Jno);
        }
        
        internal static Instruction Jnp()
        {
             // 1
            return new I(O.Jnp);
        }
        
        internal static Instruction Jns()
        {
             // 1
            return new I(O.Jns);
        }
        
        internal static Instruction Jnz()
        {
             // 1
            return new I(O.Jnz);
        }
        
        internal static Instruction Jo()
        {
             // 1
            return new I(O.Jo);
        }
        
        internal static Instruction Jp()
        {
             // 1
            return new I(O.Jp);
        }
        
        internal static Instruction Js()
        {
             // 1
            return new I(O.Js);
        }
        
        internal static Instruction Jz()
        {
             // 1
            return new I(O.Jz);
        }
        
        internal static Instruction Lahf()
        {
             // 1
            return new I(O.Lahf);
        }
        
        internal static Instruction Lds()
        {
             // 1
            return new I(O.Lds);
        }
        
        internal static Instruction Lea()
        {
             // 1
            return new I(O.Lea);
        }
        
        internal static Instruction Leave()
        {
             // 1
            return new I(O.Leave);
        }
        
        internal static Instruction Les()
        {
             // 1
            return new I(O.Les);
        }
        
        internal static Instruction Lock()
        {
             // 1
            return new I(O.Lock);
        }
        
        internal static Instruction Lodsb()
        {
             // 1
            return new I(O.Lodsb);
        }
        
        internal static Instruction Lodsw()
        {
             // 1
            return new I(O.Lodsw);
        }
        
        internal static Instruction Loop()
        {
             // 1
            return new I(O.Loop);
        }
        
        internal static Instruction Loope()
        {
             // 1
            return new I(O.Loope);
        }
        
        internal static Instruction Loopne()
        {
             // 1
            return new I(O.Loopne);
        }
        
        internal static Instruction Mov()
        {
             // 20
            return new I(O.Mov);
        }
        
        internal static Instruction Movsb()
        {
             // 1
            return new I(O.Movsb);
        }
        
        internal static Instruction Movsw()
        {
             // 1
            return new I(O.Movsw);
        }
        
        internal static Instruction Mul()
        {
             // 4
            return new I(O.Mul);
        }
        
        internal static Instruction Neg()
        {
             // 4
            return new I(O.Neg);
        }
        
        internal static Instruction Nop()
        {
             // 1
            return new I(O.Nop);
        }
        
        internal static Instruction Not()
        {
             // 4
            return new I(O.Not);
        }
        
        internal static Instruction Or()
        {
             // 14
            return new I(O.Or);
        }
        
        internal static Instruction Out()
        {
             // 4
            return new I(O.Out);
        }
        
        internal static Instruction Outsb()
        {
             // 1
            return new I(O.Outsb);
        }
        
        internal static Instruction Outsw()
        {
             // 1
            return new I(O.Outsw);
        }
        
        internal static Instruction Pop()
        {
             // 4
            return new I(O.Pop);
        }
        
        internal static Instruction Popa()
        {
             // 1
            return new I(O.Popa);
        }
        
        internal static Instruction Popf()
        {
             // 1
            return new I(O.Popf);
        }
        
        internal static Instruction Push()
        {
             // 6
            return new I(O.Push);
        }
        
        internal static Instruction Pusha()
        {
             // 1
            return new I(O.Pusha);
        }
        
        internal static Instruction Pushf()
        {
             // 1
            return new I(O.Pushf);
        }
        
        internal static Instruction Rcl()
        {
             // 12
            return new I(O.Rcl);
        }
        
        internal static Instruction Rcr()
        {
             // 12
            return new I(O.Rcr);
        }
        
        internal static Instruction Rep()
        {
             // 1
            return new I(O.Rep);
        }
        
        internal static Instruction Repne()
        {
             // 1
            return new I(O.Repne);
        }
        
        internal static Instruction Ret()
        {
             // 2
            return new I(O.Ret);
        }
        
        internal static Instruction Retf()
        {
             // 2
            return new I(O.Retf);
        }
        
        internal static Instruction Rol()
        {
             // 12
            return new I(O.Rol);
        }
        
        internal static Instruction Ror()
        {
             // 12
            return new I(O.Ror);
        }
        
        internal static Instruction Sahf()
        {
             // 1
            return new I(O.Sahf);
        }
        
        internal static Instruction Sar()
        {
             // 12
            return new I(O.Sar);
        }
        
        internal static Instruction Sbb()
        {
             // 14
            return new I(O.Sbb);
        }
        
        internal static Instruction Scasb()
        {
             // 1
            return new I(O.Scasb);
        }
        
        internal static Instruction Scasw()
        {
             // 1
            return new I(O.Scasw);
        }
        
        internal static Instruction Shl()
        {
             // 12
            return new I(O.Shl);
        }
        
        internal static Instruction Shr()
        {
             // 12
            return new I(O.Shr);
        }
        
        internal static Instruction Ss()
        {
             // 1
            return new I(O.Ss);
        }
        
        internal static Instruction Stc()
        {
             // 1
            return new I(O.Stc);
        }
        
        internal static Instruction Std()
        {
             // 1
            return new I(O.Std);
        }
        
        internal static Instruction Sti()
        {
             // 1
            return new I(O.Sti);
        }
        
        internal static Instruction Stosb()
        {
             // 1
            return new I(O.Stosb);
        }
        
        internal static Instruction Stosw()
        {
             // 1
            return new I(O.Stosw);
        }
        
        internal static Instruction Sub()
        {
             // 14
            return new I(O.Sub);
        }
        
        internal static Instruction Test()
        {
             // 10
            return new I(O.Test);
        }
        
        internal static Instruction Wait()
        {
             // 1
            return new I(O.Wait);
        }
        
        internal static Instruction Xchg()
        {
             // 5
            return new I(O.Xchg);
        }
        
        internal static Instruction Xlat()
        {
             // 1
            return new I(O.Xlat);
        }
        
        internal static Instruction Xor()
        {
             // 14
            return new I(O.Xor);
        }
    }
}
