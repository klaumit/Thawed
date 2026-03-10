using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class ShiftTest : AbstractDecodeTest
    {
        /// <summary>
        /// Rotate Through Carry Left
        /// <remarks>ROLC</remarks>
        /// </summary>
        [Theory]
        public void CheckRcl(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Rotate Through Carry Right
        /// <remarks>RORC</remarks>
        /// </summary>
        [Theory]
        public void CheckRcr(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Rotate Left
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckRol(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Rotate Right
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckRor(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Shift Arithmetic Right
        /// <remarks>SHRA</remarks>
        /// </summary>
        [Theory]
        public void CheckSar(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Shift Logical Left
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckShl(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Shift Logical Right
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckShr(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
