using Xunit;

// ReSharper disable IdentifierTypo

namespace Thawed.UnitTests.Auto
{
    public class StackTest : AbstractDecodeTest
    {
        /// <summary>
        /// Pop Value From the Stack
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckPop(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Pop All General Registers
        /// <remarks>POP</remarks>
        /// </summary>
        [Theory]
        public void CheckPopa(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Pop Stack Into EFLAGS
        /// <remarks>POP</remarks>
        /// </summary>
        [Theory]
        public void CheckPopf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push Word Onto the Stack
        /// <remarks>-</remarks>
        /// </summary>
        [Theory]
        public void CheckPush(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push All General Registers
        /// <remarks>PUSH</remarks>
        /// </summary>
        [Theory]
        public void CheckPusha(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
        
        /// <summary>
        /// Push EFLAGS Onto Stack
        /// <remarks>PUSH</remarks>
        /// </summary>
        [Theory]
        public void CheckPushf(string bin, string op, string arg)
        {
            AssertDecode(bin, op, arg);
        }
    }
}
