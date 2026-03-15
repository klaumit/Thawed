using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class OtherTest : AbstractDecodeTest
    {
        #region [ENTER, PREPARE] Make Stack Frame for Params
        [Theory(Skip = "Too complicated!")]
        [InlineData("11001000 00000001 11010001 01010010", "ENTER", "D101,52")]
        // [InlineData("11001000 00001001 00000000 00001001", "ENTER", "0009,09")]
        public void CheckEnterV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LEAVE, DISPOSE] High Level Procedure Exit
        [Theory]
        [InlineData("11001001", "LEAVE", "")]
        public void CheckLeaveV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LOCK, BUSLOCK] Assert LOCK Signal Prefix
        [Theory(Skip = "Too complicated!")]
        [InlineData("11110000", "LOCK", "")]
        public void CheckLockV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [NOP] No Operation
        [Theory]
        [InlineData("10010000", "NOP", "")]
        public void CheckNopV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [WAIT, POLL] Wait
        [Theory]
        [InlineData("10011011", "WAIT", "")]
        public void CheckWaitV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
