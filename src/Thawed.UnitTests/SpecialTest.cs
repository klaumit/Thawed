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
        [InlineData("89 D8", "MOV AX, BX")]
        [InlineData("8B 47 05", "MOV AX, [BX + 5]")]
        [InlineData("8B 4E 10", "MOV AX, [AX + DX + 16]")]
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

// MOV AX, BX = 89 D8
// MOV AX, [BX + 5] = 8B 47 05
// MOV AX, [AX + DX + 16] = 8B 4E 10

