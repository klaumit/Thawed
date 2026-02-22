using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Generator.Meta;
using Generator.Tools;
using Thawed.Auto;
using Xunit;
using static Generator.Tools.CsvTool;

namespace Thawed.UnitTests
{
    public class DecoderTest
    {
        public static IEnumerable<object[]> AllOpcodes =>
            Enum.GetValues<Opcode>().Except([default]).Take(3).Select(d => new object[] { d });

        private const StringComparison Inv = StringComparison.InvariantCultureIgnoreCase;
        private static readonly string Rot = FileTool.GetPath<DecoderTest>();
        private static readonly string Res = Path.Combine(Rot, "Resources");

        [Theory]
        [MemberData(nameof(AllOpcodes))]
        public async Task ShouldDecode(Opcode op)
        {
            var opT = op.ToString();
            var csv = FromFile<Extracted>(Path.Combine(Res, "Win.csv"))
                .Where(x => opT.Equals(x.Op, Inv)).ToArray();
            foreach (var one in csv)
            {
                var input = Convert.FromHexString(one.Input!);
                var output = $"{one.Op} {one.Arg}".Trim();

                throw new InvalidOperationException($"{Convert.ToHexString(input)} => {output}");
            }
        }
    }
}