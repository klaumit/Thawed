using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class PortsTest : AbstractDecodeTest
    {
        /// <summary>
        /// Input From Port
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11101100", "IN", "AL,DX")]
        /* */
        [InlineData("11100100 00000000", "IN", "AL,00")]
        [InlineData("11100100 10101100", "IN", "AL,AC")]
        /* */
        [InlineData("11101101", "IN", "AX,DX")]
        /* */
        [InlineData("11100101 00000000", "IN", "AX,00")]
        [InlineData("11100101 10110000", "IN", "AX,B0")]
        /* */
        public void CheckIn(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Input from Port to String
        /// <remarks>INMB</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01101100", "INSB", "")]
        /* */
        public void CheckInsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Input from Port to String
        /// <remarks>INMW</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01101101", "INSW", "")]
        /* */
        public void CheckInsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output to Port
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11101110", "OUT", "DX,AL")]
        /* */
        [InlineData("11101111", "OUT", "DX,AX")]
        /* */
        [InlineData("11100110 00000000", "OUT", "00,AL")]
        [InlineData("11100110 10111100", "OUT", "BC,AL")]
        /* */
        [InlineData("11100111 00000000", "OUT", "00,AX")]
        [InlineData("11100111 11000000", "OUT", "C0,AX")]
        /* */
        public void CheckOut(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output String to Port
        /// <remarks>OUTM</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01101110", "OUTSB", "")]
        /* */
        public void CheckOutsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output String to Port
        /// <remarks>OUTM</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01101111", "OUTSW", "")]
        /* */
        public void CheckOutsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
