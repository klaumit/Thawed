using System;
using Xunit;

namespace Thawed.UnitTests
{
    public class SpecialTest
    {
        [Theory]
        // Variant 1
        [InlineData("89 D8", "MOV AX,BX")]
        [InlineData("89 C3", "MOV BX,AX")]
        // Variant 2
        [InlineData("8B 47 05", "MOV AX,[BX+05]")]
        [InlineData("89 47 05", "MOV [BX+05],AX")]
        // Variant 3
        [InlineData("8B 4E 10", "MOV CX,[BP+10]")]
        [InlineData("89 4E 10", "MOV [BP+10],CX")]
        public void ShouldDecode(string hex, string expected)
        {
            var bytes = Convert.FromHexString(hex.Replace(" ", ""));
            var reader = new ArrayReader(bytes);
            var decoder = Decoders.GetDecoder();
            var instr = decoder.Decode(reader, true);
            var actual = instr?.ToString();
            Assert.Equal(expected, actual);
        }
    }
}