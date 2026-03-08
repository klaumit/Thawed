using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class NumericTest
    {
        /// <summary>
        /// ASCII Adjust After Addition
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckAaa(char x)
        {
        }
        
        /// <summary>
        /// ASCII Adjust AX Before Division
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckAad(char x)
        {
        }
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckAam(char x)
        {
        }
        
        /// <summary>
        /// ASCII Adjust AL After Subtraction
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckAas(char x)
        {
        }
        
        /// <summary>
        /// Convert Byte to Word
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCbw(char x)
        {
        }
        
        /// <summary>
        /// Convert Word to Doubleword
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCwd(char x)
        {
        }
        
        /// <summary>
        /// Decimal Adjust AL After Addition
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckDaa(char x)
        {
        }
        
        /// <summary>
        /// Decimal Adjust AL After Subtraction
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckDas(char x)
        {
        }
    }
    
    public class ArithmeticTest
    {
        /// <summary>
        /// Add With Carry
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckAdc(char x)
        {
        }
        
        /// <summary>
        /// Add
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckAdd(char x)
        {
        }
        
        /// <summary>
        /// Compare Two Operands
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCmp(char x)
        {
        }
        
        /// <summary>
        /// Decrement by 1
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckDec(char x)
        {
        }
        
        /// <summary>
        /// Unsigned Divide
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckDiv(char x)
        {
        }
        
        /// <summary>
        /// Signed Divide
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckIdiv(char x)
        {
        }
        
        /// <summary>
        /// Signed Multiply
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckImul(char x)
        {
        }
        
        /// <summary>
        /// Increment by 1
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckInc(char x)
        {
        }
        
        /// <summary>
        /// Unsigned Multiply
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckMul(char x)
        {
        }
        
        /// <summary>
        /// Two's Complement Negation
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckNeg(char x)
        {
        }
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckSbb(char x)
        {
        }
        
        /// <summary>
        /// Subtract
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckSub(char x)
        {
        }
    }
    
    public class BitwiseTest
    {
        /// <summary>
        /// Logical AND
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckAnd(char x)
        {
        }
        
        /// <summary>
        /// One's Complement Negation
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckNot(char x)
        {
        }
        
        /// <summary>
        /// Logical Inclusive OR
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckOr(char x)
        {
        }
        
        /// <summary>
        /// Logical Compare
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckTest(char x)
        {
        }
        
        /// <summary>
        /// Logical Exclusive OR
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckXor(char x)
        {
        }
    }
    
    public class InterruptTest
    {
        /// <summary>
        /// Check Index Against Bounds
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckBound(char x)
        {
        }
        
        /// <summary>
        /// Halt
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckHlt(char x)
        {
        }
        
        /// <summary>
        /// Call to Interrupt
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckInt(char x)
        {
        }
        
        /// <summary>
        /// Call to Interrupt
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckInto(char x)
        {
        }
        
        /// <summary>
        /// Interrupt Return
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckIret(char x)
        {
        }
    }
    
    public class JumpTest
    {
        /// <summary>
        /// Call Procedure
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCall(char x)
        {
        }
        
        /// <summary>
        /// Unconditional Jump
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJmp(char x)
        {
        }
        
        /// <summary>
        /// Return From Procedure
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRet(char x)
        {
        }
        
        /// <summary>
        /// Return From Far Procedure
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRetf(char x)
        {
        }
    }
    
    public class FlagsTest
    {
        /// <summary>
        /// Clear Carry Flag
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckClc(char x)
        {
        }
        
        /// <summary>
        /// Clear Direction Flag
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCld(char x)
        {
        }
        
        /// <summary>
        /// Clear Interrupt Flag
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCli(char x)
        {
        }
        
        /// <summary>
        /// Complement Carry Flag
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCmc(char x)
        {
        }
        
        /// <summary>
        /// Load Status Flags Into AH Register
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLahf(char x)
        {
        }
        
        /// <summary>
        /// Store AH Into Flags
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckSahf(char x)
        {
        }
        
        /// <summary>
        /// Set Carry Flag
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckStc(char x)
        {
        }
        
        /// <summary>
        /// Set Direction Flag
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckStd(char x)
        {
        }
        
        /// <summary>
        /// Set Interrupt Flag
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckSti(char x)
        {
        }
    }
    
    public class StringTest
    {
        /// <summary>
        /// Compare String Operands
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCmpsb(char x)
        {
        }
        
        /// <summary>
        /// Compare String Operands
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCmpsw(char x)
        {
        }
        
        /// <summary>
        /// Load String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLodsb(char x)
        {
        }
        
        /// <summary>
        /// Load String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLodsw(char x)
        {
        }
        
        /// <summary>
        /// Move Data From String to String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckMovsb(char x)
        {
        }
        
        /// <summary>
        /// Move Data From String to String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckMovsw(char x)
        {
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRep(char x)
        {
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRepe(char x)
        {
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRepne(char x)
        {
        }
        
        /// <summary>
        /// Scan String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckScasb(char x)
        {
        }
        
        /// <summary>
        /// Scan String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckScasw(char x)
        {
        }
        
        /// <summary>
        /// Store String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckStosb(char x)
        {
        }
        
        /// <summary>
        /// Store String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckStosw(char x)
        {
        }
    }
    
    public class PrefixTest
    {
        /// <summary>
        /// Code Segment Register
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckCs(char x)
        {
        }
        
        /// <summary>
        /// Data Segment Register
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckDs(char x)
        {
        }
        
        /// <summary>
        /// Extra Segment Register
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckEs(char x)
        {
        }
        
        /// <summary>
        /// Stack Segment Register
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckSs(char x)
        {
        }
    }
    
    public class OtherTest
    {
        /// <summary>
        /// Make Stack Frame for Params
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckEnter(char x)
        {
        }
        
        /// <summary>
        /// High Level Procedure Exit
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLeave(char x)
        {
        }
        
        /// <summary>
        /// Assert LOCK Signal Prefix
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLock(char x)
        {
        }
        
        /// <summary>
        /// No Operation
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckNop(char x)
        {
        }
        
        /// <summary>
        /// Wait
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckWait(char x)
        {
        }
    }
    
    public class PortsTest
    {
        /// <summary>
        /// Input From Port
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckIn(char x)
        {
        }
        
        /// <summary>
        /// Input from Port to String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckInsb(char x)
        {
        }
        
        /// <summary>
        /// Input from Port to String
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckInsw(char x)
        {
        }
        
        /// <summary>
        /// Output to Port
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckOut(char x)
        {
        }
        
        /// <summary>
        /// Output String to Port
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckOutsb(char x)
        {
        }
        
        /// <summary>
        /// Output String to Port
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckOutsw(char x)
        {
        }
    }
    
    public class BranchTest
    {
        /// <summary>
        /// Jump If Above
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJa(char x)
        {
        }
        
        /// <summary>
        /// Jump If Below or Equal
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJbe(char x)
        {
        }
        
        /// <summary>
        /// Jump If Carry
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJc(char x)
        {
        }
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJcxz(char x)
        {
        }
        
        /// <summary>
        /// Jump If Greater
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJg(char x)
        {
        }
        
        /// <summary>
        /// Jump If Greater or Equal
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJge(char x)
        {
        }
        
        /// <summary>
        /// Jump If Less
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJl(char x)
        {
        }
        
        /// <summary>
        /// Jump If Less or Equal
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJle(char x)
        {
        }
        
        /// <summary>
        /// Jump If Not Carry
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJnc(char x)
        {
        }
        
        /// <summary>
        /// Jump If Not Overflow
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJno(char x)
        {
        }
        
        /// <summary>
        /// Jump If Not Parity
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJnp(char x)
        {
        }
        
        /// <summary>
        /// Jump If Not Sign
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJns(char x)
        {
        }
        
        /// <summary>
        /// Jump If Not Zero
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJnz(char x)
        {
        }
        
        /// <summary>
        /// Jump If Overflow
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJo(char x)
        {
        }
        
        /// <summary>
        /// Jump If Parity
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJp(char x)
        {
        }
        
        /// <summary>
        /// Jump If Sign
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJs(char x)
        {
        }
        
        /// <summary>
        /// Jump If Zero
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckJz(char x)
        {
        }
    }
    
    public class MemoryTest
    {
        /// <summary>
        /// Load Far Pointer
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLds(char x)
        {
        }
        
        /// <summary>
        /// Load Effective Address
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLea(char x)
        {
        }
        
        /// <summary>
        /// Load Far Pointer
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLes(char x)
        {
        }
        
        /// <summary>
        /// Move
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckMov(char x)
        {
        }
        
        /// <summary>
        /// Exchange Register/Memory
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckXchg(char x)
        {
        }
        
        /// <summary>
        /// Table Lookup Translation
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckXlat(char x)
        {
        }
    }
    
    public class LoopTest
    {
        /// <summary>
        /// Loop According to ECX Counter
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLoop(char x)
        {
        }
        
        /// <summary>
        /// Loop While Equal
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLoope(char x)
        {
        }
        
        /// <summary>
        /// Loop While Not Equal
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckLoopne(char x)
        {
        }
    }
    
    public class StackTest
    {
        /// <summary>
        /// Pop Value From the Stack
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckPop(char x)
        {
        }
        
        /// <summary>
        /// Pop All General Registers
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckPopa(char x)
        {
        }
        
        /// <summary>
        /// Pop Stack Into EFLAGS
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckPopf(char x)
        {
        }
        
        /// <summary>
        /// Push Word Onto the Stack
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckPush(char x)
        {
        }
        
        /// <summary>
        /// Push All General Registers
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckPusha(char x)
        {
        }
        
        /// <summary>
        /// Push EFLAGS Onto Stack
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckPushf(char x)
        {
        }
    }
    
    public class ShiftTest
    {
        /// <summary>
        /// Rotate Through Carry Left
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRcl(char x)
        {
        }
        
        /// <summary>
        /// Rotate Through Carry Right
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRcr(char x)
        {
        }
        
        /// <summary>
        /// Rotate Left
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRol(char x)
        {
        }
        
        /// <summary>
        /// Rotate Right
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckRor(char x)
        {
        }
        
        /// <summary>
        /// Shift Arithmetic Right
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckSar(char x)
        {
        }
        
        /// <summary>
        /// Shift Logical Left
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckShl(char x)
        {
        }
        
        /// <summary>
        /// Shift Logical Right
        /// </summary>
        [Theory]
        [InlineData(' ')]
        public void CheckShr(char x)
        {
        }
    }
}
