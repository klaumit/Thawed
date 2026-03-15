using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class BranchTest : AbstractDecodeTest
    {
        #region [JA, BH] Jump If Above
        [Theory(Skip = "Too complicated!")]
        [InlineData("01110111 00000000", "JA", "0002")]
        // [InlineData("01110111 10001011", "JA", "FF8D")]
        public void CheckJaV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JB, BC, BL, JC] Jump If Below
        [Theory(Skip = "Too complicated!")]
        [InlineData("01110010 00000000", "JB", "0002")]
        // [InlineData("01110010 10001010", "JB", "FF8C")]
        public void CheckJbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JBE, BNH] Jump If Below or Equal
        [Theory(Skip = "Too complicated!")]
        [InlineData("01110110 00000000", "JBE", "0002")]
        // [InlineData("01110110 10010101", "JBE", "FF97")]
        public void CheckJbeV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JCXZ, BCWZ] Jump If CX Register is Zero
        [Theory(Skip = "Too complicated!")]
        [InlineData("11100011 00000000", "JCXZ", "0002")]
        // [InlineData("11100011 10001011", "JCXZ", "FF8D")]
        public void CheckJcxzV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JG, BGT] Jump If Greater
        [Theory(Skip = "Too complicated!")]
        [InlineData("01111111 00000000", "JG", "0002")]
        // [InlineData("01111111 10010111", "JG", "FF99")]
        public void CheckJgV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JGE, BGE] Jump If Greater or Equal
        [Theory(Skip = "Too complicated!")]
        [InlineData("01111101 00000000", "JGE", "0002")]
        // [InlineData("01111101 10110111", "JGE", "FFB9")]
        public void CheckJgeV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JL, BLT] Jump If Less
        [Theory(Skip = "Too complicated!")]
        [InlineData("01111100 00000000", "JL", "0002")]
        // [InlineData("01111100 10010111", "JL", "FF99")]
        public void CheckJlV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JLE, BLE] Jump If Less or Equal
        [Theory(Skip = "Too complicated!")]
        [InlineData("01111110 00000000", "JLE", "0002")]
        // [InlineData("01111110 10111000", "JLE", "FFBA")]
        public void CheckJleV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JNB, BNC, BNL, JAE, JNC] Jump Short If Not Below
        [Theory(Skip = "Too complicated!")]
        [InlineData("01110011 00000000", "JNB", "0002")]
        // [InlineData("01110011 10000001", "JNB", "FF83")]
        public void CheckJnbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JNO, BNV] Jump If Not Overflow
        [Theory(Skip = "Too complicated!")]
        [InlineData("01110001 00000000", "JNO", "0002")]
        // [InlineData("01110001 10000001", "JNO", "FF83")]
        public void CheckJnoV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JNS, BP] Jump If Not Sign
        [Theory(Skip = "Too complicated!")]
        [InlineData("01111001 00000000", "JNS", "0002")]
        // [InlineData("01111001 10010001", "JNS", "FF93")]
        public void CheckJnsV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JNZ, BNE, BNZ, JNE] Jump If Not Zero
        [Theory(Skip = "Too complicated!")]
        [InlineData("01110101 00000001", "JNZ", "0003")]
        // [InlineData("01110101 10000011", "JNZ", "FF85")]
        public void CheckJnzV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JO, BV] Jump If Overflow
        [Theory(Skip = "Too complicated!")]
        [InlineData("01110000 00000000", "JO", "0002")]
        // [InlineData("01110000 10000111", "JO", "FF89")]
        public void CheckJoV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JPE, BPE, JP] Jump Short If Parity Even
        [Theory(Skip = "Too complicated!")]
        [InlineData("01111010 00000000", "JPE", "0002")]
        // [InlineData("01111010 10000111", "JPE", "FF89")]
        public void CheckJpeV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JPO, BPO, JNP] Jump Short If Parity Odd
        [Theory(Skip = "Too complicated!")]
        [InlineData("01111011 00000000", "JPO", "0002")]
        // [InlineData("01111011 10011000", "JPO", "FF9A")]
        public void CheckJpoV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JS, BN] Jump If Sign
        [Theory(Skip = "Too complicated!")]
        [InlineData("01111000 00000000", "JS", "0002")]
        // [InlineData("01111000 10111001", "JS", "FFBB")]
        public void CheckJsV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [JZ, BE, BZ, JE] Jump If Zero
        [Theory(Skip = "Too complicated!")]
        [InlineData("01110100 00000000", "JZ", "0002")]
        // [InlineData("01110100 10000000", "JZ", "FF82")]
        public void CheckJzV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
