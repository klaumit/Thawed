using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class StringTest : AbstractDecodeTest
    {
        /// <summary>
        /// Compare String Operands
        /// <remarks>CMPBKB</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10100110", "CMPSB", "")]
        [InlineData("00100110 10100110", "CMPSB", "ES:")]
        [InlineData("00111110 10100110", "CMPSB", "DS:")]
        /* */
        public void CheckCmpsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Compare String Operands
        /// <remarks>CMPBKW</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10100111", "CMPSW", "")]
        [InlineData("00100110 10100111", "CMPSW", "ES:")]
        [InlineData("00111110 10100111", "CMPSW", "DS:")]
        /* */
        public void CheckCmpsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load String
        /// <remarks>LDMB</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10101100", "LODSB", "")]
        [InlineData("00100110 10101100", "LODSB", "ES:")]
        [InlineData("00111110 10101100", "LODSB", "DS:")]
        /* */
        public void CheckLodsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load String
        /// <remarks>LDMW</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10101101", "LODSW", "")]
        [InlineData("00100110 10101101", "LODSW", "ES:")]
        [InlineData("00111110 10101101", "LODSW", "DS:")]
        /* */
        public void CheckLodsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Move Data From String to String
        /// <remarks>MOVBKB</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10100100", "MOVSB", "")]
        [InlineData("00100110 10100100", "MOVSB", "ES:")]
        [InlineData("00111110 10100100", "MOVSB", "DS:")]
        /* */
        public void CheckMovsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Move Data From String to String
        /// <remarks>MOVBKW</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10100101", "MOVSW", "")]
        [InlineData("00100110 10100101", "MOVSW", "ES:")]
        [InlineData("00111110 10100101", "MOVSW", "DS:")]
        /* */
        public void CheckMovsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// <remarks>REP, REPZ</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110011", "REPE", "")]
        /* */
        public void CheckRepe(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// <remarks>REPNZ</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110010", "REPNE", "")]
        /* */
        public void CheckRepne(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Scan String
        /// <remarks>CMPMB</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10101110", "SCASB", "")]
        [InlineData("00100110 10101110", "SCASB", "ES:")]
        [InlineData("00111110 10101110", "SCASB", "DS:")]
        /* */
        public void CheckScasb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Scan String
        /// <remarks>CMPMW</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10101111", "SCASW", "")]
        [InlineData("00100110 10101111", "SCASW", "ES:")]
        [InlineData("00111110 10101111", "SCASW", "DS:")]
        /* */
        public void CheckScasw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Store String
        /// <remarks>STMB</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10101010", "STOSB", "")]
        [InlineData("00100110 10101010", "STOSB", "ES:")]
        /* */
        public void CheckStosb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Store String
        /// <remarks>STMW</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10101011", "STOSW", "")]
        [InlineData("00100110 10101011", "STOSW", "ES:")]
        /* */
        public void CheckStosw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
