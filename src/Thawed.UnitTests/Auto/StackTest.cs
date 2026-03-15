using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class StackTest : AbstractDecodeTest
    {
        #region [POP] Pop Value From the Stack
        [Theory(Skip = "Too complicated!")]
        [InlineData("00101110 10001111 00011110 11010001 00001011", "POP", "Word Ptr CS:[0BD1]")]
        public void CheckPopV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("01011000", "POP", "AX")]
        public void CheckPopV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("10001111 00000000", "POP", "Word Ptr [BX+SI]")]
        [InlineData("10001111 11000110", "POP", "SI")]
        // [InlineData("10001111 01000000 00010001", "POP", "Word Ptr [BX+SI+11]")]
        // [InlineData("10001111 01000100 00010001", "POP", "Word Ptr [SI+11]")]
        // [InlineData("10001111 00000110 00010001 00000000", "POP", "Word Ptr [0011]")]
        // [InlineData("10001111 10000000 00010001 00000000", "POP", "Word Ptr [BX+SI+0011]")]
        public void CheckPopV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00011111", "POP", "DS")]
        public void CheckPopV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00000111", "POP", "ES")]
        public void CheckPopV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00010111", "POP", "SS")]
        public void CheckPopV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [POPA, POP] Pop All General Registers
        [Theory]
        [InlineData("01100001", "POPA", "")]
        public void CheckPopaV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [POPF, POP] Pop Stack Into EFLAGS
        [Theory]
        [InlineData("10011101", "POPF", "")]
        public void CheckPopfV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [PUSH] Push Word Onto the Stack
        [Theory(Skip = "Too complicated!")]
        // [InlineData("01101000 00000000 01110101", "PUSH", "7500")]
        [InlineData("01101000 01010000 00000100", "PUSH", "0450")]
        public void CheckPushV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("01010000", "PUSH", "AX")]
        public void CheckPushV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11111111 00110010", "PUSH", "[BP+SI]")]
        [InlineData("11111111 11110000", "PUSH", "AX")]
        // [InlineData("11111111 01110000 00010001", "PUSH", "[BX+SI+11]")]
        // [InlineData("11111111 01110100 00010001", "PUSH", "[SI+11]")]
        // [InlineData("11111111 00110110 00010001 00000000", "PUSH", "[0011]")]
        // [InlineData("11111111 10110000 00010001 00000000", "PUSH", "[BX+SI+0011]")]
        public void CheckPushV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00001110", "PUSH", "CS")]
        public void CheckPushV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00011110", "PUSH", "DS")]
        public void CheckPushV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00000110", "PUSH", "ES")]
        public void CheckPushV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("01101010 00000000", "PUSH", "00")]
        // [InlineData("01101010 10011111", "PUSH", "9F")]
        public void CheckPushV7(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("00010110", "PUSH", "SS")]
        public void CheckPushV8(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [PUSHA, PUSH] Push All General Registers
        [Theory]
        [InlineData("01100000", "PUSHA", "")]
        public void CheckPushaV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [PUSHF, PUSH] Push EFLAGS Onto Stack
        [Theory]
        [InlineData("10011100", "PUSHF", "")]
        public void CheckPushfV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
