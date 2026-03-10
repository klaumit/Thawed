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
        public void CheckEnter(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// High Level Procedure Exit
        /// <remarks>DISPOSE</remarks>
        /// </summary>
        [Theory]
        public void CheckLeave(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Assert LOCK Signal Prefix
        /// <remarks>BUSLOCK</remarks>
        /// </summary>
        [Theory]
        public void CheckLock(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// No Operation
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckNop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Wait
        /// <remarks>POLL</remarks>
        /// </summary>
        [Theory]
        public void CheckWait(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
