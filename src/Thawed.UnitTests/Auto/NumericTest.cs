using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class NumericTest : AbstractDecodeTest
    {
        /// <summary>
        /// ASCII Adjust After Addition
        /// <remarks>ADJBA</remarks>
        /// </summary>
        [Theory]
        public void CheckAaa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AX Before Division
        /// <remarks>CVTDB</remarks>
        /// </summary>
        [Theory]
        public void CheckAad(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// <remarks>CVTBD</remarks>
        /// </summary>
        [Theory]
        public void CheckAam(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AL After Subtraction
        /// <remarks>ADJBS</remarks>
        /// </summary>
        [Theory]
        public void CheckAas(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Convert Byte to Word
        /// <remarks>CVTBW</remarks>
        /// </summary>
        [Theory]
        public void CheckCbw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Convert Word to Doubleword
        /// <remarks>CVTWL</remarks>
        /// </summary>
        [Theory]
        public void CheckCwd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decimal Adjust AL After Addition
        /// <remarks>ADJ4A</remarks>
        /// </summary>
        [Theory]
        public void CheckDaa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decimal Adjust AL After Subtraction
        /// <remarks>ADJ4S</remarks>
        /// </summary>
        [Theory]
        public void CheckDas(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
