using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Generator.Meta;
using Thawed.Auto;
using Xunit;
using System.IO;
using System.Text;
using T = Thawed.UnitTests.TestTool;

namespace Thawed.UnitTests
{
    public class SpecialTest
    {
        [Theory]
        // Variant 1
        [InlineData("89 D8", "MOV AX,BX")]
        [InlineData("89 C3", "MOV BX,AX")]
        // Variant 2
        [InlineData("8B 47 05", "MOV AX,[BX+5]")]
        [InlineData("89 47 05", "MOV [BX+5],AX")]
        // Variant 3
        [InlineData("8B 4E 10", "MOV CX,Word ptr [BP+0X10]")]
        [InlineData("89 4E 10", "MOV Word ptr [BP+0X10],CX")]
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