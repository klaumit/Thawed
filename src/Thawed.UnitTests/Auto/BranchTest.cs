using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class BranchTest : AbstractDecodeTest
    {
        /// <summary>
        /// Jump If Above
        /// <remarks>BH</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01110111 00000000", "JA", "0002")]
        [InlineData("01110111 10001011", "JA", "FF8D")]
        /* */
        public void CheckJa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Below
        /// <remarks>BC, BL, JC</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01110010 00000000", "JB", "0002")]
        [InlineData("01110010 10001010", "JB", "FF8C")]
        /* */
        public void CheckJb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Below or Equal
        /// <remarks>BNH</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01110110 00000000", "JBE", "0002")]
        [InlineData("01110110 10010101", "JBE", "FF97")]
        /* */
        public void CheckJbe(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// <remarks>BCWZ</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11100011 00000000", "JCXZ", "0002")]
        [InlineData("11100011 10001011", "JCXZ", "FF8D")]
        /* */
        public void CheckJcxz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Greater
        /// <remarks>BGT</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01111111 00000000", "JG", "0002")]
        [InlineData("01111111 10010111", "JG", "FF99")]
        /* */
        public void CheckJg(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Greater or Equal
        /// <remarks>BGE</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01111101 00000000", "JGE", "0002")]
        [InlineData("01111101 10110111", "JGE", "FFB9")]
        /* */
        public void CheckJge(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Less
        /// <remarks>BLT</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01111100 00000000", "JL", "0002")]
        [InlineData("01111100 10010111", "JL", "FF99")]
        /* */
        public void CheckJl(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Less or Equal
        /// <remarks>BLE</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01111110 00000000", "JLE", "0002")]
        [InlineData("01111110 10111000", "JLE", "FFBA")]
        /* */
        public void CheckJle(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump Short If Not Below
        /// <remarks>BNC, BNL, JAE, JNC</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01110011 00000000", "JNB", "0002")]
        [InlineData("01110011 10000001", "JNB", "FF83")]
        /* */
        public void CheckJnb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Overflow
        /// <remarks>BNV</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01110001 00000000", "JNO", "0002")]
        [InlineData("01110001 10000001", "JNO", "FF83")]
        /* */
        public void CheckJno(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Sign
        /// <remarks>BP</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01111001 00000000", "JNS", "0002")]
        [InlineData("01111001 10010001", "JNS", "FF93")]
        /* */
        public void CheckJns(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Zero
        /// <remarks>BNE, BNZ, JNE</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01110101 00000001", "JNZ", "0003")]
        [InlineData("01110101 10000011", "JNZ", "FF85")]
        /* */
        public void CheckJnz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Overflow
        /// <remarks>BV</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01110000 00000000", "JO", "0002")]
        [InlineData("01110000 10000111", "JO", "FF89")]
        /* */
        public void CheckJo(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump Short If Parity Even
        /// <remarks>BPE, JP</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01111010 00000000", "JPE", "0002")]
        [InlineData("01111010 10000111", "JPE", "FF89")]
        /* */
        public void CheckJpe(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump Short If Parity Odd
        /// <remarks>BPO, JNP</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01111011 00000000", "JPO", "0002")]
        [InlineData("01111011 10011000", "JPO", "FF9A")]
        /* */
        public void CheckJpo(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Sign
        /// <remarks>BN</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01111000 00000000", "JS", "0002")]
        [InlineData("01111000 10111001", "JS", "FFBB")]
        /* */
        public void CheckJs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Zero
        /// <remarks>BE, BZ, JE</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("01110100 00000000", "JZ", "0002")]
        [InlineData("01110100 10000000", "JZ", "FF82")]
        /* */
        public void CheckJz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
