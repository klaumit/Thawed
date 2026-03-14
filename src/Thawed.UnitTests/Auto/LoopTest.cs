using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class LoopTest : AbstractDecodeTest
    {
        #region [LOOP, DBNZ] Loop According to ECX Counter
        [Theory(Skip = "Too complicated!")]
        [InlineData("11100010 00000000", "LOOP", "0002")]
        // [InlineData("11100010 10011010", "LOOP", "FF9C")]
        public void CheckLoopV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LOOPNZ, DBNZNE, LOOPNE] Loop While Not Zero
        [Theory(Skip = "Too complicated!")]
        [InlineData("11100000 00000000", "LOOPNZ", "0002")]
        // [InlineData("11100000 10000000", "LOOPNZ", "FF82")]
        public void CheckLoopnzV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LOOPZ, DBNZE, LOOPE] Loop While Zero
        [Theory(Skip = "Too complicated!")]
        [InlineData("11100001 00000000", "LOOPZ", "0002")]
        // [InlineData("11100001 10001101", "LOOPZ", "FF8F")]
        public void CheckLoopzV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
