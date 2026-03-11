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
            var hex = Convert.ToHexString(bytes);
            var ins = IceTool.Parse16(bytes);
            var reader = new ArrayReader(bytes);
            var decoded = Decoder.Decode(reader, fail: true);
            var expected = $"{op} {arg}".Trim();
            var actual = decoded?.ToString();
            Assert.Equal(expected, actual);
        }
    }
}