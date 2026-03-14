using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class JumpTest : AbstractDecodeTest
    {
        #region [CALL] Call Procedure
        [Theory(Skip = "Too complicated!")]
        [InlineData("11111111 11011000", "CALL", "FAR AX")]
        public void CheckCallV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11111111 00011000", "CALL", "FAR [BX+SI]")]
        [InlineData("11111111 00011100", "CALL", "FAR [SI]")]
        // [InlineData("11111111 01011001 00011001", "CALL", "FAR [BX+DI+19]")]
        // [InlineData("11111111 01011100 00010001", "CALL", "FAR [SI+11]")]
        // [InlineData("11111111 00011110 00010001 00000000", "CALL", "FAR [0011]")]
        // [InlineData("11111111 10011000 00010001 00000000", "CALL", "FAR [BX+SI+0011]")]
        public void CheckCallV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("10011010 00000001 11110100 11011111 11010111", "CALL", "D7DF:F401")]
        // [InlineData("10011010 00001001 00000000 00001001 00000000", "CALL", "0009:0009")]
        public void CheckCallV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("11101000 00000001 10101000", "CALL", "A804")]
        // [InlineData("11101000 00000110 00000000", "CALL", "0009")]
        public void CheckCallV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11111111 00010011", "CALL", "[BP+DI]")]
        [InlineData("11111111 11010011", "CALL", "BX")]
        // [InlineData("00111110 11111111 00010001", "CALL", "DS:[BX+DI]")]
        // [InlineData("11111111 01010100 00010001", "CALL", "[SI+11]")]
        // [InlineData("11111111 00010110 00010001 00000000", "CALL", "[0011]")]
        // [InlineData("11111111 10010000 00010001 00000000", "CALL", "[BX+SI+0011]")]
        public void CheckCallV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JMP, BR] Unconditional Jump
        [Theory(Skip = "Too complicated!")]
        [InlineData("11111111 11101000", "JMP", "FAR AX")]
        public void CheckJmpV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11111111 00101001", "JMP", "FAR [BX+DI]")]
        [InlineData("11111111 00101100", "JMP", "FAR [SI]")]
        // [InlineData("11111111 01101000 00010001", "JMP", "FAR [BX+SI+11]")]
        // [InlineData("11111111 01101100 00010001", "JMP", "FAR [SI+11]")]
        // [InlineData("11111111 00101110 00010001 00000000", "JMP", "FAR [0011]")]
        // [InlineData("11111111 10101000 10101001 01101101", "JMP", "FAR [BX+SI+6DA9]")]
        public void CheckJmpV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11101010 00001001 00000000 00001001 00000000", "JMP", "0009:0009")]
        [InlineData("11101010 11000010 11100011 00000100 01101011", "JMP", "6B04:E3C2")]
        public void CheckJmpV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11101001 00000000 11011100", "JMP", "DC03")]
        [InlineData("11101001 00000001 00011110", "JMP", "1E04")]
        public void CheckJmpV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11101011 00000000", "JMP", "0002")]
        [InlineData("11101011 10001000", "JMP", "FF8A")]
        public void CheckJmpV5(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("11111111 00100000", "JMP", "[BX+SI]")]
        [InlineData("11111111 11100011", "JMP", "BX")]
        // [InlineData("11111111 01100000 00010001", "JMP", "[BX+SI+11]")]
        // [InlineData("11111111 01100100 00010001", "JMP", "[SI+11]")]
        // [InlineData("11111111 00100110 00010001 00000000", "JMP", "[0011]")]
        // [InlineData("11111111 10100000 00010001 00000000", "JMP", "[BX+SI+0011]")]
        public void CheckJmpV6(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [RET] Return From Procedure
        [Theory(Skip = "Too complicated!")]
        [InlineData("11000010 00001001 00000000", "RET", "0009")]
        // [InlineData("11000010 01000010 11010100", "RET", "D442")]
        public void CheckRetV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("11000011", "RET", "")]
        public void CheckRetV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [RETF, RET] Return From Far Procedure
        [Theory(Skip = "Too complicated!")]
        [InlineData("11001010 00000001 11010001", "RETF", "D101")]
        // [InlineData("11001010 00001001 00000000", "RETF", "0009")]
        public void CheckRetfV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        [InlineData("11001011", "RETF", "")]
        public void CheckRetfV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
