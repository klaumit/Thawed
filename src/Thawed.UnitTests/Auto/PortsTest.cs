using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class PortsTest : AbstractDecodeTest
    {
        #region [IN] Input From Port
        [Theory]
        [InlineData("11101100", "IN", "AL,DX")]
        public void CheckInV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11100100 00000000", "IN", "AL,00")]
        // [InlineData("11100100 10101100", "IN", "AL,AC")]
        public void CheckInV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11101101", "IN", "AX,DX")]
        public void CheckInV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11100101 00000000", "IN", "AX,00")]
        // [InlineData("11100101 10110000", "IN", "AX,B0")]
        public void CheckInV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [INSB, INMB] Input from Port to String
        [Theory]
        [InlineData("01101100", "INSB", "")]
        public void CheckInsbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [INSW, INMW] Input from Port to String
        [Theory]
        [InlineData("01101101", "INSW", "")]
        public void CheckInswV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [OUT] Output to Port
        [Theory]
        [InlineData("11101110", "OUT", "DX,AL")]
        public void CheckOutV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        [InlineData("11101111", "OUT", "DX,AX")]
        public void CheckOutV2(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        // [InlineData("11100110 00000000", "OUT", "00,AL")]
        [InlineData("11100110 10111100", "OUT", "BC,AL")]
        public void CheckOutV3(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        
        [Theory]
        // [InlineData("11100111 00000000", "OUT", "00,AX")]
        [InlineData("11100111 11000000", "OUT", "C0,AX")]
        public void CheckOutV4(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [OUTSB, OUTM] Output String to Port
        [Theory]
        [InlineData("01101110", "OUTSB", "")]
        public void CheckOutsbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [OUTSW, OUTM] Output String to Port
        [Theory]
        [InlineData("01101111", "OUTSW", "")]
        public void CheckOutswV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
