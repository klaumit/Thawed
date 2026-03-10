using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class InterruptTest : AbstractDecodeTest
    {
        /// <summary>
        /// Check Index Against Bounds
        /// <remarks>CHKIND</remarks>
        /// </summary>
        [Theory]
        public void CheckBound(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Halt
        /// <remarks>HALT</remarks>
        /// </summary>
        [Theory]
        public void CheckHlt(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>BRK</remarks>
        /// </summary>
        [Theory]
        public void CheckInt(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>BRK</remarks>
        /// </summary>
        [Theory]
        public void CheckInt3(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Call to Interrupt
        /// <remarks>BRKV</remarks>
        /// </summary>
        [Theory]
        public void CheckInto(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Interrupt Return
        /// <remarks>RETI</remarks>
        /// </summary>
        [Theory]
        public void CheckIret(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
