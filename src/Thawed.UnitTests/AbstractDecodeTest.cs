using System;
using Generator.Tools;

namespace Thawed.UnitTests
{
    public abstract class AbstractDecodeTest
    {
        protected void AssertDecode(string bin, string op, string arg)
        {
            var bytes = BitTool.ParseBin(bin);
            var hex = Convert.ToHexString(bytes);
            var txt = $"{op} {arg}".Trim();

            var xxxxx = IceTool.Fuck();

            throw new NotImplementedException(hex + " / " + bin + " / " + txt);
        }
    }
}