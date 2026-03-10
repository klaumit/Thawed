using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class BitwiseTest : AbstractDecodeTest
    {
        /// <summary>
        /// Logical AND
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckAnd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// One's Complement Negation
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckNot(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Logical Inclusive OR
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckOr(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Logical Compare
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckTest(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Logical Exclusive OR
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckXor(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
