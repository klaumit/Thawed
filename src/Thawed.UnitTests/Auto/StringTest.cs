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
        public void CheckCmpsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Compare String Operands
        /// <remarks>CMPBKW</remarks>
        /// </summary>
        [Theory]
        public void CheckCmpsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load String
        /// <remarks>LDMB</remarks>
        /// </summary>
        [Theory]
        public void CheckLodsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load String
        /// <remarks>LDMW</remarks>
        /// </summary>
        [Theory]
        public void CheckLodsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Move Data From String to String
        /// <remarks>MOVBKB</remarks>
        /// </summary>
        [Theory]
        public void CheckMovsb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Move Data From String to String
        /// <remarks>MOVBKW</remarks>
        /// </summary>
        [Theory]
        public void CheckMovsw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// </summary>
        [Theory]
        public void CheckRep(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// <remarks>REP, REPZ</remarks>
        /// </summary>
        [Theory]
        public void CheckRepe(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Repeat String Operation Prefix
        /// <remarks>REPNZ</remarks>
        /// </summary>
        [Theory]
        public void CheckRepne(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Scan String
        /// <remarks>CMPMB</remarks>
        /// </summary>
        [Theory]
        public void CheckScasb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Scan String
        /// <remarks>CMPMW</remarks>
        /// </summary>
        [Theory]
        public void CheckScasw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Store String
        /// <remarks>STMB</remarks>
        /// </summary>
        [Theory]
        public void CheckStosb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Store String
        /// <remarks>STMW</remarks>
        /// </summary>
        [Theory]
        public void CheckStosw(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
