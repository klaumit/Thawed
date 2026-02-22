using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator.Meta;
using Thawed.Auto;
using Xunit;
using T = Thawed.UnitTests.TestTool;

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
            foreach (var one in ExW[opT])
            {
                var input = Convert.FromHexString(one.Input!);
                var output = $"{one.Op} {one.Arg}".Trim();

                throw new InvalidOperationException($"{Convert.ToHexString(input)} => {output}");
            }
        }
    }
}