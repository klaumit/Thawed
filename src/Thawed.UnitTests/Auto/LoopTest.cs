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
        /* */
        [InlineData("11100010 00000000", "LOOP", "0002")]
        [InlineData("11100010 10011010", "LOOP", "FF9C")]
        /* */
        public void CheckLoop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Loop While Not Zero
        /// <remarks>DBNZNE, LOOPNE</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11100000 00000000", "LOOPNZ", "0002")]
        [InlineData("11100000 10000000", "LOOPNZ", "FF82")]
        /* */
        public void CheckLoopnz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Loop While Zero
        /// <remarks>DBNZE, LOOPE</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11100001 00000000", "LOOPZ", "0002")]
        [InlineData("11100001 10001101", "LOOPZ", "FF8F")]
        /* */
        public void CheckLoopz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
