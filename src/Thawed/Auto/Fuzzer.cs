using System;
using Iced.Intel;
using R = Iced.Intel.Register;
using L = Iced.Intel.Label;
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

// ReSharper disable RedundantCast

namespace Thawed.Auto
{
    public static class Fuzzer
    {
        /// <summary>
        /// ASCII Adjust After Addition
        /// </summary>
        public static void DoAaa(A a)
        {
            a.aaa();
        }
        
        /// <summary>
        /// ASCII Adjust AX Before Division
        /// </summary>
        public static void DoAad(A a)
        {
            a.aad((sbyte)9);
            a.aad((byte)9);
        }
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// </summary>
        public static void DoAam(A a)
        {
            a.aam((sbyte)9);
            a.aam((byte)9);
        }
        
        /// <summary>
        /// ASCII Adjust AL After Subtraction
        /// </summary>
        public static void DoAas(A a)
        {
            a.aas();
        }
        
        /// <summary>
        /// Add With Carry
        /// </summary>
        public static void DoAdc(A a)
        {
            a.adc(new AR8(R.AH), new AR8(R.AH));
            a.adc(new AMO(), new AR8(R.AH));
            a.adc(new AR16(R.BX), new AR16(R.BX));
            a.adc(new AMO(), new AR16(R.BX));
            a.adc(new AR32(R.ECX), new AR32(R.ECX));
            a.adc(new AMO(), new AR32(R.ECX));
            a.adc(new AR64(R.RDX), new AR64(R.RDX));
            a.adc(new AMO(), new AR64(R.RDX));
            a.adc(new AR8(R.AH), new AMO());
            a.adc(new AR16(R.BX), new AMO());
            a.adc(new AR32(R.ECX), new AMO());
            a.adc(new AR64(R.RDX), new AMO());
            a.adc(new AR8(R.AH), (sbyte)9);
            a.adc(new AR16(R.BX), (short)9);
            a.adc(new AR32(R.ECX), (int)9);
            a.adc(new AR64(R.RDX), (int)9);
            a.adc(new AMO(), (int)9);
            a.adc(new AR8(R.AH), (byte)9);
            a.adc(new AR16(R.BX), (ushort)9);
            a.adc(new AR32(R.ECX), (uint)9);
            a.adc(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Add
        /// </summary>
        public static void DoAdd(A a)
        {
            a.add(new AR8(R.AH), new AR8(R.AH));
            a.add(new AMO(), new AR8(R.AH));
            a.add(new AR16(R.BX), new AR16(R.BX));
            a.add(new AMO(), new AR16(R.BX));
            a.add(new AR32(R.ECX), new AR32(R.ECX));
            a.add(new AMO(), new AR32(R.ECX));
            a.add(new AR64(R.RDX), new AR64(R.RDX));
            a.add(new AMO(), new AR64(R.RDX));
            a.add(new AR8(R.AH), new AMO());
            a.add(new AR16(R.BX), new AMO());
            a.add(new AR32(R.ECX), new AMO());
            a.add(new AR64(R.RDX), new AMO());
            a.add(new AR8(R.AH), (sbyte)9);
            a.add(new AR16(R.BX), (short)9);
            a.add(new AR32(R.ECX), (int)9);
            a.add(new AR64(R.RDX), (int)9);
            a.add(new AMO(), (int)9);
            a.add(new AR8(R.AH), (byte)9);
            a.add(new AR16(R.BX), (ushort)9);
            a.add(new AR32(R.ECX), (uint)9);
            a.add(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Logical AND
        /// </summary>
        public static void DoAnd(A a)
        {
            a.and(new AR8(R.AH), new AR8(R.AH));
            a.and(new AMO(), new AR8(R.AH));
            a.and(new AR16(R.BX), new AR16(R.BX));
            a.and(new AMO(), new AR16(R.BX));
            a.and(new AR32(R.ECX), new AR32(R.ECX));
            a.and(new AMO(), new AR32(R.ECX));
            a.and(new AR64(R.RDX), new AR64(R.RDX));
            a.and(new AMO(), new AR64(R.RDX));
            a.and(new AR8(R.AH), new AMO());
            a.and(new AR16(R.BX), new AMO());
            a.and(new AR32(R.ECX), new AMO());
            a.and(new AR64(R.RDX), new AMO());
            a.and(new AR8(R.AH), (sbyte)9);
            a.and(new AR16(R.BX), (short)9);
            a.and(new AR32(R.ECX), (int)9);
            a.and(new AR64(R.RDX), (int)9);
            a.and(new AMO(), (int)9);
            a.and(new AR8(R.AH), (byte)9);
            a.and(new AR16(R.BX), (ushort)9);
            a.and(new AR32(R.ECX), (uint)9);
            a.and(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Check Index Against Bounds
        /// </summary>
        public static void DoBound(A a)
        {
            a.bound(new AR16(R.BX), new AMO());
            a.bound(new AR32(R.ECX), new AMO());
        }
        
        /// <summary>
        /// Call Procedure
        /// </summary>
        public static void DoCall(A a)
        {
            a.call((ushort)9, (uint)9);
            a.call(new AR16(R.BX));
            a.call(new AR32(R.ECX));
            a.call(new AR64(R.RDX));
            a.call(new AMO());
            a.call(new L());
            a.call((ulong)9);
        }
        
        /// <summary>
        /// Convert Byte to Word
        /// </summary>
        public static void DoCbw(A a)
        {
            a.cbw();
        }
        
        /// <summary>
        /// Clear Carry Flag
        /// </summary>
        public static void DoClc(A a)
        {
            a.clc();
        }
        
        /// <summary>
        /// Clear Direction Flag
        /// </summary>
        public static void DoCld(A a)
        {
            a.cld();
        }
        
        /// <summary>
        /// Clear Interrupt Flag
        /// </summary>
        public static void DoCli(A a)
        {
            a.cli();
        }
        
        /// <summary>
        /// Complement Carry Flag
        /// </summary>
        public static void DoCmc(A a)
        {
            a.cmc();
        }
        
        /// <summary>
        /// Compare Two Operands
        /// </summary>
        public static void DoCmp(A a)
        {
            a.cmp(new AR8(R.AH), new AR8(R.AH));
            a.cmp(new AMO(), new AR8(R.AH));
            a.cmp(new AR16(R.BX), new AR16(R.BX));
            a.cmp(new AMO(), new AR16(R.BX));
            a.cmp(new AR32(R.ECX), new AR32(R.ECX));
            a.cmp(new AMO(), new AR32(R.ECX));
            a.cmp(new AR64(R.RDX), new AR64(R.RDX));
            a.cmp(new AMO(), new AR64(R.RDX));
            a.cmp(new AR8(R.AH), new AMO());
            a.cmp(new AR16(R.BX), new AMO());
            a.cmp(new AR32(R.ECX), new AMO());
            a.cmp(new AR64(R.RDX), new AMO());
            a.cmp(new AR8(R.AH), (sbyte)9);
            a.cmp(new AR16(R.BX), (short)9);
            a.cmp(new AR32(R.ECX), (int)9);
            a.cmp(new AR64(R.RDX), (int)9);
            a.cmp(new AMO(), (int)9);
            a.cmp(new AR8(R.AH), (byte)9);
            a.cmp(new AR16(R.BX), (ushort)9);
            a.cmp(new AR32(R.ECX), (uint)9);
            a.cmp(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Compare String Operands
        /// </summary>
        public static void DoCmpsb(A a)
        {
            a.cmpsb();
        }
        
        /// <summary>
        /// Compare String Operands
        /// </summary>
        public static void DoCmpsw(A a)
        {
            a.cmpsw();
        }
        
        /// <summary>
        /// Convert Word to Doubleword
        /// </summary>
        public static void DoCwd(A a)
        {
            a.cwd();
        }
        
        /// <summary>
        /// Decimal Adjust AL After Addition
        /// </summary>
        public static void DoDaa(A a)
        {
            a.daa();
        }
        
        /// <summary>
        /// Decimal Adjust AL After Subtraction
        /// </summary>
        public static void DoDas(A a)
        {
            a.das();
        }
        
        /// <summary>
        /// Decrement by 1
        /// </summary>
        public static void DoDec(A a)
        {
            a.dec(new AR8(R.AH));
            a.dec(new AR16(R.BX));
            a.dec(new AR32(R.ECX));
            a.dec(new AR64(R.RDX));
            a.dec(new AMO());
        }
        
        /// <summary>
        /// Unsigned Divide
        /// </summary>
        public static void DoDiv(A a)
        {
            a.div(new AR8(R.AH));
            a.div(new AR16(R.BX));
            a.div(new AR32(R.ECX));
            a.div(new AR64(R.RDX));
            a.div(new AMO());
        }
        
        /// <summary>
        /// Make Stack Frame for Params
        /// </summary>
        public static void DoEnter(A a)
        {
            a.enter((short)9, (sbyte)9);
            a.enter((ushort)9, (byte)9);
        }
        
        /// <summary>
        /// Halt
        /// </summary>
        public static void DoHlt(A a)
        {
            a.hlt();
        }
        
        /// <summary>
        /// Signed Divide
        /// </summary>
        public static void DoIdiv(A a)
        {
            a.idiv(new AR8(R.AH));
            a.idiv(new AR16(R.BX));
            a.idiv(new AR32(R.ECX));
            a.idiv(new AR64(R.RDX));
            a.idiv(new AMO());
        }
        
        /// <summary>
        /// Signed Multiply
        /// </summary>
        public static void DoImul(A a)
        {
            a.imul(new AR8(R.AH));
            a.imul(new AR16(R.BX));
            a.imul(new AR32(R.ECX));
            a.imul(new AR64(R.RDX));
            a.imul(new AMO());
            a.imul(new AR16(R.BX), new AR16(R.BX));
            a.imul(new AR32(R.ECX), new AR32(R.ECX));
            a.imul(new AR64(R.RDX), new AR64(R.RDX));
            a.imul(new AR16(R.BX), new AMO());
            a.imul(new AR32(R.ECX), new AMO());
            a.imul(new AR64(R.RDX), new AMO());
            a.imul(new AR16(R.BX), new AR16(R.BX), (short)9);
            a.imul(new AR32(R.ECX), new AR32(R.ECX), (int)9);
            a.imul(new AR64(R.RDX), new AR64(R.RDX), (int)9);
            a.imul(new AR16(R.BX), new AMO(), (short)9);
            a.imul(new AR32(R.ECX), new AMO(), (int)9);
            a.imul(new AR64(R.RDX), new AMO(), (int)9);
            a.imul(new AR16(R.BX), new AR16(R.BX), (ushort)9);
            a.imul(new AR32(R.ECX), new AR32(R.ECX), (uint)9);
            a.imul(new AR16(R.BX), new AMO(), (ushort)9);
            a.imul(new AR32(R.ECX), new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Input From Port
        /// </summary>
        public static void DoIn(A a)
        {
            a.@in(new AR8(R.AH), new AR16(R.BX));
            a.@in(new AR16(R.BX), new AR16(R.BX));
            a.@in(new AR32(R.ECX), new AR16(R.BX));
            a.@in(new AR8(R.AH), (sbyte)9);
            a.@in(new AR16(R.BX), (sbyte)9);
            a.@in(new AR32(R.ECX), (sbyte)9);
            a.@in(new AR8(R.AH), (byte)9);
            a.@in(new AR16(R.BX), (byte)9);
            a.@in(new AR32(R.ECX), (byte)9);
        }
        
        /// <summary>
        /// Increment by 1
        /// </summary>
        public static void DoInc(A a)
        {
            a.inc(new AR8(R.AH));
            a.inc(new AR16(R.BX));
            a.inc(new AR32(R.ECX));
            a.inc(new AR64(R.RDX));
            a.inc(new AMO());
        }
        
        /// <summary>
        /// Input from Port to String
        /// </summary>
        public static void DoInsb(A a)
        {
            a.insb();
        }
        
        /// <summary>
        /// Input from Port to String
        /// </summary>
        public static void DoInsw(A a)
        {
            a.insw();
        }
        
        /// <summary>
        /// Call to Interrupt
        /// </summary>
        public static void DoInt(A a)
        {
            a.@int((sbyte)9);
            a.@int((byte)9);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// </summary>
        public static void DoInto(A a)
        {
            a.into();
        }
        
        /// <summary>
        /// Interrupt Return
        /// </summary>
        public static void DoIret(A a)
        {
            a.iret();
        }
        
        /// <summary>
        /// Jump If Above
        /// </summary>
        public static void DoJa(A a)
        {
            a.ja(new L());
            a.ja((ulong)9);
        }
        
        /// <summary>
        /// Jump If Below or Equal
        /// </summary>
        public static void DoJbe(A a)
        {
            a.jbe(new L());
            a.jbe((ulong)9);
        }
        
        /// <summary>
        /// Jump If Carry
        /// </summary>
        public static void DoJc(A a)
        {
            a.jc(new L());
            a.jc((ulong)9);
        }
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// </summary>
        public static void DoJcxz(A a)
        {
            a.jcxz(new L());
            a.jcxz((ulong)9);
        }
        
        /// <summary>
        /// Jump If Greater
        /// </summary>
        public static void DoJg(A a)
        {
            a.jg(new L());
            a.jg((ulong)9);
        }
        
        /// <summary>
        /// Jump If Greater or Equal
        /// </summary>
        public static void DoJge(A a)
        {
            a.jge(new L());
            a.jge((ulong)9);
        }
        
        /// <summary>
        /// Jump If Less
        /// </summary>
        public static void DoJl(A a)
        {
            a.jl(new L());
            a.jl((ulong)9);
        }
        
        /// <summary>
        /// Jump If Less or Equal
        /// </summary>
        public static void DoJle(A a)
        {
            a.jle(new L());
            a.jle((ulong)9);
        }
        
        /// <summary>
        /// Unconditional Jump
        /// </summary>
        public static void DoJmp(A a)
        {
            a.jmp((ushort)9, (uint)9);
            a.jmp(new AR16(R.BX));
            a.jmp(new AR32(R.ECX));
            a.jmp(new AR64(R.RDX));
            a.jmp(new AMO());
            a.jmp(new L());
            a.jmp((ulong)9);
        }
        
        /// <summary>
        /// Jump If Not Carry
        /// </summary>
        public static void DoJnc(A a)
        {
            a.jnc(new L());
            a.jnc((ulong)9);
        }
        
        /// <summary>
        /// Jump If Not Overflow
        /// </summary>
        public static void DoJno(A a)
        {
            a.jno(new L());
            a.jno((ulong)9);
        }
        
        /// <summary>
        /// Jump If Not Parity
        /// </summary>
        public static void DoJnp(A a)
        {
            a.jnp(new L());
            a.jnp((ulong)9);
        }
        
        /// <summary>
        /// Jump If Not Sign
        /// </summary>
        public static void DoJns(A a)
        {
            a.jns(new L());
            a.jns((ulong)9);
        }
        
        /// <summary>
        /// Jump If Not Zero
        /// </summary>
        public static void DoJnz(A a)
        {
            a.jnz(new L());
            a.jnz((ulong)9);
        }
        
        /// <summary>
        /// Jump If Overflow
        /// </summary>
        public static void DoJo(A a)
        {
            a.jo(new L());
            a.jo((ulong)9);
        }
        
        /// <summary>
        /// Jump If Parity
        /// </summary>
        public static void DoJp(A a)
        {
            a.jp(new L());
            a.jp((ulong)9);
        }
        
        /// <summary>
        /// Jump If Sign
        /// </summary>
        public static void DoJs(A a)
        {
            a.js(new L());
            a.js((ulong)9);
        }
        
        /// <summary>
        /// Jump If Zero
        /// </summary>
        public static void DoJz(A a)
        {
            a.jz(new L());
            a.jz((ulong)9);
        }
        
        /// <summary>
        /// Load Status Flags Into AH Register
        /// </summary>
        public static void DoLahf(A a)
        {
            a.lahf();
        }
        
        /// <summary>
        /// Load Far Pointer
        /// </summary>
        public static void DoLds(A a)
        {
            a.lds(new AR16(R.BX), new AMO());
            a.lds(new AR32(R.ECX), new AMO());
        }
        
        /// <summary>
        /// Load Effective Address
        /// </summary>
        public static void DoLea(A a)
        {
            a.lea(new AR16(R.BX), new AMO());
            a.lea(new AR32(R.ECX), new AMO());
            a.lea(new AR64(R.RDX), new AMO());
        }
        
        /// <summary>
        /// High Level Procedure Exit
        /// </summary>
        public static void DoLeave(A a)
        {
            a.leave();
        }
        
        /// <summary>
        /// Load Far Pointer
        /// </summary>
        public static void DoLes(A a)
        {
            a.les(new AR16(R.BX), new AMO());
            a.les(new AR32(R.ECX), new AMO());
        }
        
        /// <summary>
        /// Load String
        /// </summary>
        public static void DoLodsb(A a)
        {
            a.lodsb();
        }
        
        /// <summary>
        /// Load String
        /// </summary>
        public static void DoLodsw(A a)
        {
            a.lodsw();
        }
        
        /// <summary>
        /// Loop According to ECX Counter
        /// </summary>
        public static void DoLoop(A a)
        {
            a.loop(new L());
            a.loop((ulong)9);
        }
        
        /// <summary>
        /// Loop While Equal
        /// </summary>
        public static void DoLoope(A a)
        {
            a.loope(new L());
            a.loope((ulong)9);
        }
        
        /// <summary>
        /// Loop While Not Equal
        /// </summary>
        public static void DoLoopne(A a)
        {
            a.loopne(new L());
            a.loopne((ulong)9);
        }
        
        /// <summary>
        /// Move
        /// </summary>
        public static void DoMov(A a)
        {
            a.mov(new AR8(R.AH), new AR8(R.AH));
            a.mov(new AMO(), new AR8(R.AH));
            a.mov(new AR16(R.BX), new AR16(R.BX));
            a.mov(new ARS(), new AR16(R.BX));
            a.mov(new AMO(), new AR16(R.BX));
            a.mov(new AR32(R.ECX), new AR32(R.ECX));
            a.mov(new ARS(), new AR32(R.ECX));
            a.mov(new ARCR(), new AR32(R.ECX));
            a.mov(new ARDR(), new AR32(R.ECX));
            a.mov(new ARTR(), new AR32(R.ECX));
            a.mov(new AMO(), new AR32(R.ECX));
            a.mov(new AR64(R.RDX), new AR64(R.RDX));
            a.mov(new ARS(), new AR64(R.RDX));
            a.mov(new ARCR(), new AR64(R.RDX));
            a.mov(new ARDR(), new AR64(R.RDX));
            a.mov(new AMO(), new AR64(R.RDX));
            a.mov(new AR16(R.BX), new ARS());
            a.mov(new AR32(R.ECX), new ARS());
            a.mov(new AR64(R.RDX), new ARS());
            a.mov(new AMO(), new ARS());
            a.mov(new AR32(R.ECX), new ARCR());
            a.mov(new AR64(R.RDX), new ARCR());
            a.mov(new AR32(R.ECX), new ARDR());
            a.mov(new AR64(R.RDX), new ARDR());
            a.mov(new AR32(R.ECX), new ARTR());
            a.mov(new AR8(R.AH), new AMO());
            a.mov(new AR16(R.BX), new AMO());
            a.mov(new AR32(R.ECX), new AMO());
            a.mov(new AR64(R.RDX), new AMO());
            a.mov(new ARS(), new AMO());
            a.mov(new AR8(R.AH), (sbyte)9);
            a.mov(new AR16(R.BX), (short)9);
            a.mov(new AR32(R.ECX), (int)9);
            a.mov(new AR64(R.RDX), (long)9);
            a.mov(new AMO(), (int)9);
            a.mov(new AR8(R.AH), (byte)9);
            a.mov(new AR16(R.BX), (ushort)9);
            a.mov(new AR32(R.ECX), (uint)9);
            a.mov(new AR64(R.RDX), (ulong)9);
            a.mov(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Move Data From String to String
        /// </summary>
        public static void DoMovsb(A a)
        {
            a.movsb();
        }
        
        /// <summary>
        /// Move Data From String to String
        /// </summary>
        public static void DoMovsw(A a)
        {
            a.movsw();
        }
        
        /// <summary>
        /// Unsigned Multiply
        /// </summary>
        public static void DoMul(A a)
        {
            a.mul(new AR8(R.AH));
            a.mul(new AR16(R.BX));
            a.mul(new AR32(R.ECX));
            a.mul(new AR64(R.RDX));
            a.mul(new AMO());
        }
        
        /// <summary>
        /// Two's Complement Negation
        /// </summary>
        public static void DoNeg(A a)
        {
            a.neg(new AR8(R.AH));
            a.neg(new AR16(R.BX));
            a.neg(new AR32(R.ECX));
            a.neg(new AR64(R.RDX));
            a.neg(new AMO());
        }
        
        /// <summary>
        /// No Operation
        /// </summary>
        public static void DoNop(A a)
        {
            a.nop((int)9);
            a.nop();
            a.nop(new AR16(R.BX));
            a.nop(new AR32(R.ECX));
            a.nop(new AR64(R.RDX));
            a.nop(new AMO());
        }
        
        /// <summary>
        /// One's Complement Negation
        /// </summary>
        public static void DoNot(A a)
        {
            a.not(new AR8(R.AH));
            a.not(new AR16(R.BX));
            a.not(new AR32(R.ECX));
            a.not(new AR64(R.RDX));
            a.not(new AMO());
        }
        
        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        public static void DoOr(A a)
        {
            a.or(new AR8(R.AH), new AR8(R.AH));
            a.or(new AMO(), new AR8(R.AH));
            a.or(new AR16(R.BX), new AR16(R.BX));
            a.or(new AMO(), new AR16(R.BX));
            a.or(new AR32(R.ECX), new AR32(R.ECX));
            a.or(new AMO(), new AR32(R.ECX));
            a.or(new AR64(R.RDX), new AR64(R.RDX));
            a.or(new AMO(), new AR64(R.RDX));
            a.or(new AR8(R.AH), new AMO());
            a.or(new AR16(R.BX), new AMO());
            a.or(new AR32(R.ECX), new AMO());
            a.or(new AR64(R.RDX), new AMO());
            a.or(new AR8(R.AH), (sbyte)9);
            a.or(new AR16(R.BX), (short)9);
            a.or(new AR32(R.ECX), (int)9);
            a.or(new AR64(R.RDX), (int)9);
            a.or(new AMO(), (int)9);
            a.or(new AR8(R.AH), (byte)9);
            a.or(new AR16(R.BX), (ushort)9);
            a.or(new AR32(R.ECX), (uint)9);
            a.or(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Output to Port
        /// </summary>
        public static void DoOut(A a)
        {
            a.@out(new AR16(R.BX), new AR8(R.AH));
            a.@out((sbyte)9, new AR8(R.AH));
            a.@out((byte)9, new AR8(R.AH));
            a.@out(new AR16(R.BX), new AR16(R.BX));
            a.@out((sbyte)9, new AR16(R.BX));
            a.@out((byte)9, new AR16(R.BX));
            a.@out(new AR16(R.BX), new AR32(R.ECX));
            a.@out((sbyte)9, new AR32(R.ECX));
            a.@out((byte)9, new AR32(R.ECX));
        }
        
        /// <summary>
        /// Output String to Port
        /// </summary>
        public static void DoOutsb(A a)
        {
            a.outsb();
        }
        
        /// <summary>
        /// Output String to Port
        /// </summary>
        public static void DoOutsw(A a)
        {
            a.outsw();
        }
        
        /// <summary>
        /// Pop Value From the Stack
        /// </summary>
        public static void DoPop(A a)
        {
            a.pop(new AR16(R.BX));
            a.pop(new AR32(R.ECX));
            a.pop(new AR64(R.RDX));
            a.pop(new ARS());
            a.pop(new AMO());
        }
        
        /// <summary>
        /// Pop All General Registers
        /// </summary>
        public static void DoPopa(A a)
        {
            a.popa();
        }
        
        /// <summary>
        /// Pop Stack Into EFLAGS
        /// </summary>
        public static void DoPopf(A a)
        {
            a.popf();
        }
        
        /// <summary>
        /// Push Word Onto the Stack
        /// </summary>
        public static void DoPush(A a)
        {
            a.push(new AR16(R.BX));
            a.push(new AR32(R.ECX));
            a.push(new AR64(R.RDX));
            a.push(new ARS());
            a.push(new AMO());
            a.push((int)9);
            a.push((uint)9);
        }
        
        /// <summary>
        /// Push All General Registers
        /// </summary>
        public static void DoPusha(A a)
        {
            a.pusha();
        }
        
        /// <summary>
        /// Push EFLAGS Onto Stack
        /// </summary>
        public static void DoPushf(A a)
        {
            a.pushf();
        }
        
        /// <summary>
        /// Rotate Through Carry Left
        /// </summary>
        public static void DoRcl(A a)
        {
            a.rcl(new AR8(R.AH), new AR8(R.AH));
            a.rcl(new AR16(R.BX), new AR8(R.AH));
            a.rcl(new AR32(R.ECX), new AR8(R.AH));
            a.rcl(new AR64(R.RDX), new AR8(R.AH));
            a.rcl(new AMO(), new AR8(R.AH));
            a.rcl(new AR8(R.AH), (sbyte)9);
            a.rcl(new AR16(R.BX), (sbyte)9);
            a.rcl(new AR32(R.ECX), (sbyte)9);
            a.rcl(new AR64(R.RDX), (sbyte)9);
            a.rcl(new AMO(), (sbyte)9);
            a.rcl(new AR8(R.AH), (byte)9);
            a.rcl(new AR16(R.BX), (byte)9);
            a.rcl(new AR32(R.ECX), (byte)9);
            a.rcl(new AR64(R.RDX), (byte)9);
            a.rcl(new AMO(), (byte)9);
        }
        
        /// <summary>
        /// Rotate Through Carry Right
        /// </summary>
        public static void DoRcr(A a)
        {
            a.rcr(new AR8(R.AH), new AR8(R.AH));
            a.rcr(new AR16(R.BX), new AR8(R.AH));
            a.rcr(new AR32(R.ECX), new AR8(R.AH));
            a.rcr(new AR64(R.RDX), new AR8(R.AH));
            a.rcr(new AMO(), new AR8(R.AH));
            a.rcr(new AR8(R.AH), (sbyte)9);
            a.rcr(new AR16(R.BX), (sbyte)9);
            a.rcr(new AR32(R.ECX), (sbyte)9);
            a.rcr(new AR64(R.RDX), (sbyte)9);
            a.rcr(new AMO(), (sbyte)9);
            a.rcr(new AR8(R.AH), (byte)9);
            a.rcr(new AR16(R.BX), (byte)9);
            a.rcr(new AR32(R.ECX), (byte)9);
            a.rcr(new AR64(R.RDX), (byte)9);
            a.rcr(new AMO(), (byte)9);
        }
        
        /// <summary>
        /// Return From Procedure
        /// </summary>
        public static void DoRet(A a)
        {
            a.ret();
            a.ret((short)9);
            a.ret((ushort)9);
        }
        
        /// <summary>
        /// Return From Far Procedure
        /// </summary>
        public static void DoRetf(A a)
        {
            a.retf();
            a.retf((short)9);
            a.retf((ushort)9);
        }
        
        /// <summary>
        /// Rotate Left
        /// </summary>
        public static void DoRol(A a)
        {
            a.rol(new AR8(R.AH), new AR8(R.AH));
            a.rol(new AR16(R.BX), new AR8(R.AH));
            a.rol(new AR32(R.ECX), new AR8(R.AH));
            a.rol(new AR64(R.RDX), new AR8(R.AH));
            a.rol(new AMO(), new AR8(R.AH));
            a.rol(new AR8(R.AH), (sbyte)9);
            a.rol(new AR16(R.BX), (sbyte)9);
            a.rol(new AR32(R.ECX), (sbyte)9);
            a.rol(new AR64(R.RDX), (sbyte)9);
            a.rol(new AMO(), (sbyte)9);
            a.rol(new AR8(R.AH), (byte)9);
            a.rol(new AR16(R.BX), (byte)9);
            a.rol(new AR32(R.ECX), (byte)9);
            a.rol(new AR64(R.RDX), (byte)9);
            a.rol(new AMO(), (byte)9);
        }
        
        /// <summary>
        /// Rotate Right
        /// </summary>
        public static void DoRor(A a)
        {
            a.ror(new AR8(R.AH), new AR8(R.AH));
            a.ror(new AR16(R.BX), new AR8(R.AH));
            a.ror(new AR32(R.ECX), new AR8(R.AH));
            a.ror(new AR64(R.RDX), new AR8(R.AH));
            a.ror(new AMO(), new AR8(R.AH));
            a.ror(new AR8(R.AH), (sbyte)9);
            a.ror(new AR16(R.BX), (sbyte)9);
            a.ror(new AR32(R.ECX), (sbyte)9);
            a.ror(new AR64(R.RDX), (sbyte)9);
            a.ror(new AMO(), (sbyte)9);
            a.ror(new AR8(R.AH), (byte)9);
            a.ror(new AR16(R.BX), (byte)9);
            a.ror(new AR32(R.ECX), (byte)9);
            a.ror(new AR64(R.RDX), (byte)9);
            a.ror(new AMO(), (byte)9);
        }
        
        /// <summary>
        /// Store AH Into Flags
        /// </summary>
        public static void DoSahf(A a)
        {
            a.sahf();
        }
        
        /// <summary>
        /// Shift Arithmetic Right
        /// </summary>
        public static void DoSar(A a)
        {
            a.sar(new AR8(R.AH), new AR8(R.AH));
            a.sar(new AR16(R.BX), new AR8(R.AH));
            a.sar(new AR32(R.ECX), new AR8(R.AH));
            a.sar(new AR64(R.RDX), new AR8(R.AH));
            a.sar(new AMO(), new AR8(R.AH));
            a.sar(new AR8(R.AH), (sbyte)9);
            a.sar(new AR16(R.BX), (sbyte)9);
            a.sar(new AR32(R.ECX), (sbyte)9);
            a.sar(new AR64(R.RDX), (sbyte)9);
            a.sar(new AMO(), (sbyte)9);
            a.sar(new AR8(R.AH), (byte)9);
            a.sar(new AR16(R.BX), (byte)9);
            a.sar(new AR32(R.ECX), (byte)9);
            a.sar(new AR64(R.RDX), (byte)9);
            a.sar(new AMO(), (byte)9);
        }
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// </summary>
        public static void DoSbb(A a)
        {
            a.sbb(new AR8(R.AH), new AR8(R.AH));
            a.sbb(new AMO(), new AR8(R.AH));
            a.sbb(new AR16(R.BX), new AR16(R.BX));
            a.sbb(new AMO(), new AR16(R.BX));
            a.sbb(new AR32(R.ECX), new AR32(R.ECX));
            a.sbb(new AMO(), new AR32(R.ECX));
            a.sbb(new AR64(R.RDX), new AR64(R.RDX));
            a.sbb(new AMO(), new AR64(R.RDX));
            a.sbb(new AR8(R.AH), new AMO());
            a.sbb(new AR16(R.BX), new AMO());
            a.sbb(new AR32(R.ECX), new AMO());
            a.sbb(new AR64(R.RDX), new AMO());
            a.sbb(new AR8(R.AH), (sbyte)9);
            a.sbb(new AR16(R.BX), (short)9);
            a.sbb(new AR32(R.ECX), (int)9);
            a.sbb(new AR64(R.RDX), (int)9);
            a.sbb(new AMO(), (int)9);
            a.sbb(new AR8(R.AH), (byte)9);
            a.sbb(new AR16(R.BX), (ushort)9);
            a.sbb(new AR32(R.ECX), (uint)9);
            a.sbb(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Scan String
        /// </summary>
        public static void DoScasb(A a)
        {
            a.scasb();
        }
        
        /// <summary>
        /// Scan String
        /// </summary>
        public static void DoScasw(A a)
        {
            a.scasw();
        }
        
        /// <summary>
        /// Shift Logical Left
        /// </summary>
        public static void DoShl(A a)
        {
            a.shl(new AR8(R.AH), new AR8(R.AH));
            a.shl(new AR16(R.BX), new AR8(R.AH));
            a.shl(new AR32(R.ECX), new AR8(R.AH));
            a.shl(new AR64(R.RDX), new AR8(R.AH));
            a.shl(new AMO(), new AR8(R.AH));
            a.shl(new AR8(R.AH), (sbyte)9);
            a.shl(new AR16(R.BX), (sbyte)9);
            a.shl(new AR32(R.ECX), (sbyte)9);
            a.shl(new AR64(R.RDX), (sbyte)9);
            a.shl(new AMO(), (sbyte)9);
            a.shl(new AR8(R.AH), (byte)9);
            a.shl(new AR16(R.BX), (byte)9);
            a.shl(new AR32(R.ECX), (byte)9);
            a.shl(new AR64(R.RDX), (byte)9);
            a.shl(new AMO(), (byte)9);
        }
        
        /// <summary>
        /// Shift Logical Right
        /// </summary>
        public static void DoShr(A a)
        {
            a.shr(new AR8(R.AH), new AR8(R.AH));
            a.shr(new AR16(R.BX), new AR8(R.AH));
            a.shr(new AR32(R.ECX), new AR8(R.AH));
            a.shr(new AR64(R.RDX), new AR8(R.AH));
            a.shr(new AMO(), new AR8(R.AH));
            a.shr(new AR8(R.AH), (sbyte)9);
            a.shr(new AR16(R.BX), (sbyte)9);
            a.shr(new AR32(R.ECX), (sbyte)9);
            a.shr(new AR64(R.RDX), (sbyte)9);
            a.shr(new AMO(), (sbyte)9);
            a.shr(new AR8(R.AH), (byte)9);
            a.shr(new AR16(R.BX), (byte)9);
            a.shr(new AR32(R.ECX), (byte)9);
            a.shr(new AR64(R.RDX), (byte)9);
            a.shr(new AMO(), (byte)9);
        }
        
        /// <summary>
        /// Set Carry Flag
        /// </summary>
        public static void DoStc(A a)
        {
            a.stc();
        }
        
        /// <summary>
        /// Set Direction Flag
        /// </summary>
        public static void DoStd(A a)
        {
            a.std();
        }
        
        /// <summary>
        /// Set Interrupt Flag
        /// </summary>
        public static void DoSti(A a)
        {
            a.sti();
        }
        
        /// <summary>
        /// Store String
        /// </summary>
        public static void DoStosb(A a)
        {
            a.stosb();
        }
        
        /// <summary>
        /// Store String
        /// </summary>
        public static void DoStosw(A a)
        {
            a.stosw();
        }
        
        /// <summary>
        /// Subtract
        /// </summary>
        public static void DoSub(A a)
        {
            a.sub(new AR8(R.AH), new AR8(R.AH));
            a.sub(new AMO(), new AR8(R.AH));
            a.sub(new AR16(R.BX), new AR16(R.BX));
            a.sub(new AMO(), new AR16(R.BX));
            a.sub(new AR32(R.ECX), new AR32(R.ECX));
            a.sub(new AMO(), new AR32(R.ECX));
            a.sub(new AR64(R.RDX), new AR64(R.RDX));
            a.sub(new AMO(), new AR64(R.RDX));
            a.sub(new AR8(R.AH), new AMO());
            a.sub(new AR16(R.BX), new AMO());
            a.sub(new AR32(R.ECX), new AMO());
            a.sub(new AR64(R.RDX), new AMO());
            a.sub(new AR8(R.AH), (sbyte)9);
            a.sub(new AR16(R.BX), (short)9);
            a.sub(new AR32(R.ECX), (int)9);
            a.sub(new AR64(R.RDX), (int)9);
            a.sub(new AMO(), (int)9);
            a.sub(new AR8(R.AH), (byte)9);
            a.sub(new AR16(R.BX), (ushort)9);
            a.sub(new AR32(R.ECX), (uint)9);
            a.sub(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Logical Compare
        /// </summary>
        public static void DoTest(A a)
        {
            a.test(new AR8(R.AH), new AR8(R.AH));
            a.test(new AMO(), new AR8(R.AH));
            a.test(new AR16(R.BX), new AR16(R.BX));
            a.test(new AMO(), new AR16(R.BX));
            a.test(new AR32(R.ECX), new AR32(R.ECX));
            a.test(new AMO(), new AR32(R.ECX));
            a.test(new AR64(R.RDX), new AR64(R.RDX));
            a.test(new AMO(), new AR64(R.RDX));
            a.test(new AR8(R.AH), (sbyte)9);
            a.test(new AR16(R.BX), (short)9);
            a.test(new AR32(R.ECX), (int)9);
            a.test(new AR64(R.RDX), (int)9);
            a.test(new AMO(), (int)9);
            a.test(new AR8(R.AH), (byte)9);
            a.test(new AR16(R.BX), (ushort)9);
            a.test(new AR32(R.ECX), (uint)9);
            a.test(new AMO(), (uint)9);
        }
        
        /// <summary>
        /// Wait
        /// </summary>
        public static void DoWait(A a)
        {
            a.wait();
        }
        
        /// <summary>
        /// Exchange Register/Memory
        /// </summary>
        public static void DoXchg(A a)
        {
            a.xchg(new AR8(R.AH), new AR8(R.AH));
            a.xchg(new AMO(), new AR8(R.AH));
            a.xchg(new AR16(R.BX), new AR16(R.BX));
            a.xchg(new AMO(), new AR16(R.BX));
            a.xchg(new AR32(R.ECX), new AR32(R.ECX));
            a.xchg(new AMO(), new AR32(R.ECX));
            a.xchg(new AR64(R.RDX), new AR64(R.RDX));
            a.xchg(new AMO(), new AR64(R.RDX));
        }
        
        /// <summary>
        /// Table Lookup Translation
        /// </summary>
        public static void DoXlatb(A a)
        {
            a.xlatb();
        }
        
        /// <summary>
        /// Logical Exclusive OR
        /// </summary>
        public static void DoXor(A a)
        {
            a.xor(new AR8(R.AH), new AR8(R.AH));
            a.xor(new AMO(), new AR8(R.AH));
            a.xor(new AR16(R.BX), new AR16(R.BX));
            a.xor(new AMO(), new AR16(R.BX));
            a.xor(new AR32(R.ECX), new AR32(R.ECX));
            a.xor(new AMO(), new AR32(R.ECX));
            a.xor(new AR64(R.RDX), new AR64(R.RDX));
            a.xor(new AMO(), new AR64(R.RDX));
            a.xor(new AR8(R.AH), new AMO());
            a.xor(new AR16(R.BX), new AMO());
            a.xor(new AR32(R.ECX), new AMO());
            a.xor(new AR64(R.RDX), new AMO());
            a.xor(new AR8(R.AH), (sbyte)9);
            a.xor(new AR16(R.BX), (short)9);
            a.xor(new AR32(R.ECX), (int)9);
            a.xor(new AR64(R.RDX), (int)9);
            a.xor(new AMO(), (int)9);
            a.xor(new AR8(R.AH), (byte)9);
            a.xor(new AR16(R.BX), (ushort)9);
            a.xor(new AR32(R.ECX), (uint)9);
            a.xor(new AMO(), (uint)9);
        }
        
        public static void DoAll(A a)
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
