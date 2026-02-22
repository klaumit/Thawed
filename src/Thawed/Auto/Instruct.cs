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
        internal static I Aaa()
        {
            return new I(O.Aaa);
        }
        
        internal static I Aad()
        {
            return new I(O.Aad);
        }
        
        internal static I Aam()
        {
            return new I(O.Aam);
        }
        
        internal static I Aas()
        {
            return new I(O.Aas);
        }
        
        internal static I Adc()
        {
             // 14
            return new I(O.Adc);
        }
        
        internal static I Add()
        {
             // 14
            return new I(O.Add);
        }
        
        internal static I And()
        {
             // 14
            return new I(O.And);
        }
        
        internal static I Bound()
        {
            return new I(O.Bound);
        }
        
        internal static I Call()
        {
             // 5
            return new I(O.Call);
        }
        
        internal static I Cbw()
        {
            return new I(O.Cbw);
        }
        
        internal static I Clc()
        {
            return new I(O.Clc);
        }
        
        internal static I Cld()
        {
            return new I(O.Cld);
        }
        
        internal static I Cli()
        {
            return new I(O.Cli);
        }
        
        internal static I Cmc()
        {
            return new I(O.Cmc);
        }
        
        internal static I Cmp()
        {
             // 14
            return new I(O.Cmp);
        }
        
        internal static I Cmpsb()
        {
            return new I(O.Cmpsb);
        }
        
        internal static I Cmpsw()
        {
            return new I(O.Cmpsw);
        }
        
        internal static I Cs()
        {
            return new I(O.Cs);
        }
        
        internal static I Cwd()
        {
            return new I(O.Cwd);
        }
        
        internal static I Daa()
        {
            return new I(O.Daa);
        }
        
        internal static I Das()
        {
            return new I(O.Das);
        }
        
        internal static I Dec()
        {
             // 4
            return new I(O.Dec);
        }
        
        internal static I Div()
        {
             // 4
            return new I(O.Div);
        }
        
        internal static I Ds()
        {
            return new I(O.Ds);
        }
        
        internal static I Enter()
        {
            return new I(O.Enter);
        }
        
        internal static I Es()
        {
            return new I(O.Es);
        }
        
        internal static I Hlt()
        {
            return new I(O.Hlt);
        }
        
        internal static I Idiv()
        {
             // 4
            return new I(O.Idiv);
        }
        
        internal static I Imul()
        {
             // 8
            return new I(O.Imul);
        }
        
        internal static I In()
        {
             // 4
            return new I(O.In);
        }
        
        internal static I Inc()
        {
             // 4
            return new I(O.Inc);
        }
        
        internal static I Insb()
        {
            return new I(O.Insb);
        }
        
        internal static I Insw()
        {
            return new I(O.Insw);
        }
        
        internal static I Int()
        {
             // 2
            return new I(O.Int);
        }
        
        internal static I Into()
        {
            return new I(O.Into);
        }
        
        internal static I Iret()
        {
            return new I(O.Iret);
        }
        
        internal static I Ja()
        {
            return new I(O.Ja);
        }
        
        internal static I Jbe()
        {
            return new I(O.Jbe);
        }
        
        internal static I Jc()
        {
            return new I(O.Jc);
        }
        
        internal static I Jcxz()
        {
            return new I(O.Jcxz);
        }
        
        internal static I Jg()
        {
            return new I(O.Jg);
        }
        
        internal static I Jge()
        {
            return new I(O.Jge);
        }
        
        internal static I Jl()
        {
            return new I(O.Jl);
        }
        
        internal static I Jle()
        {
            return new I(O.Jle);
        }
        
        internal static I Jmp()
        {
             // 6
            return new I(O.Jmp);
        }
        
        internal static I Jnc()
        {
            return new I(O.Jnc);
        }
        
        internal static I Jno()
        {
            return new I(O.Jno);
        }
        
        internal static I Jnp()
        {
            return new I(O.Jnp);
        }
        
        internal static I Jns()
        {
            return new I(O.Jns);
        }
        
        internal static I Jnz()
        {
            return new I(O.Jnz);
        }
        
        internal static I Jo()
        {
            return new I(O.Jo);
        }
        
        internal static I Jp()
        {
            return new I(O.Jp);
        }
        
        internal static I Js()
        {
            return new I(O.Js);
        }
        
        internal static I Jz()
        {
            return new I(O.Jz);
        }
        
        internal static I Lahf()
        {
            return new I(O.Lahf);
        }
        
        internal static I Lds()
        {
            return new I(O.Lds);
        }
        
        internal static I Lea()
        {
            return new I(O.Lea);
        }
        
        internal static I Leave()
        {
            return new I(O.Leave);
        }
        
        internal static I Les()
        {
            return new I(O.Les);
        }
        
        internal static I Lock()
        {
            return new I(O.Lock);
        }
        
        internal static I Lodsb()
        {
            return new I(O.Lodsb);
        }
        
        internal static I Lodsw()
        {
            return new I(O.Lodsw);
        }
        
        internal static I Loop()
        {
            return new I(O.Loop);
        }
        
        internal static I Loope()
        {
            return new I(O.Loope);
        }
        
        internal static I Loopne()
        {
            return new I(O.Loopne);
        }
        
        internal static I Mov()
        {
             // 20
            return new I(O.Mov);
        }
        
        internal static I Movsb()
        {
            return new I(O.Movsb);
        }
        
        internal static I Movsw()
        {
            return new I(O.Movsw);
        }
        
        internal static I Mul()
        {
             // 4
            return new I(O.Mul);
        }
        
        internal static I Neg()
        {
             // 4
            return new I(O.Neg);
        }
        
        internal static I Nop()
        {
            return new I(O.Nop);
        }
        
        internal static I Not()
        {
             // 4
            return new I(O.Not);
        }
        
        internal static I Or()
        {
             // 14
            return new I(O.Or);
        }
        
        internal static I Out()
        {
             // 4
            return new I(O.Out);
        }
        
        internal static I Outsb()
        {
            return new I(O.Outsb);
        }
        
        internal static I Outsw()
        {
            return new I(O.Outsw);
        }
        
        internal static I Pop()
        {
             // 4
            return new I(O.Pop);
        }
        
        internal static I Popa()
        {
            return new I(O.Popa);
        }
        
        internal static I Popf()
        {
            return new I(O.Popf);
        }
        
        internal static I Push()
        {
             // 6
            return new I(O.Push);
        }
        
        internal static I Pusha()
        {
            return new I(O.Pusha);
        }
        
        internal static I Pushf()
        {
            return new I(O.Pushf);
        }
        
        internal static I Rcl()
        {
             // 12
            return new I(O.Rcl);
        }
        
        internal static I Rcr()
        {
             // 12
            return new I(O.Rcr);
        }
        
        internal static I Rep()
        {
            return new I(O.Rep);
        }
        
        internal static I Repne()
        {
            return new I(O.Repne);
        }
        
        internal static I Ret()
        {
             // 2
            return new I(O.Ret);
        }
        
        internal static I Retf()
        {
             // 2
            return new I(O.Retf);
        }
        
        internal static I Rol()
        {
             // 12
            return new I(O.Rol);
        }
        
        internal static I Ror()
        {
             // 12
            return new I(O.Ror);
        }
        
        internal static I Sahf()
        {
            return new I(O.Sahf);
        }
        
        internal static I Sar()
        {
             // 12
            return new I(O.Sar);
        }
        
        internal static I Sbb()
        {
             // 14
            return new I(O.Sbb);
        }
        
        internal static I Scasb()
        {
            return new I(O.Scasb);
        }
        
        internal static I Scasw()
        {
            return new I(O.Scasw);
        }
        
        internal static I Shl()
        {
             // 12
            return new I(O.Shl);
        }
        
        internal static I Shr()
        {
             // 12
            return new I(O.Shr);
        }
        
        internal static I Ss()
        {
            return new I(O.Ss);
        }
        
        internal static I Stc()
        {
            return new I(O.Stc);
        }
        
        internal static I Std()
        {
            return new I(O.Std);
        }
        
        internal static I Sti()
        {
            return new I(O.Sti);
        }
        
        internal static I Stosb()
        {
            return new I(O.Stosb);
        }
        
        internal static I Stosw()
        {
            return new I(O.Stosw);
        }
        
        internal static I Sub()
        {
             // 14
            return new I(O.Sub);
        }
        
        internal static I Test()
        {
             // 10
            return new I(O.Test);
        }
        
        internal static I Wait()
        {
            return new I(O.Wait);
        }
        
        internal static I Xchg()
        {
             // 5
            return new I(O.Xchg);
        }
        
        internal static I Xlat()
        {
            return new I(O.Xlat);
        }
        
        internal static I Xor()
        {
             // 14
            return new I(O.Xor);
        }
    }
}
