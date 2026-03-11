using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class OtherTest : AbstractDecodeTest
    {
        /// <summary>
        /// Make Stack Frame for Params
        /// <remarks>PREPARE</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11001000 00000001 11010001 01010010", "ENTER", "D101,52")]
        [InlineData("11001000 00001001 00000000 00001001", "ENTER", "0009,09")]
        /* */
        public void CheckEnter(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// High Level Procedure Exit
        /// <remarks>DISPOSE</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11001001", "LEAVE", "")]
        /* */
        public void CheckLeave(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Assert LOCK Signal Prefix
        /// <remarks>BUSLOCK</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110000", "LOCK", "")]
        /* */
        public void CheckLock(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// No Operation
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10010000", "NOP", "")]
        /* */
        public void CheckNop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Wait
        /// <remarks>POLL</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10011011", "WAIT", "")]
        /* */
        public void CheckWait(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
