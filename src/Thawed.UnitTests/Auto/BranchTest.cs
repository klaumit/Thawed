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
        public void CheckJa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Below
        /// <remarks>BC, BL, JC</remarks>
        /// </summary>
        [Theory]
        public void CheckJb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Below or Equal
        /// <remarks>BNH</remarks>
        /// </summary>
        [Theory]
        public void CheckJbe(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Carry
        /// </summary>
        [Theory]
        public void CheckJc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If CX Register is Zero
        /// <remarks>BCWZ</remarks>
        /// </summary>
        [Theory]
        public void CheckJcxz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Greater
        /// <remarks>BGT</remarks>
        /// </summary>
        [Theory]
        public void CheckJg(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Greater or Equal
        /// <remarks>BGE</remarks>
        /// </summary>
        [Theory]
        public void CheckJge(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Less
        /// <remarks>BLT</remarks>
        /// </summary>
        [Theory]
        public void CheckJl(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Less or Equal
        /// <remarks>BLE</remarks>
        /// </summary>
        [Theory]
        public void CheckJle(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump Short If Not Below
        /// <remarks>BNC, BNL, JAE, JNC</remarks>
        /// </summary>
        [Theory]
        public void CheckJnb(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Carry
        /// </summary>
        [Theory]
        public void CheckJnc(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump if Not Equal
        /// </summary>
        [Theory]
        public void CheckJne(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Overflow
        /// <remarks>BNV</remarks>
        /// </summary>
        [Theory]
        public void CheckJno(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Parity
        /// </summary>
        [Theory]
        public void CheckJnp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Sign
        /// <remarks>BP</remarks>
        /// </summary>
        [Theory]
        public void CheckJns(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Not Zero
        /// <remarks>BNE, BNZ, JNE</remarks>
        /// </summary>
        [Theory]
        public void CheckJnz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Overflow
        /// <remarks>BV</remarks>
        /// </summary>
        [Theory]
        public void CheckJo(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Parity
        /// </summary>
        [Theory]
        public void CheckJp(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump Short If Parity Even
        /// <remarks>BPE, JP</remarks>
        /// </summary>
        [Theory]
        public void CheckJpe(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump Short If Parity Odd
        /// <remarks>BPO, JNP</remarks>
        /// </summary>
        [Theory]
        public void CheckJpo(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Sign
        /// <remarks>BN</remarks>
        /// </summary>
        [Theory]
        public void CheckJs(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Jump If Zero
        /// <remarks>BE, BZ, JE</remarks>
        /// </summary>
        [Theory]
        public void CheckJz(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
