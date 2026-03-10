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
        public void CheckIn(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Input from Port to String
        /// <remarks>INMB</remarks>
        /// </summary>
        [Theory]
        public void CheckInsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Input from Port to String
        /// <remarks>INMW</remarks>
        /// </summary>
        [Theory]
        public void CheckInsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output to Port
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckOut(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output String to Port
        /// <remarks>OUTM</remarks>
        /// </summary>
        [Theory]
        public void CheckOutsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Output String to Port
        /// <remarks>OUTM</remarks>
        /// </summary>
        [Theory]
        public void CheckOutsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
