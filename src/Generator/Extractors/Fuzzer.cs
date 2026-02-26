using System;
using R = Iced.Intel.Register;
using A = Iced.Intel.Assembler;
using AR8 = Iced.Intel.AssemblerRegister8;
using AR16 = Iced.Intel.AssemblerRegister16;
using AR32 = Iced.Intel.AssemblerRegister32;
using AR64 = Iced.Intel.AssemblerRegister64;
using ARCR = Iced.Intel.AssemblerRegisterCR;
using ARDR = Iced.Intel.AssemblerRegisterDR;
using ARTR = Iced.Intel.AssemblerRegisterTR;
using AMO = Iced.Intel.AssemblerMemoryOperand;
using ARS = Iced.Intel.AssemblerRegisterSegment;
using Y = Iced.Intel.AssemblerRegisters;

// ReSharper disable RedundantCast

namespace Generator.Extractors
{
    internal static class Fuzzer
    {
        /// <summary>
        /// ASCII Adjust After Addition
        /// </summary>
        public static void DoAaa(Action<Action<A>> f)
        {
            f(a => a.aaa());
        }
        
        /// <summary>
        /// ASCII Adjust AX Before Division
        /// </summary>
        public static void DoAad(Action<Action<A>> f)
        {
            f(a => a.aad((sbyte)9));
            f(a => a.aad((byte)9));
        }
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// </summary>
        public static void DoAam(Action<Action<A>> f)
        {
            f(a => a.aam((sbyte)9));
            f(a => a.aam((byte)9));
        }
        
        /// <summary>
        /// ASCII Adjust AL After Subtraction
        /// </summary>
        public static void DoAas(Action<Action<A>> f)
        {
            f(a => a.aas());
        }
        
        /// <summary>
        /// Add With Carry
        /// </summary>
        public static void DoAdc(Action<Action<A>> f)
        {
            f(a => a.adc(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.adc((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.adc(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.adc((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.adc(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.adc((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.adc(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.adc((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.adc(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.adc(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.adc(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.adc(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.adc(new AR8(R.AH), (sbyte)9));
            f(a => a.adc(new AR16(R.BX), (short)9));
            f(a => a.adc(new AR32(R.ECX), (int)9));
            f(a => a.adc(new AR64(R.RDX), (int)9));
            f(a => a.adc((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.adc(new AR8(R.AH), (byte)9));
            f(a => a.adc(new AR16(R.BX), (ushort)9));
            f(a => a.adc(new AR32(R.ECX), (uint)9));
            f(a => a.adc((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Add
        /// </summary>
        public static void DoAdd(Action<Action<A>> f)
        {
            f(a => a.add(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.add((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.add(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.add((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.add(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.add((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.add(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.add((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.add(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.add(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.add(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.add(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.add(new AR8(R.AH), (sbyte)9));
            f(a => a.add(new AR16(R.BX), (short)9));
            f(a => a.add(new AR32(R.ECX), (int)9));
            f(a => a.add(new AR64(R.RDX), (int)9));
            f(a => a.add((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.add(new AR8(R.AH), (byte)9));
            f(a => a.add(new AR16(R.BX), (ushort)9));
            f(a => a.add(new AR32(R.ECX), (uint)9));
            f(a => a.add((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Logical AND
        /// </summary>
        public static void DoAnd(Action<Action<A>> f)
        {
            f(a => a.and(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.and((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.and(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.and((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.and(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.and((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.and(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.and((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.and(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.and(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.and(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.and(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.and(new AR8(R.AH), (sbyte)9));
            f(a => a.and(new AR16(R.BX), (short)9));
            f(a => a.and(new AR32(R.ECX), (int)9));
            f(a => a.and(new AR64(R.RDX), (int)9));
            f(a => a.and((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.and(new AR8(R.AH), (byte)9));
            f(a => a.and(new AR16(R.BX), (ushort)9));
            f(a => a.and(new AR32(R.ECX), (uint)9));
            f(a => a.and((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Check Index Against Bounds
        /// </summary>
        public static void DoBound(Action<Action<A>> f)
        {
            f(a => a.bound(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.bound(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Call Procedure
        /// </summary>
        public static void DoCall(Action<Action<A>> f)
        {
            f(a => a.call((ushort)9, (uint)9));
            f(a => a.call(new AR16(R.BX)));
            f(a => a.call(new AR32(R.ECX)));
            f(a => a.call(new AR64(R.RDX)));
            f(a => a.call((AMO)Y.__word_ptr[Y.ax]));
            f(a => a.call(a.CreateLabel()));
            f(a => a.call((ulong)9));
        }
        
        /// <summary>
        /// Convert Byte to Word
        /// </summary>
        public static void DoCbw(Action<Action<A>> f)
        {
            f(a => a.cbw());
        }
        
        /// <summary>
        /// Clear Carry Flag
        /// </summary>
        public static void DoClc(Action<Action<A>> f)
        {
            f(a => a.clc());
        }
        
        /// <summary>
        /// Clear Direction Flag
        /// </summary>
        public static void DoCld(Action<Action<A>> f)
        {
            f(a => a.cld());
        }
        
        /// <summary>
        /// Clear Interrupt Flag
        /// </summary>
        public static void DoCli(Action<Action<A>> f)
        {
            f(a => a.cli());
        }
        
        /// <summary>
        /// Complement Carry Flag
        /// </summary>
        public static void DoCmc(Action<Action<A>> f)
        {
            f(a => a.cmc());
        }
        
        /// <summary>
        /// Compare Two Operands
        /// </summary>
        public static void DoCmp(Action<Action<A>> f)
        {
            f(a => a.cmp(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.cmp((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.cmp(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.cmp((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.cmp(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.cmp((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.cmp(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.cmp((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.cmp(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.cmp(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.cmp(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.cmp(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.cmp(new AR8(R.AH), (sbyte)9));
            f(a => a.cmp(new AR16(R.BX), (short)9));
            f(a => a.cmp(new AR32(R.ECX), (int)9));
            f(a => a.cmp(new AR64(R.RDX), (int)9));
            f(a => a.cmp((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.cmp(new AR8(R.AH), (byte)9));
            f(a => a.cmp(new AR16(R.BX), (ushort)9));
            f(a => a.cmp(new AR32(R.ECX), (uint)9));
            f(a => a.cmp((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Compare String Operands
        /// </summary>
        public static void DoCmpsb(Action<Action<A>> f)
        {
            f(a => a.cmpsb());
        }
        
        /// <summary>
        /// Compare String Operands
        /// </summary>
        public static void DoCmpsw(Action<Action<A>> f)
        {
            f(a => a.cmpsw());
        }
        
        /// <summary>
        /// Convert Word to Doubleword
        /// </summary>
        public static void DoCwd(Action<Action<A>> f)
        {
            f(a => a.cwd());
        }
        
        /// <summary>
        /// Decimal Adjust AL After Addition
        /// </summary>
        public static void DoDaa(Action<Action<A>> f)
        {
            f(a => a.daa());
        }
        
        /// <summary>
        /// Decimal Adjust AL After Subtraction
        /// </summary>
        public static void DoDas(Action<Action<A>> f)
        {
            f(a => a.das());
        }
        
        /// <summary>
        /// Decrement by 1
        /// </summary>
        public static void DoDec(Action<Action<A>> f)
        {
            f(a => a.dec(new AR8(R.AH)));
            f(a => a.dec(new AR16(R.BX)));
            f(a => a.dec(new AR32(R.ECX)));
            f(a => a.dec(new AR64(R.RDX)));
            f(a => a.dec((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Unsigned Divide
        /// </summary>
        public static void DoDiv(Action<Action<A>> f)
        {
            f(a => a.div(new AR8(R.AH)));
            f(a => a.div(new AR16(R.BX)));
            f(a => a.div(new AR32(R.ECX)));
            f(a => a.div(new AR64(R.RDX)));
            f(a => a.div((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Make Stack Frame for Params
        /// </summary>
        public static void DoEnter(Action<Action<A>> f)
        {
            f(a => a.enter((short)9, (sbyte)9));
            f(a => a.enter((ushort)9, (byte)9));
        }
        
        /// <summary>
        /// Halt
        /// </summary>
        public static void DoHlt(Action<Action<A>> f)
        {
            f(a => a.hlt());
        }
        
        /// <summary>
        /// Signed Divide
        /// </summary>
        public static void DoIdiv(Action<Action<A>> f)
        {
            f(a => a.idiv(new AR8(R.AH)));
            f(a => a.idiv(new AR16(R.BX)));
            f(a => a.idiv(new AR32(R.ECX)));
            f(a => a.idiv(new AR64(R.RDX)));
            f(a => a.idiv((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Signed Multiply
        /// </summary>
        public static void DoImul(Action<Action<A>> f)
        {
            f(a => a.imul(new AR8(R.AH)));
            f(a => a.imul(new AR16(R.BX)));
            f(a => a.imul(new AR32(R.ECX)));
            f(a => a.imul(new AR64(R.RDX)));
            f(a => a.imul((AMO)Y.__word_ptr[Y.ax]));
            f(a => a.imul(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.imul(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.imul(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.imul(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.imul(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.imul(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.imul(new AR16(R.BX), new AR16(R.BX), (short)9));
            f(a => a.imul(new AR32(R.ECX), new AR32(R.ECX), (int)9));
            f(a => a.imul(new AR64(R.RDX), new AR64(R.RDX), (int)9));
            f(a => a.imul(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax], (short)9));
            f(a => a.imul(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.imul(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.imul(new AR16(R.BX), new AR16(R.BX), (ushort)9));
            f(a => a.imul(new AR32(R.ECX), new AR32(R.ECX), (uint)9));
            f(a => a.imul(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax], (ushort)9));
            f(a => a.imul(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Input From Port
        /// </summary>
        public static void DoIn(Action<Action<A>> f)
        {
            f(a => a.@in(new AR8(R.AH), new AR16(R.BX)));
            f(a => a.@in(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.@in(new AR32(R.ECX), new AR16(R.BX)));
            f(a => a.@in(new AR8(R.AH), (sbyte)9));
            f(a => a.@in(new AR16(R.BX), (sbyte)9));
            f(a => a.@in(new AR32(R.ECX), (sbyte)9));
            f(a => a.@in(new AR8(R.AH), (byte)9));
            f(a => a.@in(new AR16(R.BX), (byte)9));
            f(a => a.@in(new AR32(R.ECX), (byte)9));
        }
        
        /// <summary>
        /// Increment by 1
        /// </summary>
        public static void DoInc(Action<Action<A>> f)
        {
            f(a => a.inc(new AR8(R.AH)));
            f(a => a.inc(new AR16(R.BX)));
            f(a => a.inc(new AR32(R.ECX)));
            f(a => a.inc(new AR64(R.RDX)));
            f(a => a.inc((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Input from Port to String
        /// </summary>
        public static void DoInsb(Action<Action<A>> f)
        {
            f(a => a.insb());
        }
        
        /// <summary>
        /// Input from Port to String
        /// </summary>
        public static void DoInsw(Action<Action<A>> f)
        {
            f(a => a.insw());
        }
        
        /// <summary>
        /// Call to Interrupt
        /// </summary>
        public static void DoInt(Action<Action<A>> f)
        {
            f(a => a.@int((sbyte)9));
            f(a => a.@int((byte)9));
        }
        
        /// <summary>
        /// Call to Interrupt
        /// </summary>
        public static void DoInto(Action<Action<A>> f)
        {
            f(a => a.into());
        }
        
        /// <summary>
        /// Interrupt Return
        /// </summary>
        public static void DoIret(Action<Action<A>> f)
        {
            f(a => a.iret());
        }
        
        /// <summary>
        /// Jump If Above
        /// </summary>
        public static void DoJa(Action<Action<A>> f)
        {
            f(a => a.ja(a.CreateLabel()));
            f(a => a.ja((ulong)9));
        }
        
        /// <summary>
        /// Jump If Below or Equal
        /// </summary>
        public static void DoJbe(Action<Action<A>> f)
        {
            f(a => a.jbe(a.CreateLabel()));
            f(a => a.jbe((ulong)9));
        }
        
        /// <summary>
        /// Jump If Carry
        /// </summary>
        public static void DoJc(Action<Action<A>> f)
        {
            f(a => a.jc(a.CreateLabel()));
            f(a => a.jc((ulong)9));
        }
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// </summary>
        public static void DoJcxz(Action<Action<A>> f)
        {
            f(a => a.jcxz(a.CreateLabel()));
            f(a => a.jcxz((ulong)9));
        }
        
        /// <summary>
        /// Jump If Greater
        /// </summary>
        public static void DoJg(Action<Action<A>> f)
        {
            f(a => a.jg(a.CreateLabel()));
            f(a => a.jg((ulong)9));
        }
        
        /// <summary>
        /// Jump If Greater or Equal
        /// </summary>
        public static void DoJge(Action<Action<A>> f)
        {
            f(a => a.jge(a.CreateLabel()));
            f(a => a.jge((ulong)9));
        }
        
        /// <summary>
        /// Jump If Less
        /// </summary>
        public static void DoJl(Action<Action<A>> f)
        {
            f(a => a.jl(a.CreateLabel()));
            f(a => a.jl((ulong)9));
        }
        
        /// <summary>
        /// Jump If Less or Equal
        /// </summary>
        public static void DoJle(Action<Action<A>> f)
        {
            f(a => a.jle(a.CreateLabel()));
            f(a => a.jle((ulong)9));
        }
        
        /// <summary>
        /// Unconditional Jump
        /// </summary>
        public static void DoJmp(Action<Action<A>> f)
        {
            f(a => a.jmp((ushort)9, (uint)9));
            f(a => a.jmp(new AR16(R.BX)));
            f(a => a.jmp(new AR32(R.ECX)));
            f(a => a.jmp(new AR64(R.RDX)));
            f(a => a.jmp((AMO)Y.__word_ptr[Y.ax]));
            f(a => a.jmp(a.CreateLabel()));
            f(a => a.jmp((ulong)9));
        }
        
        /// <summary>
        /// Jump If Not Carry
        /// </summary>
        public static void DoJnc(Action<Action<A>> f)
        {
            f(a => a.jnc(a.CreateLabel()));
            f(a => a.jnc((ulong)9));
        }
        
        /// <summary>
        /// Jump If Not Overflow
        /// </summary>
        public static void DoJno(Action<Action<A>> f)
        {
            f(a => a.jno(a.CreateLabel()));
            f(a => a.jno((ulong)9));
        }
        
        /// <summary>
        /// Jump If Not Parity
        /// </summary>
        public static void DoJnp(Action<Action<A>> f)
        {
            f(a => a.jnp(a.CreateLabel()));
            f(a => a.jnp((ulong)9));
        }
        
        /// <summary>
        /// Jump If Not Sign
        /// </summary>
        public static void DoJns(Action<Action<A>> f)
        {
            f(a => a.jns(a.CreateLabel()));
            f(a => a.jns((ulong)9));
        }
        
        /// <summary>
        /// Jump If Not Zero
        /// </summary>
        public static void DoJnz(Action<Action<A>> f)
        {
            f(a => a.jnz(a.CreateLabel()));
            f(a => a.jnz((ulong)9));
        }
        
        /// <summary>
        /// Jump If Overflow
        /// </summary>
        public static void DoJo(Action<Action<A>> f)
        {
            f(a => a.jo(a.CreateLabel()));
            f(a => a.jo((ulong)9));
        }
        
        /// <summary>
        /// Jump If Parity
        /// </summary>
        public static void DoJp(Action<Action<A>> f)
        {
            f(a => a.jp(a.CreateLabel()));
            f(a => a.jp((ulong)9));
        }
        
        /// <summary>
        /// Jump If Sign
        /// </summary>
        public static void DoJs(Action<Action<A>> f)
        {
            f(a => a.js(a.CreateLabel()));
            f(a => a.js((ulong)9));
        }
        
        /// <summary>
        /// Jump If Zero
        /// </summary>
        public static void DoJz(Action<Action<A>> f)
        {
            f(a => a.jz(a.CreateLabel()));
            f(a => a.jz((ulong)9));
        }
        
        /// <summary>
        /// Load Status Flags Into AH Register
        /// </summary>
        public static void DoLahf(Action<Action<A>> f)
        {
            f(a => a.lahf());
        }
        
        /// <summary>
        /// Load Far Pointer
        /// </summary>
        public static void DoLds(Action<Action<A>> f)
        {
            f(a => a.lds(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.lds(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Load Effective Address
        /// </summary>
        public static void DoLea(Action<Action<A>> f)
        {
            f(a => a.lea(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.lea(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.lea(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// High Level Procedure Exit
        /// </summary>
        public static void DoLeave(Action<Action<A>> f)
        {
            f(a => a.leave());
        }
        
        /// <summary>
        /// Load Far Pointer
        /// </summary>
        public static void DoLes(Action<Action<A>> f)
        {
            f(a => a.les(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.les(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Load String
        /// </summary>
        public static void DoLodsb(Action<Action<A>> f)
        {
            f(a => a.lodsb());
        }
        
        /// <summary>
        /// Load String
        /// </summary>
        public static void DoLodsw(Action<Action<A>> f)
        {
            f(a => a.lodsw());
        }
        
        /// <summary>
        /// Loop According to ECX Counter
        /// </summary>
        public static void DoLoop(Action<Action<A>> f)
        {
            f(a => a.loop(a.CreateLabel()));
            f(a => a.loop((ulong)9));
        }
        
        /// <summary>
        /// Loop While Equal
        /// </summary>
        public static void DoLoope(Action<Action<A>> f)
        {
            f(a => a.loope(a.CreateLabel()));
            f(a => a.loope((ulong)9));
        }
        
        /// <summary>
        /// Loop While Not Equal
        /// </summary>
        public static void DoLoopne(Action<Action<A>> f)
        {
            f(a => a.loopne(a.CreateLabel()));
            f(a => a.loopne((ulong)9));
        }
        
        /// <summary>
        /// Move
        /// </summary>
        public static void DoMov(Action<Action<A>> f)
        {
            f(a => a.mov(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.mov((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.mov(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.mov((ARS)Y.ds, new AR16(R.BX)));
            f(a => a.mov((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.mov(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.mov((ARS)Y.ds, new AR32(R.ECX)));
            f(a => a.mov(new ARCR(R.CR0), new AR32(R.ECX)));
            f(a => a.mov(new ARDR(R.DR0), new AR32(R.ECX)));
            f(a => a.mov(new ARTR(R.TR0), new AR32(R.ECX)));
            f(a => a.mov((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.mov(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.mov((ARS)Y.ds, new AR64(R.RDX)));
            f(a => a.mov(new ARCR(R.CR0), new AR64(R.RDX)));
            f(a => a.mov(new ARDR(R.DR0), new AR64(R.RDX)));
            f(a => a.mov((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.mov(new AR16(R.BX), (ARS)Y.ds));
            f(a => a.mov(new AR32(R.ECX), (ARS)Y.ds));
            f(a => a.mov(new AR64(R.RDX), (ARS)Y.ds));
            f(a => a.mov((AMO)Y.__word_ptr[Y.ax], (ARS)Y.ds));
            f(a => a.mov(new AR32(R.ECX), new ARCR(R.CR0)));
            f(a => a.mov(new AR64(R.RDX), new ARCR(R.CR0)));
            f(a => a.mov(new AR32(R.ECX), new ARDR(R.DR0)));
            f(a => a.mov(new AR64(R.RDX), new ARDR(R.DR0)));
            f(a => a.mov(new AR32(R.ECX), new ARTR(R.TR0)));
            f(a => a.mov(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.mov(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.mov(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.mov(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.mov((ARS)Y.ds, (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.mov(new AR8(R.AH), (sbyte)9));
            f(a => a.mov(new AR16(R.BX), (short)9));
            f(a => a.mov(new AR32(R.ECX), (int)9));
            f(a => a.mov(new AR64(R.RDX), (long)9));
            f(a => a.mov((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.mov(new AR8(R.AH), (byte)9));
            f(a => a.mov(new AR16(R.BX), (ushort)9));
            f(a => a.mov(new AR32(R.ECX), (uint)9));
            f(a => a.mov(new AR64(R.RDX), (ulong)9));
            f(a => a.mov((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Move Data From String to String
        /// </summary>
        public static void DoMovsb(Action<Action<A>> f)
        {
            f(a => a.movsb());
        }
        
        /// <summary>
        /// Move Data From String to String
        /// </summary>
        public static void DoMovsw(Action<Action<A>> f)
        {
            f(a => a.movsw());
        }
        
        /// <summary>
        /// Unsigned Multiply
        /// </summary>
        public static void DoMul(Action<Action<A>> f)
        {
            f(a => a.mul(new AR8(R.AH)));
            f(a => a.mul(new AR16(R.BX)));
            f(a => a.mul(new AR32(R.ECX)));
            f(a => a.mul(new AR64(R.RDX)));
            f(a => a.mul((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Two's Complement Negation
        /// </summary>
        public static void DoNeg(Action<Action<A>> f)
        {
            f(a => a.neg(new AR8(R.AH)));
            f(a => a.neg(new AR16(R.BX)));
            f(a => a.neg(new AR32(R.ECX)));
            f(a => a.neg(new AR64(R.RDX)));
            f(a => a.neg((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// No Operation
        /// </summary>
        public static void DoNop(Action<Action<A>> f)
        {
            f(a => a.nop((int)9));
            f(a => a.nop());
            f(a => a.nop(new AR16(R.BX)));
            f(a => a.nop(new AR32(R.ECX)));
            f(a => a.nop(new AR64(R.RDX)));
            f(a => a.nop((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// One's Complement Negation
        /// </summary>
        public static void DoNot(Action<Action<A>> f)
        {
            f(a => a.not(new AR8(R.AH)));
            f(a => a.not(new AR16(R.BX)));
            f(a => a.not(new AR32(R.ECX)));
            f(a => a.not(new AR64(R.RDX)));
            f(a => a.not((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        public static void DoOr(Action<Action<A>> f)
        {
            f(a => a.or(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.or((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.or(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.or((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.or(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.or((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.or(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.or((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.or(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.or(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.or(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.or(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.or(new AR8(R.AH), (sbyte)9));
            f(a => a.or(new AR16(R.BX), (short)9));
            f(a => a.or(new AR32(R.ECX), (int)9));
            f(a => a.or(new AR64(R.RDX), (int)9));
            f(a => a.or((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.or(new AR8(R.AH), (byte)9));
            f(a => a.or(new AR16(R.BX), (ushort)9));
            f(a => a.or(new AR32(R.ECX), (uint)9));
            f(a => a.or((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Output to Port
        /// </summary>
        public static void DoOut(Action<Action<A>> f)
        {
            f(a => a.@out(new AR16(R.BX), new AR8(R.AH)));
            f(a => a.@out((sbyte)9, new AR8(R.AH)));
            f(a => a.@out((byte)9, new AR8(R.AH)));
            f(a => a.@out(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.@out((sbyte)9, new AR16(R.BX)));
            f(a => a.@out((byte)9, new AR16(R.BX)));
            f(a => a.@out(new AR16(R.BX), new AR32(R.ECX)));
            f(a => a.@out((sbyte)9, new AR32(R.ECX)));
            f(a => a.@out((byte)9, new AR32(R.ECX)));
        }
        
        /// <summary>
        /// Output String to Port
        /// </summary>
        public static void DoOutsb(Action<Action<A>> f)
        {
            f(a => a.outsb());
        }
        
        /// <summary>
        /// Output String to Port
        /// </summary>
        public static void DoOutsw(Action<Action<A>> f)
        {
            f(a => a.outsw());
        }
        
        /// <summary>
        /// Pop Value From the Stack
        /// </summary>
        public static void DoPop(Action<Action<A>> f)
        {
            f(a => a.pop(new AR16(R.BX)));
            f(a => a.pop(new AR32(R.ECX)));
            f(a => a.pop(new AR64(R.RDX)));
            f(a => a.pop((ARS)Y.ds));
            f(a => a.pop((AMO)Y.__word_ptr[Y.ax]));
        }
        
        /// <summary>
        /// Pop All General Registers
        /// </summary>
        public static void DoPopa(Action<Action<A>> f)
        {
            f(a => a.popa());
        }
        
        /// <summary>
        /// Pop Stack Into EFLAGS
        /// </summary>
        public static void DoPopf(Action<Action<A>> f)
        {
            f(a => a.popf());
        }
        
        /// <summary>
        /// Push Word Onto the Stack
        /// </summary>
        public static void DoPush(Action<Action<A>> f)
        {
            f(a => a.push(new AR16(R.BX)));
            f(a => a.push(new AR32(R.ECX)));
            f(a => a.push(new AR64(R.RDX)));
            f(a => a.push((ARS)Y.ds));
            f(a => a.push((AMO)Y.__word_ptr[Y.ax]));
            f(a => a.push((int)9));
            f(a => a.push((uint)9));
        }
        
        /// <summary>
        /// Push All General Registers
        /// </summary>
        public static void DoPusha(Action<Action<A>> f)
        {
            f(a => a.pusha());
        }
        
        /// <summary>
        /// Push EFLAGS Onto Stack
        /// </summary>
        public static void DoPushf(Action<Action<A>> f)
        {
            f(a => a.pushf());
        }
        
        /// <summary>
        /// Rotate Through Carry Left
        /// </summary>
        public static void DoRcl(Action<Action<A>> f)
        {
            f(a => a.rcl(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.rcl(new AR16(R.BX), new AR8(R.AH)));
            f(a => a.rcl(new AR32(R.ECX), new AR8(R.AH)));
            f(a => a.rcl(new AR64(R.RDX), new AR8(R.AH)));
            f(a => a.rcl((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.rcl(new AR8(R.AH), (sbyte)9));
            f(a => a.rcl(new AR16(R.BX), (sbyte)9));
            f(a => a.rcl(new AR32(R.ECX), (sbyte)9));
            f(a => a.rcl(new AR64(R.RDX), (sbyte)9));
            f(a => a.rcl((AMO)Y.__word_ptr[Y.ax], (sbyte)9));
            f(a => a.rcl(new AR8(R.AH), (byte)9));
            f(a => a.rcl(new AR16(R.BX), (byte)9));
            f(a => a.rcl(new AR32(R.ECX), (byte)9));
            f(a => a.rcl(new AR64(R.RDX), (byte)9));
            f(a => a.rcl((AMO)Y.__word_ptr[Y.ax], (byte)9));
        }
        
        /// <summary>
        /// Rotate Through Carry Right
        /// </summary>
        public static void DoRcr(Action<Action<A>> f)
        {
            f(a => a.rcr(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.rcr(new AR16(R.BX), new AR8(R.AH)));
            f(a => a.rcr(new AR32(R.ECX), new AR8(R.AH)));
            f(a => a.rcr(new AR64(R.RDX), new AR8(R.AH)));
            f(a => a.rcr((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.rcr(new AR8(R.AH), (sbyte)9));
            f(a => a.rcr(new AR16(R.BX), (sbyte)9));
            f(a => a.rcr(new AR32(R.ECX), (sbyte)9));
            f(a => a.rcr(new AR64(R.RDX), (sbyte)9));
            f(a => a.rcr((AMO)Y.__word_ptr[Y.ax], (sbyte)9));
            f(a => a.rcr(new AR8(R.AH), (byte)9));
            f(a => a.rcr(new AR16(R.BX), (byte)9));
            f(a => a.rcr(new AR32(R.ECX), (byte)9));
            f(a => a.rcr(new AR64(R.RDX), (byte)9));
            f(a => a.rcr((AMO)Y.__word_ptr[Y.ax], (byte)9));
        }
        
        /// <summary>
        /// Return From Procedure
        /// </summary>
        public static void DoRet(Action<Action<A>> f)
        {
            f(a => a.ret());
            f(a => a.ret((short)9));
            f(a => a.ret((ushort)9));
        }
        
        /// <summary>
        /// Return From Far Procedure
        /// </summary>
        public static void DoRetf(Action<Action<A>> f)
        {
            f(a => a.retf());
            f(a => a.retf((short)9));
            f(a => a.retf((ushort)9));
        }
        
        /// <summary>
        /// Rotate Left
        /// </summary>
        public static void DoRol(Action<Action<A>> f)
        {
            f(a => a.rol(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.rol(new AR16(R.BX), new AR8(R.AH)));
            f(a => a.rol(new AR32(R.ECX), new AR8(R.AH)));
            f(a => a.rol(new AR64(R.RDX), new AR8(R.AH)));
            f(a => a.rol((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.rol(new AR8(R.AH), (sbyte)9));
            f(a => a.rol(new AR16(R.BX), (sbyte)9));
            f(a => a.rol(new AR32(R.ECX), (sbyte)9));
            f(a => a.rol(new AR64(R.RDX), (sbyte)9));
            f(a => a.rol((AMO)Y.__word_ptr[Y.ax], (sbyte)9));
            f(a => a.rol(new AR8(R.AH), (byte)9));
            f(a => a.rol(new AR16(R.BX), (byte)9));
            f(a => a.rol(new AR32(R.ECX), (byte)9));
            f(a => a.rol(new AR64(R.RDX), (byte)9));
            f(a => a.rol((AMO)Y.__word_ptr[Y.ax], (byte)9));
        }
        
        /// <summary>
        /// Rotate Right
        /// </summary>
        public static void DoRor(Action<Action<A>> f)
        {
            f(a => a.ror(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.ror(new AR16(R.BX), new AR8(R.AH)));
            f(a => a.ror(new AR32(R.ECX), new AR8(R.AH)));
            f(a => a.ror(new AR64(R.RDX), new AR8(R.AH)));
            f(a => a.ror((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.ror(new AR8(R.AH), (sbyte)9));
            f(a => a.ror(new AR16(R.BX), (sbyte)9));
            f(a => a.ror(new AR32(R.ECX), (sbyte)9));
            f(a => a.ror(new AR64(R.RDX), (sbyte)9));
            f(a => a.ror((AMO)Y.__word_ptr[Y.ax], (sbyte)9));
            f(a => a.ror(new AR8(R.AH), (byte)9));
            f(a => a.ror(new AR16(R.BX), (byte)9));
            f(a => a.ror(new AR32(R.ECX), (byte)9));
            f(a => a.ror(new AR64(R.RDX), (byte)9));
            f(a => a.ror((AMO)Y.__word_ptr[Y.ax], (byte)9));
        }
        
        /// <summary>
        /// Store AH Into Flags
        /// </summary>
        public static void DoSahf(Action<Action<A>> f)
        {
            f(a => a.sahf());
        }
        
        /// <summary>
        /// Shift Arithmetic Right
        /// </summary>
        public static void DoSar(Action<Action<A>> f)
        {
            f(a => a.sar(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.sar(new AR16(R.BX), new AR8(R.AH)));
            f(a => a.sar(new AR32(R.ECX), new AR8(R.AH)));
            f(a => a.sar(new AR64(R.RDX), new AR8(R.AH)));
            f(a => a.sar((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.sar(new AR8(R.AH), (sbyte)9));
            f(a => a.sar(new AR16(R.BX), (sbyte)9));
            f(a => a.sar(new AR32(R.ECX), (sbyte)9));
            f(a => a.sar(new AR64(R.RDX), (sbyte)9));
            f(a => a.sar((AMO)Y.__word_ptr[Y.ax], (sbyte)9));
            f(a => a.sar(new AR8(R.AH), (byte)9));
            f(a => a.sar(new AR16(R.BX), (byte)9));
            f(a => a.sar(new AR32(R.ECX), (byte)9));
            f(a => a.sar(new AR64(R.RDX), (byte)9));
            f(a => a.sar((AMO)Y.__word_ptr[Y.ax], (byte)9));
        }
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// </summary>
        public static void DoSbb(Action<Action<A>> f)
        {
            f(a => a.sbb(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.sbb((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.sbb(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.sbb((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.sbb(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.sbb((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.sbb(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.sbb((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.sbb(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.sbb(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.sbb(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.sbb(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.sbb(new AR8(R.AH), (sbyte)9));
            f(a => a.sbb(new AR16(R.BX), (short)9));
            f(a => a.sbb(new AR32(R.ECX), (int)9));
            f(a => a.sbb(new AR64(R.RDX), (int)9));
            f(a => a.sbb((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.sbb(new AR8(R.AH), (byte)9));
            f(a => a.sbb(new AR16(R.BX), (ushort)9));
            f(a => a.sbb(new AR32(R.ECX), (uint)9));
            f(a => a.sbb((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Scan String
        /// </summary>
        public static void DoScasb(Action<Action<A>> f)
        {
            f(a => a.scasb());
        }
        
        /// <summary>
        /// Scan String
        /// </summary>
        public static void DoScasw(Action<Action<A>> f)
        {
            f(a => a.scasw());
        }
        
        /// <summary>
        /// Shift Logical Left
        /// </summary>
        public static void DoShl(Action<Action<A>> f)
        {
            f(a => a.shl(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.shl(new AR16(R.BX), new AR8(R.AH)));
            f(a => a.shl(new AR32(R.ECX), new AR8(R.AH)));
            f(a => a.shl(new AR64(R.RDX), new AR8(R.AH)));
            f(a => a.shl((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.shl(new AR8(R.AH), (sbyte)9));
            f(a => a.shl(new AR16(R.BX), (sbyte)9));
            f(a => a.shl(new AR32(R.ECX), (sbyte)9));
            f(a => a.shl(new AR64(R.RDX), (sbyte)9));
            f(a => a.shl((AMO)Y.__word_ptr[Y.ax], (sbyte)9));
            f(a => a.shl(new AR8(R.AH), (byte)9));
            f(a => a.shl(new AR16(R.BX), (byte)9));
            f(a => a.shl(new AR32(R.ECX), (byte)9));
            f(a => a.shl(new AR64(R.RDX), (byte)9));
            f(a => a.shl((AMO)Y.__word_ptr[Y.ax], (byte)9));
        }
        
        /// <summary>
        /// Shift Logical Right
        /// </summary>
        public static void DoShr(Action<Action<A>> f)
        {
            f(a => a.shr(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.shr(new AR16(R.BX), new AR8(R.AH)));
            f(a => a.shr(new AR32(R.ECX), new AR8(R.AH)));
            f(a => a.shr(new AR64(R.RDX), new AR8(R.AH)));
            f(a => a.shr((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.shr(new AR8(R.AH), (sbyte)9));
            f(a => a.shr(new AR16(R.BX), (sbyte)9));
            f(a => a.shr(new AR32(R.ECX), (sbyte)9));
            f(a => a.shr(new AR64(R.RDX), (sbyte)9));
            f(a => a.shr((AMO)Y.__word_ptr[Y.ax], (sbyte)9));
            f(a => a.shr(new AR8(R.AH), (byte)9));
            f(a => a.shr(new AR16(R.BX), (byte)9));
            f(a => a.shr(new AR32(R.ECX), (byte)9));
            f(a => a.shr(new AR64(R.RDX), (byte)9));
            f(a => a.shr((AMO)Y.__word_ptr[Y.ax], (byte)9));
        }
        
        /// <summary>
        /// Set Carry Flag
        /// </summary>
        public static void DoStc(Action<Action<A>> f)
        {
            f(a => a.stc());
        }
        
        /// <summary>
        /// Set Direction Flag
        /// </summary>
        public static void DoStd(Action<Action<A>> f)
        {
            f(a => a.std());
        }
        
        /// <summary>
        /// Set Interrupt Flag
        /// </summary>
        public static void DoSti(Action<Action<A>> f)
        {
            f(a => a.sti());
        }
        
        /// <summary>
        /// Store String
        /// </summary>
        public static void DoStosb(Action<Action<A>> f)
        {
            f(a => a.stosb());
        }
        
        /// <summary>
        /// Store String
        /// </summary>
        public static void DoStosw(Action<Action<A>> f)
        {
            f(a => a.stosw());
        }
        
        /// <summary>
        /// Subtract
        /// </summary>
        public static void DoSub(Action<Action<A>> f)
        {
            f(a => a.sub(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.sub((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.sub(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.sub((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.sub(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.sub((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.sub(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.sub((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.sub(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.sub(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.sub(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.sub(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.sub(new AR8(R.AH), (sbyte)9));
            f(a => a.sub(new AR16(R.BX), (short)9));
            f(a => a.sub(new AR32(R.ECX), (int)9));
            f(a => a.sub(new AR64(R.RDX), (int)9));
            f(a => a.sub((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.sub(new AR8(R.AH), (byte)9));
            f(a => a.sub(new AR16(R.BX), (ushort)9));
            f(a => a.sub(new AR32(R.ECX), (uint)9));
            f(a => a.sub((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Logical Compare
        /// </summary>
        public static void DoTest(Action<Action<A>> f)
        {
            f(a => a.test(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.test((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.test(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.test((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.test(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.test((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.test(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.test((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.test(new AR8(R.AH), (sbyte)9));
            f(a => a.test(new AR16(R.BX), (short)9));
            f(a => a.test(new AR32(R.ECX), (int)9));
            f(a => a.test(new AR64(R.RDX), (int)9));
            f(a => a.test((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.test(new AR8(R.AH), (byte)9));
            f(a => a.test(new AR16(R.BX), (ushort)9));
            f(a => a.test(new AR32(R.ECX), (uint)9));
            f(a => a.test((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        /// <summary>
        /// Wait
        /// </summary>
        public static void DoWait(Action<Action<A>> f)
        {
            f(a => a.wait());
        }
        
        /// <summary>
        /// Exchange Register/Memory
        /// </summary>
        public static void DoXchg(Action<Action<A>> f)
        {
            f(a => a.xchg(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.xchg((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.xchg(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.xchg((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.xchg(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.xchg((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.xchg(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.xchg((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
        }
        
        /// <summary>
        /// Table Lookup Translation
        /// </summary>
        public static void DoXlatb(Action<Action<A>> f)
        {
            f(a => a.xlatb());
        }
        
        /// <summary>
        /// Logical Exclusive OR
        /// </summary>
        public static void DoXor(Action<Action<A>> f)
        {
            f(a => a.xor(new AR8(R.AH), new AR8(R.AH)));
            f(a => a.xor((AMO)Y.__word_ptr[Y.ax], new AR8(R.AH)));
            f(a => a.xor(new AR16(R.BX), new AR16(R.BX)));
            f(a => a.xor((AMO)Y.__word_ptr[Y.ax], new AR16(R.BX)));
            f(a => a.xor(new AR32(R.ECX), new AR32(R.ECX)));
            f(a => a.xor((AMO)Y.__word_ptr[Y.ax], new AR32(R.ECX)));
            f(a => a.xor(new AR64(R.RDX), new AR64(R.RDX)));
            f(a => a.xor((AMO)Y.__word_ptr[Y.ax], new AR64(R.RDX)));
            f(a => a.xor(new AR8(R.AH), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.xor(new AR16(R.BX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.xor(new AR32(R.ECX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.xor(new AR64(R.RDX), (AMO)Y.__word_ptr[Y.ax]));
            f(a => a.xor(new AR8(R.AH), (sbyte)9));
            f(a => a.xor(new AR16(R.BX), (short)9));
            f(a => a.xor(new AR32(R.ECX), (int)9));
            f(a => a.xor(new AR64(R.RDX), (int)9));
            f(a => a.xor((AMO)Y.__word_ptr[Y.ax], (int)9));
            f(a => a.xor(new AR8(R.AH), (byte)9));
            f(a => a.xor(new AR16(R.BX), (ushort)9));
            f(a => a.xor(new AR32(R.ECX), (uint)9));
            f(a => a.xor((AMO)Y.__word_ptr[Y.ax], (uint)9));
        }
        
        public static void DoAll(Action<Action<A>> a)
        {
            DoAaa(a);
            DoAad(a);
            DoAam(a);
            DoAas(a);
            DoAdc(a);
            DoAdd(a);
            DoAnd(a);
            DoBound(a);
            DoCall(a);
            DoCbw(a);
            DoClc(a);
            DoCld(a);
            DoCli(a);
            DoCmc(a);
            DoCmp(a);
            DoCmpsb(a);
            DoCmpsw(a);
            DoCwd(a);
            DoDaa(a);
            DoDas(a);
            DoDec(a);
            DoDiv(a);
            DoEnter(a);
            DoHlt(a);
            DoIdiv(a);
            DoImul(a);
            DoIn(a);
            DoInc(a);
            DoInsb(a);
            DoInsw(a);
            DoInt(a);
            DoInto(a);
            DoIret(a);
            DoJa(a);
            DoJbe(a);
            DoJc(a);
            DoJcxz(a);
            DoJg(a);
            DoJge(a);
            DoJl(a);
            DoJle(a);
            DoJmp(a);
            DoJnc(a);
            DoJno(a);
            DoJnp(a);
            DoJns(a);
            DoJnz(a);
            DoJo(a);
            DoJp(a);
            DoJs(a);
            DoJz(a);
            DoLahf(a);
            DoLds(a);
            DoLea(a);
            DoLeave(a);
            DoLes(a);
            DoLodsb(a);
            DoLodsw(a);
            DoLoop(a);
            DoLoope(a);
            DoLoopne(a);
            DoMov(a);
            DoMovsb(a);
            DoMovsw(a);
            DoMul(a);
            DoNeg(a);
            DoNop(a);
            DoNot(a);
            DoOr(a);
            DoOut(a);
            DoOutsb(a);
            DoOutsw(a);
            DoPop(a);
            DoPopa(a);
            DoPopf(a);
            DoPush(a);
            DoPusha(a);
            DoPushf(a);
            DoRcl(a);
            DoRcr(a);
            DoRet(a);
            DoRetf(a);
            DoRol(a);
            DoRor(a);
            DoSahf(a);
            DoSar(a);
            DoSbb(a);
            DoScasb(a);
            DoScasw(a);
            DoShl(a);
            DoShr(a);
            DoStc(a);
            DoStd(a);
            DoSti(a);
            DoStosb(a);
            DoStosw(a);
            DoSub(a);
            DoTest(a);
            DoWait(a);
            DoXchg(a);
            DoXlatb(a);
            DoXor(a);
        }
    }
}
