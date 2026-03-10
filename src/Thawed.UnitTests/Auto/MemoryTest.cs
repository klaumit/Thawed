using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class MemoryTest : AbstractDecodeTest
    {
        /// <summary>
        /// Load Far Pointer
        /// <remarks>MOV</remarks>
        /// </summary>
        [Theory]
        public void CheckLds(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load Effective Address
        /// <remarks>LDEA</remarks>
        /// </summary>
        [Theory]
        public void CheckLea(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Load Far Pointer
        /// <remarks>MOV</remarks>
        /// </summary>
        [Theory]
        public void CheckLes(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Move
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckMov(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Exchange Register/Memory
        /// <remarks>XCH</remarks>
        /// </summary>
        [Theory]
        public void CheckXchg(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Table Lookup Translation
        /// <remarks>TRANS</remarks>
        /// </summary>
        [Theory]
        public void CheckXlat(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
