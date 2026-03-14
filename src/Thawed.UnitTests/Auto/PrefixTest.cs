using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class PrefixTest : AbstractDecodeTest
    {
        #region [CS, PS] Code Segment Register
        [Theory]
        [InlineData("00101110", "CS:", "")]
        public void CheckCsV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [DS, DS0] Data Segment Register
        [Theory]
        [InlineData("00111110", "DS:", "")]
        public void CheckDsV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [ES, DS1] Extra Segment Register
        [Theory]
        [InlineData("00100110", "ES:", "")]
        public void CheckEsV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [SS] Stack Segment Register
        [Theory]
        [InlineData("00110110", "SS:", "")]
        public void CheckSsV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
