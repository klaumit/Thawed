using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator.Meta;
using Thawed.Auto;
using Xunit;
using System.IO;
using System.Text;
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
            var ones = ExW[opT];
            Assert.True(ones.Length >= 1, $"{ones.Length} ?!");

            var src = new SortedSet<string>();
            var got = new SortedSet<string>();

            var decoder = Decoders.GetDecoder();
            var reader = new ArrayReader([]);

            foreach (var one in ones)
            {
                var input = Convert.FromHexString(one.Input!);
                var output = $"{one.Input} {one.Op} {one.Arg}".Trim();
                src.Add(output);

                reader.Reset(input);
                var text = decoder.Decode(reader, fail: false)?.ToString();
                var hex = reader.ToString().ToLower();
                got.Add($"{hex}\t{text?.Trim()}");
            }

            var t1F = $"win_{op}_orig.txt";
            await File.WriteAllLinesAsync(t1F, src, Encoding.UTF8);

            var t2F = $"win_{op}_mine.txt";
            await File.WriteAllLinesAsync(t2F, got, Encoding.UTF8);

            await TestTool.Compare(t1F, t2F);
        }
    }
}