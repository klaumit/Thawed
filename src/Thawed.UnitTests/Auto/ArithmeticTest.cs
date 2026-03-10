using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class ArithmeticTest : AbstractDecodeTest
    {
        /// <summary>
        /// Add With Carry
        /// <remarks>ADDC</remarks>
        /// </summary>
        [Theory]
        public void CheckAdc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Add
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckAdd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Compare Two Operands
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckCmp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decrement by 1
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckDec(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Unsigned Divide
        /// <remarks>DIVU</remarks>
        /// </summary>
        [Theory]
        public void CheckDiv(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Signed Divide
        /// <remarks>DIV</remarks>
        /// </summary>
        [Theory]
        public void CheckIdiv(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Signed Multiply
        /// <remarks>MUL</remarks>
        /// </summary>
        [Theory]
        public void CheckImul(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Increment by 1
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckInc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Unsigned Multiply
        /// <remarks>MULU</remarks>
        /// </summary>
        [Theory]
        public void CheckMul(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Two's Complement Negation
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckNeg(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Integer Subtraction With Borrow
        /// <remarks>SUBC</remarks>
        /// </summary>
        [Theory]
        public void CheckSbb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Subtract
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckSub(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
