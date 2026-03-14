using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class NumericTest : AbstractDecodeTest
    {
        #region [AAA, ADJBA] ASCII Adjust After Addition
        [Theory]
        [InlineData("00110111", "AAA", "")]
        public void CheckAaaV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [AAD, CVTDB] ASCII Adjust AX Before Division
        [Theory]
        [InlineData("11010101 00001010", "AAD", "")]
        public void CheckAadV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [AAM, CVTBD] ASCII Adjust AX After Multiply
        [Theory]
        [InlineData("11010100 00001010", "AAM", "")]
        public void CheckAamV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [AAS, ADJBS] ASCII Adjust AL After Subtraction
        [Theory]
        [InlineData("00111111", "AAS", "")]
        public void CheckAasV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [CBW, CVTBW] Convert Byte to Word
        [Theory]
        [InlineData("10011000", "CBW", "")]
        public void CheckCbwV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [CWD, CVTWL] Convert Word to Doubleword
        [Theory]
        [InlineData("10011001", "CWD", "")]
        public void CheckCwdV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [DAA, ADJ4A] Decimal Adjust AL After Addition
        [Theory]
        [InlineData("00100111", "DAA", "")]
        public void CheckDaaV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [DAS, ADJ4S] Decimal Adjust AL After Subtraction
        [Theory]
        [InlineData("00101111", "DAS", "")]
        public void CheckDasV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
