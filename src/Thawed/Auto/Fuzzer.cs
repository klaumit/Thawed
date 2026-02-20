using System;
using Iced.Intel;
using A = Iced.Intel.Assembler;

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
        }
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// </summary>
        public static void DoAam(A a)
        {
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
        }
        
        /// <summary>
        /// Add
        /// </summary>
        public static void DoAdd(A a)
        {
        }
        
        /// <summary>
        /// Logical AND
        /// </summary>
        public static void DoAnd(A a)
        {
        }
        
        /// <summary>
        /// Check Index Against Bounds
        /// </summary>
        public static void DoBound(A a)
        {
        }
        
        /// <summary>
        /// Call Procedure
        /// </summary>
        public static void DoCall(A a)
        {
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
        /// Code Segment Register
        /// </summary>
        public static void DoCs(A a)
        {
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
        }
        
        /// <summary>
        /// Unsigned Divide
        /// </summary>
        public static void DoDiv(A a)
        {
        }
        
        /// <summary>
        /// Data Segment Register
        /// </summary>
        public static void DoDs(A a)
        {
        }
        
        /// <summary>
        /// Make Stack Frame for Params
        /// </summary>
        public static void DoEnter(A a)
        {
        }
        
        /// <summary>
        /// Extra Segment Register
        /// </summary>
        public static void DoEs(A a)
        {
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
        }
        
        /// <summary>
        /// Signed Multiply
        /// </summary>
        public static void DoImul(A a)
        {
        }
        
        /// <summary>
        /// Input From Port
        /// </summary>
        public static void DoIn(A a)
        {
        }
        
        /// <summary>
        /// Increment by 1
        /// </summary>
        public static void DoInc(A a)
        {
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
        }
        
        /// <summary>
        /// Jump If Below or Equal
        /// </summary>
        public static void DoJbe(A a)
        {
        }
        
        /// <summary>
        /// Jump If Carry
        /// </summary>
        public static void DoJc(A a)
        {
        }
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// </summary>
        public static void DoJcxz(A a)
        {
        }
        
        /// <summary>
        /// Jump If Greater
        /// </summary>
        public static void DoJg(A a)
        {
        }
        
        /// <summary>
        /// Jump If Greater or Equal
        /// </summary>
        public static void DoJge(A a)
        {
        }
        
        /// <summary>
        /// Jump If Less
        /// </summary>
        public static void DoJl(A a)
        {
        }
        
        /// <summary>
        /// Jump If Less or Equal
        /// </summary>
        public static void DoJle(A a)
        {
        }
        
        /// <summary>
        /// Unconditional Jump
        /// </summary>
        public static void DoJmp(A a)
        {
        }
        
        /// <summary>
        /// Jump If Not Carry
        /// </summary>
        public static void DoJnc(A a)
        {
        }
        
        /// <summary>
        /// Jump If Not Overflow
        /// </summary>
        public static void DoJno(A a)
        {
        }
        
        /// <summary>
        /// Jump If Not Parity
        /// </summary>
        public static void DoJnp(A a)
        {
        }
        
        /// <summary>
        /// Jump If Not Sign
        /// </summary>
        public static void DoJns(A a)
        {
        }
        
        /// <summary>
        /// Jump If Not Zero
        /// </summary>
        public static void DoJnz(A a)
        {
        }
        
        /// <summary>
        /// Jump If Overflow
        /// </summary>
        public static void DoJo(A a)
        {
        }
        
        /// <summary>
        /// Jump If Parity
        /// </summary>
        public static void DoJp(A a)
        {
        }
        
        /// <summary>
        /// Jump If Sign
        /// </summary>
        public static void DoJs(A a)
        {
        }
        
        /// <summary>
        /// Jump If Zero
        /// </summary>
        public static void DoJz(A a)
        {
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
        }
        
        /// <summary>
        /// Load Effective Address
        /// </summary>
        public static void DoLea(A a)
        {
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
        }
        
        /// <summary>
        /// Assert LOCK Signal Prefix
        /// </summary>
        public static void DoLock(A a)
        {
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
        }
        
        /// <summary>
        /// Loop While Equal
        /// </summary>
        public static void DoLoope(A a)
        {
        }
        
        /// <summary>
        /// Loop While Not Equal
        /// </summary>
        public static void DoLoopne(A a)
        {
        }
        
        /// <summary>
        /// Move
        /// </summary>
        public static void DoMov(A a)
        {
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
        }
        
        /// <summary>
        /// Two's Complement Negation
        /// </summary>
        public static void DoNeg(A a)
        {
        }
        
        /// <summary>
        /// No Operation
        /// </summary>
        public static void DoNop(A a)
        {
            a.nop();
        }
        
        /// <summary>
        /// One's Complement Negation
        /// </summary>
        public static void DoNot(A a)
        {
        }
        
        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        public static void DoOr(A a)
        {
        }
        
        /// <summary>
        /// Output to Port
        /// </summary>
        public static void DoOut(A a)
        {
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
        }
        
        /// <summary>
        /// Rotate Through Carry Right
        /// </summary>
        public static void DoRcr(A a)
        {
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        public static void DoRep(A a)
        {
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        public static void DoRepne(A a)
        {
        }
        
        /// <summary>
        /// Return From Procedure
        /// </summary>
        public static void DoRet(A a)
        {
            a.ret();
        }
        
        /// <summary>
        /// Return From Far Procedure
        /// </summary>
        public static void DoRetf(A a)
        {
            a.retf();
        }
        
        /// <summary>
        /// Rotate Left
        /// </summary>
        public static void DoRol(A a)
        {
        }
        
        /// <summary>
        /// Rotate Right
        /// </summary>
        public static void DoRor(A a)
        {
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
        }
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// </summary>
        public static void DoSbb(A a)
        {
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
        }
        
        /// <summary>
        /// Shift Logical Right
        /// </summary>
        public static void DoShr(A a)
        {
        }
        
        /// <summary>
        /// Stack Segment Register
        /// </summary>
        public static void DoSs(A a)
        {
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
        }
        
        /// <summary>
        /// Logical Compare
        /// </summary>
        public static void DoTest(A a)
        {
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
        }
        
        /// <summary>
        /// Table Lookup Translation
        /// </summary>
        public static void DoXlat(A a)
        {
        }
        
        /// <summary>
        /// Logical Exclusive OR
        /// </summary>
        public static void DoXor(A a)
        {
        }
    }
}
