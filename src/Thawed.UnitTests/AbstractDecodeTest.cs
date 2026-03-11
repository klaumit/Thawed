using System;
using Generator.Tools;

namespace Thawed.UnitTests
{
    public abstract class AbstractDecodeTest
    {
        protected static void AssertDecode(string bin, string op, string arg)
        {
            var bytes = BitTool.ParseBin(bin);
            var hex = Convert.ToHexString(bytes);
            var ins = IceTool.Parse16(bytes);
            var txt = $"{op} {arg}".Trim();

            throw new NotImplementedException(hex + " / " + bin + " / " + txt + " / " + ins);
        }
    }
}