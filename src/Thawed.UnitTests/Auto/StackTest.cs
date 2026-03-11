using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class StackTest : AbstractDecodeTest
    {
        /// <summary>
        /// Pop Value From the Stack
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00101110 10001111 00011110 11010001 00001011", "POP", "Word Ptr CS:[0BD1]")]
        /* */
        [InlineData("01011000", "POP", "AX")]
        /* */
        [InlineData("10001111 00000000", "POP", "Word Ptr [BX+SI]")]
        [InlineData("10001111 11000110", "POP", "SI")]
        [InlineData("10001111 01000000 00010001", "POP", "Word Ptr [BX+SI+11]")]
        [InlineData("10001111 01000100 00010001", "POP", "Word Ptr [SI+11]")]
        [InlineData("10001111 00000110 00010001 00000000", "POP", "Word Ptr [0011]")]
        [InlineData("10001111 10000000 00010001 00000000", "POP", "Word Ptr [BX+SI+0011]")]
        /* */
        [InlineData("00011111", "POP", "DS")]
        /* */
        [InlineData("00000111", "POP", "ES")]
        /* */
        [InlineData("00010111", "POP", "SS")]
        /* */
        public void CheckPop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Pop All General Registers
        /// <remarks>POP</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01100001", "POPA", "")]
        /* */
        public void CheckPopa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Pop Stack Into EFLAGS
        /// <remarks>POP</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10011101", "POPF", "")]
        /* */
        public void CheckPopf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push Word Onto the Stack
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01101000 00000000 01110101", "PUSH", "7500")]
        [InlineData("01101000 01010000 00000100", "PUSH", "0450")]
        /* */
        [InlineData("01010000", "PUSH", "AX")]
        /* */
        [InlineData("11111111 00110010", "PUSH", "[BP+SI]")]
        [InlineData("11111111 11110000", "PUSH", "AX")]
        [InlineData("11111111 01110000 00010001", "PUSH", "[BX+SI+11]")]
        [InlineData("11111111 01110100 00010001", "PUSH", "[SI+11]")]
        [InlineData("11111111 00110110 00010001 00000000", "PUSH", "[0011]")]
        [InlineData("11111111 10110000 00010001 00000000", "PUSH", "[BX+SI+0011]")]
        /* */
        [InlineData("00001110", "PUSH", "CS")]
        /* */
        [InlineData("00011110", "PUSH", "DS")]
        /* */
        [InlineData("00000110", "PUSH", "ES")]
        /* */
        [InlineData("01101010 00000000", "PUSH", "00")]
        [InlineData("01101010 10011111", "PUSH", "9F")]
        /* */
        [InlineData("00010110", "PUSH", "SS")]
        /* */
        public void CheckPush(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push All General Registers
        /// <remarks>PUSH</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01100000", "PUSHA", "")]
        /* */
        public void CheckPusha(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push EFLAGS Onto Stack
        /// <remarks>PUSH</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10011100", "PUSHF", "")]
        /* */
        public void CheckPushf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
