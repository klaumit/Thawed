using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class FlagsTest : AbstractDecodeTest
    {
        /// <summary>
        /// Clear Carry Flag
        /// <remarks>CLR1 CY</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11111000", "CLC", "")]
        /* */
        public void CheckClc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Clear Direction Flag
        /// <remarks>CLR1 DIR</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11111100", "CLD", "")]
        /* */
        public void CheckCld(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Clear Interrupt Flag
        /// <remarks>DI</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11111010", "CLI", "")]
        /* */
        public void CheckCli(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Complement Carry Flag
        /// <remarks>NOT1 CY</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11110101", "CMC", "")]
        /* */
        public void CheckCmc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load Status Flags Into AH Register
        /// <remarks>MOV</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10011111", "LAHF", "")]
        /* */
        public void CheckLahf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Store AH Into Flags
        /// <remarks>MOV</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("10011110", "SAHF", "")]
        /* */
        public void CheckSahf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Set Carry Flag
        /// <remarks>SET1 CY</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11111001", "STC", "")]
        /* */
        public void CheckStc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Set Direction Flag
        /// <remarks>SET1 DIR</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11111101", "STD", "")]
        /* */
        public void CheckStd(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Set Interrupt Flag
        /// <remarks>EI</remarks>
        /// </summary>
        [Theory]
        /* */
        [InlineData("11111011", "STI", "")]
        /* */
        public void CheckSti(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
