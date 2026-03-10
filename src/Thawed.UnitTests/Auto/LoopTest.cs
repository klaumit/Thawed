using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class LoopTest : AbstractDecodeTest
    {
        /// <summary>
        /// Loop According to ECX Counter
        /// <remarks>DBNZ</remarks>
        /// </summary>
        [Theory]
        public void CheckLoop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Loop While Equal
        /// </summary>
        [Theory]
        public void CheckLoope(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Loop While Not Equal
        /// </summary>
        [Theory]
        public void CheckLoopne(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Loop While Not Zero
        /// <remarks>DBNZNE, LOOPNE</remarks>
        /// </summary>
        [Theory]
        public void CheckLoopnz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Loop While Zero
        /// <remarks>DBNZE, LOOPE</remarks>
        /// </summary>
        [Theory]
        public void CheckLoopz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
