using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class JumpTest : AbstractDecodeTest
    {
        /// <summary>
        /// Call Procedure
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckCall(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Unconditional Jump
        /// <remarks>BR</remarks>
        /// </summary>
        [Theory]
        public void CheckJmp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Return From Procedure
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckRet(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Return From Far Procedure
        /// <remarks>RET</remarks>
        /// </summary>
        [Theory]
        public void CheckRetf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
