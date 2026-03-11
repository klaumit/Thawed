using Xunit;
using Generator.Tools;
using RefX86Asm;

namespace Thawed.UnitTests
{
    public class XmlTest
    {
        [Fact]
        public void ShouldSerialize()
        {
            const string origFile = "Resources/x86reference.xml";
            var origObj = RefX86.LoadFile(origFile);
            JsonTool.ToFile($"{origFile}.json", origObj, format: true);
            Assert.NotNull(origObj);

            const string copyFile = $"{origFile}.c.xml";
            RefX86.SaveFile(origObj, copyFile);
            var copyObj = RefX86.LoadFile(copyFile);
            Assert.NotNull(copyObj);

            JsonTool.ToFile($"{copyFile}.json", copyObj, format: true);
        }
    }
}