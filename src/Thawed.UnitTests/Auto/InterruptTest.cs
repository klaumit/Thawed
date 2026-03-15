using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class InterruptTest : AbstractDecodeTest
    {
        #region [BOUND, CHKIND] Check Index Against Bounds
        [Theory(Skip = "Too complicated!")]
        [InlineData("01100010 11000000", "BOUND", "AX,AX")]
        public void CheckBoundV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory(Skip = "Too complicated!")]
        // [InlineData("01100010 00000000", "BOUND", "AX,Word Ptr [BX+SI]")]
        [InlineData("01100010 00111101", "BOUND", "DI,Word Ptr [DI]")]
        // [InlineData("00111110 01100010 00010001", "BOUND", "DX,Word Ptr DS:[BX+DI]")]
        // [InlineData("01100010 01000010 00010000", "BOUND", "AX,Word Ptr [BP+SI+10]")]
        // [InlineData("01100010 00000110 00010001 00000000", "BOUND", "AX,Word Ptr [0011]")]
        // [InlineData("01100010 10000011 10001101 00010011", "BOUND", "AX,Word Ptr [BP+DI+138D]")]
        public void CheckBoundV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [HLT, HALT] Halt
        [Theory]
        [InlineData("11110100", "HLT", "")]
        public void CheckHltV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [INT, BRK] Call to Interrupt
        [Theory(Skip = "Too complicated!")]
        [InlineData("11001101 00000000", "INT", "00")]
        // [InlineData("11001101 10101111", "INT", "AF")]
        public void CheckIntV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [INT3, BRK] Call to Interrupt
        [Theory(Skip = "Too complicated!")]
        [InlineData("11001100", "INT3", "")]
        public void CheckInt3V1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [INTO, BRKV] Call to Interrupt
        [Theory(Skip = "Too complicated!")]
        [InlineData("11001110", "INTO", "")]
        public void CheckIntoV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [IRET, RETI] Interrupt Return
        [Theory(Skip = "Too complicated!")]
        [InlineData("11001111", "IRET", "")]
        public void CheckIretV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
