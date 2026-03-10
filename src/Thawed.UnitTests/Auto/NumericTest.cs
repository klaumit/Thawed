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
        /* */
        [InlineData("00110111", "AAA", "")]
        /* */
        public void CheckAaa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AX Before Division
        /// <remarks>CVTDB</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11010101 00001010", "AAD", "")]
        /* */
        public void CheckAad(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AX After Multiply
        /// <remarks>CVTBD</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11010100 00001010", "AAM", "")]
        /* */
        public void CheckAam(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// ASCII Adjust AL After Subtraction
        /// <remarks>ADJBS</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00111111", "AAS", "")]
        /* */
        public void CheckAas(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Convert Byte to Word
        /// <remarks>CVTBW</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10011000", "CBW", "")]
        /* */
        public void CheckCbw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Convert Word to Doubleword
        /// <remarks>CVTWL</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10011001", "CWD", "")]
        /* */
        public void CheckCwd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decimal Adjust AL After Addition
        /// <remarks>ADJ4A</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00100111", "DAA", "")]
        /* */
        public void CheckDaa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Decimal Adjust AL After Subtraction
        /// <remarks>ADJ4S</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("00101111", "DAS", "")]
        /* */
        public void CheckDas(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
