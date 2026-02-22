using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Generator.Meta;
using Generator.Tools;
using Thawed.Auto;
using static Generator.Tools.CsvTool;

namespace Thawed.UnitTests
{
    public static class TestTool
    {
        public const StringComparison Inv = StringComparison.InvariantCultureIgnoreCase;

        private static readonly string Rot = FileTool.GetPath<DecoderTest>();
        private static readonly string Res = Path.Combine(Rot, "Resources");

        internal static Dictionary<string, Extracted[]> ReadCsv(string file)
            => FromFile<Extracted>(Path.Combine(Res, file))
                .GroupBy(x => x.Op?.ToUpperInvariant())
                .ToDictionary(k => k.Key!, v => v.ToArray());

        public static IEnumerable<object[]> AllOpcodes =>
            Enum.GetValues<Opcode>().Except([default]).Select(d => new object[] { d });

        private static string GetBinaryStr(string first)
        {
            var txt = first.Split(' ', 2).Take(1).ToArray();
            var num = ushort.Parse($"{txt[0]}", NumberStyles.HexNumber);
            return $"{num:b16}";
        }

        internal static async Task Compare(string t1, string t2)
        {
            var enc = Encoding.UTF8;
            var l1 = await File.ReadAllLinesAsync(t1, enc);
            var l2 = await File.ReadAllLinesAsync(t2, enc);

            foreach (var pair in l1.Zip(l2))
            {
                var first = pair.First.Replace('\t', ' ');
                var second = pair.Second.Replace('\t', ' ');
                var bin = $"({GetBinaryStr(first)}) ";
                Assert.Equal(bin + first, bin + second);
            }
        }
    }
}