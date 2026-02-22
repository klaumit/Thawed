using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    }
}