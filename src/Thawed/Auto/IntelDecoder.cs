using System;
using Thawed.Auto;
using I = Thawed.Auto.Instruct;
using R = Thawed.Register;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming

namespace Thawed.Auto
{
    /// <summary>
    /// Decoder for Intel
    /// </summary>
    internal sealed class IntelDecoder : IDecoder
    {
        public Instruction? Decode(IByteReader r, bool fail)
        {
            byte b0 = 0;
            
            var i = (b0 = r.ReadOne()) switch
            {
                0x06 => I.Push(R.es),
                0x07 => I.Pop(R.es),
                0x0E => I.Push(R.cs),
                0x16 => I.Push(R.ss),
                0x17 => I.Pop(R.ss),
                0x1E => I.Push(R.ds),
                0x1F => I.Pop(R.ds),
                0x27 => I.Daa(),
                0x2F => I.Das(),
                0x37 => I.Aaa(),
                0x3F => I.Aas(),
                0x40 => I.Inc(R.ax),
                0x41 => I.Inc(R.cx),
                0x42 => I.Inc(R.dx),
                0x43 => I.Inc(R.bx),
                0x44 => I.Inc(R.sp),
                0x45 => I.Inc(R.bp),
                0x46 => I.Inc(R.si),
                0x47 => I.Inc(R.di),
                0x48 => I.Dec(R.ax),
                0x49 => I.Dec(R.cx),
                0x4A => I.Dec(R.dx),
                0x4B => I.Dec(R.bx),
                0x4C => I.Dec(R.sp),
                0x4D => I.Dec(R.bp),
                0x4E => I.Dec(R.si),
                0x4F => I.Dec(R.di),
                0x50 => I.Push(R.ax),
                0x51 => I.Push(R.cx),
                0x52 => I.Push(R.dx),
                0x53 => I.Push(R.bx),
                0x54 => I.Push(R.sp),
                0x55 => I.Push(R.bp),
                0x56 => I.Push(R.si),
                0x57 => I.Push(R.di),
                0x58 => I.Pop(R.ax),
                0x59 => I.Pop(R.cx),
                0x5A => I.Pop(R.dx),
                0x5B => I.Pop(R.bx),
                0x5C => I.Pop(R.sp),
                0x5D => I.Pop(R.bp),
                0x5E => I.Pop(R.si),
                0x5F => I.Pop(R.di),
                0x60 => I.Pusha(),
                0x61 => I.Popa(),
                0x6C => I.Insb(),
                0x6D => I.Insw(),
                0x6E => I.Outsb(),
                0x6F => I.Outsw(),
                0x90 => I.Nop(),
                0x91 => I.Xchg(R.ax, R.cx),
                0x92 => I.Xchg(R.ax, R.dx),
                0x93 => I.Xchg(R.ax, R.bx),
                0x94 => I.Xchg(R.ax, R.sp),
                0x95 => I.Xchg(R.ax, R.bp),
                0x96 => I.Xchg(R.ax, R.si),
                0x97 => I.Xchg(R.ax, R.di),
                0x98 => I.Cbw(),
                0x99 => I.Cwd(),
                0x9B => I.Wait(),
                0x9C => I.Pushf(),
                0x9D => I.Popf(),
                0x9E => I.Sahf(),
                0x9F => I.Lahf(),
                0xA4 => I.Movsb(),
                0xA5 => I.Movsw(),
                0xA6 => I.Cmpsb(),
                0xA7 => I.Cmpsw(),
                0xAA => I.Stosb(),
                0xAB => I.Stosw(),
                0xAC => I.Lodsb(),
                0xAD => I.Lodsw(),
                0xAE => I.Scasb(),
                0xAF => I.Scasw(),
                0xC3 => I.Ret(),
                0xC9 => I.Leave(),
                0xCB => I.Retf(),
                0xCC => I.Int3(),
                0xCE => I.Into(),
                0xCF => I.Iret(),
                0xD7 => I.Xlat(),
                0xEC => I.In(R.al, R.dx),
                0xED => I.In(R.ax, R.dx),
                0xEE => I.Out(R.dx, R.al),
                0xEF => I.Out(R.dx, R.ax),
                0xF0 => I.Lock(),
                0xF2 => I.Repne(),
                0xF3 => I.Repe(),
                0xF4 => I.Hlt(),
                0xF5 => I.Cmc(),
                0xF8 => I.Clc(),
                0xF9 => I.Stc(),
                0xFA => I.Cli(),
                0xFB => I.Sti(),
                0xFC => I.Cld(),
                0xFD => I.Std(),
                _ => null
            };
            
            return fail ? throw new DecodeException(b0) : i;
        }
    }
}
