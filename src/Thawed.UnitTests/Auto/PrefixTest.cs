using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class PrefixTest : AbstractDecodeTest
    {
        /// <summary>
        /// Code Segment Register
        /// <remarks>PS</remarks>
        /// </summary>
        [Theory]
        public void CheckCs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Data Segment Register
        /// <remarks>DS0</remarks>
        /// </summary>
        [Theory]
        public void CheckDs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Extra Segment Register
        /// <remarks>DS1</remarks>
        /// </summary>
        [Theory]
        public void CheckEs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Stack Segment Register
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckSs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
