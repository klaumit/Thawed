using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator.Meta;
using Thawed.Auto;
using Xunit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator;
using Xunit;
using T = Thawed.UnitTests.TestTool;
using static Generator.Tools.FileTool;

namespace Thawed.UnitTests
{
    public class DecoderTest
    {
        public static IEnumerable<object[]> AllOpcodes => T.AllOpcodes.Take(3);
        private static readonly Dictionary<string, Extracted[]> ExW = T.ReadCsv("Win.csv");

        [Theory]
        [MemberData(nameof(AllOpcodes))]
        public async Task ShouldDecode(Opcode op)
        {
            var opT = op.ToString().ToUpperInvariant();
            var ones = ExW[opT];
            Assert.True(ones.Length >= 1, $"{ones.Length} ?!");

            foreach (var one in ones)
            {
                var input = Convert.FromHexString(one.Input!);
                var output = $"{one.Op} {one.Arg}".Trim();

                throw new InvalidOperationException($"{Convert.ToHexString(input)} => {output}");
            }
        }
    }
}