using System;
using Generator.Tools;
using Xunit;

namespace Thawed.UnitTests
{
    public abstract class AbstractDecodeTest
    {
        private static readonly IDecoder Decoder = Decoders.GetDecoder();

        protected static void AssertDecode(string bin, string op, string arg)
        {
            var bytes = BitTool.ParseBin(bin);
            var ins = IceTool.Parse16(bytes);
            var reader = new ArrayReader(bytes);
            var decoded = Decoder.Decode(reader, fail: true);
            var expected = $"{op} {arg}".Trim();
            var actual = decoded?.ToString();
            var xB = bytes.Format('b');
            var xH = bytes.Format('h');
            var n = Environment.NewLine;
            var dbg = $"({xB}) ({xH}) '{ins}' {ins?.Code} {n}" +
                      $"    e = '{expected}' {n}" +
                      $"    a = '{actual}'";
            Assert.True(expected.Equals(actual), dbg);
        }
    }
}