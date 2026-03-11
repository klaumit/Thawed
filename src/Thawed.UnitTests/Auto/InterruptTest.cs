using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class InterruptTest : AbstractDecodeTest
    {
        /// <summary>
        /// Check Index Against Bounds
        /// <remarks>CHKIND</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01100010 11000000", "BOUND", "AX,AX")]
        /* */
        [InlineData("01100010 00000000", "BOUND", "AX,Word Ptr [BX+SI]")]
        [InlineData("01100010 00111101", "BOUND", "DI,Word Ptr [DI]")]
        [InlineData("00111110 01100010 00010001", "BOUND", "DX,Word Ptr DS:[BX+DI]")]
        [InlineData("01100010 01000010 00010000", "BOUND", "AX,Word Ptr [BP+SI+10]")]
        [InlineData("01100010 00000110 00010001 00000000", "BOUND", "AX,Word Ptr [0011]")]
        [InlineData("01100010 10000011 10001101 00010011", "BOUND", "AX,Word Ptr [BP+DI+138D]")]
        /* */
        public void CheckBound(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Halt
        /// <remarks>HALT</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110100", "HLT", "")]
        /* */
        public void CheckHlt(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>BRK</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11001101 00000000", "INT", "00")]
        [InlineData("11001101 10101111", "INT", "AF")]
        /* */
        public void CheckInt(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>BRK</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11001100", "INT3", "")]
        /* */
        public void CheckInt3(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>BRKV</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11001110", "INTO", "")]
        /* */
        public void CheckInto(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Interrupt Return
        /// <remarks>RETI</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11001111", "IRET", "")]
        /* */
        public void CheckIret(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
