using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class StringTest : AbstractDecodeTest
    {
        #region [CMPSB, CMPBKB] Compare String Operands
        [Theory]
        [InlineData("10100110", "CMPSB", "")]
        // [InlineData("00100110 10100110", "CMPSB", "ES:")]
        // [InlineData("00111110 10100110", "CMPSB", "DS:")]
        public void CheckCmpsbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [CMPSW, CMPBKW] Compare String Operands
        [Theory]
        [InlineData("10100111", "CMPSW", "")]
        // [InlineData("00100110 10100111", "CMPSW", "ES:")]
        // [InlineData("00111110 10100111", "CMPSW", "DS:")]
        public void CheckCmpswV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LODSB, LDMB] Load String
        [Theory]
        [InlineData("10101100", "LODSB", "")]
        // [InlineData("00100110 10101100", "LODSB", "ES:")]
        // [InlineData("00111110 10101100", "LODSB", "DS:")]
        public void CheckLodsbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LODSW, LDMW] Load String
        [Theory]
        [InlineData("10101101", "LODSW", "")]
        // [InlineData("00100110 10101101", "LODSW", "ES:")]
        // [InlineData("00111110 10101101", "LODSW", "DS:")]
        public void CheckLodswV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [MOVSB, MOVBKB] Move Data From String to String
        [Theory]
        [InlineData("10100100", "MOVSB", "")]
        // [InlineData("00100110 10100100", "MOVSB", "ES:")]
        // [InlineData("00111110 10100100", "MOVSB", "DS:")]
        public void CheckMovsbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [MOVSW, MOVBKW] Move Data From String to String
        [Theory]
        [InlineData("10100101", "MOVSW", "")]
        // [InlineData("00100110 10100101", "MOVSW", "ES:")]
        // [InlineData("00111110 10100101", "MOVSW", "DS:")]
        public void CheckMovswV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [REPE, REP, REPZ] Repeat String Operation Prefix
        [Theory]
        [InlineData("11110011", "REPE", "")]
        public void CheckRepeV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [REPNE, REPNZ] Repeat String Operation Prefix
        [Theory]
        [InlineData("11110010", "REPNE", "")]
        public void CheckRepneV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [SCASB, CMPMB] Scan String
        [Theory]
        [InlineData("10101110", "SCASB", "")]
        // [InlineData("00100110 10101110", "SCASB", "ES:")]
        // [InlineData("00111110 10101110", "SCASB", "DS:")]
        public void CheckScasbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [SCASW, CMPMW] Scan String
        [Theory]
        [InlineData("10101111", "SCASW", "")]
        // [InlineData("00100110 10101111", "SCASW", "ES:")]
        // [InlineData("00111110 10101111", "SCASW", "DS:")]
        public void CheckScaswV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [STOSB, STMB] Store String
        [Theory]
        [InlineData("10101010", "STOSB", "")]
        // [InlineData("00100110 10101010", "STOSB", "ES:")]
        public void CheckStosbV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [STOSW, STMW] Store String
        [Theory]
        [InlineData("10101011", "STOSW", "")]
        // [InlineData("00100110 10101011", "STOSW", "ES:")]
        public void CheckStoswV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
