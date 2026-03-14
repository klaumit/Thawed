using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class FlagsTest : AbstractDecodeTest
    {
        #region [CLC, CLR1 CY] Clear Carry Flag
        [Theory]
        [InlineData("11111000", "CLC", "")]
        public void CheckClcV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [CLD, CLR1 DIR] Clear Direction Flag
        [Theory]
        [InlineData("11111100", "CLD", "")]
        public void CheckCldV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [CLI, DI] Clear Interrupt Flag
        [Theory]
        [InlineData("11111010", "CLI", "")]
        public void CheckCliV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [CMC, NOT1 CY] Complement Carry Flag
        [Theory]
        [InlineData("11110101", "CMC", "")]
        public void CheckCmcV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [LAHF, MOV] Load Status Flags Into AH Register
        [Theory]
        [InlineData("10011111", "LAHF", "")]
        public void CheckLahfV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [SAHF, MOV] Store AH Into Flags
        [Theory]
        [InlineData("10011110", "SAHF", "")]
        public void CheckSahfV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [STC, SET1 CY] Set Carry Flag
        [Theory]
        [InlineData("11111001", "STC", "")]
        public void CheckStcV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [STD, SET1 DIR] Set Direction Flag
        [Theory]
        [InlineData("11111101", "STD", "")]
        public void CheckStdV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
        
        #region [STI, EI] Set Interrupt Flag
        [Theory]
        [InlineData("11111011", "STI", "")]
        public void CheckStiV1(string bin, string op, string arg)
            => AssertDecode(bin, op, arg);
        #endregion
    }
}
