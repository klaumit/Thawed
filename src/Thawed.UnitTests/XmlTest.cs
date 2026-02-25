using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Generator.Meta;
using Thawed.Auto;
using Xunit;
using System.IO;
using System.Text;
using Generator.Tools;
using RefX86Asm;
using T = Thawed.UnitTests.TestTool;

namespace Thawed.UnitTests
{
    public class XmlTest
    {
        [Fact]
        public void ShouldSerialize()
        {
            const string origFile = "data/x86reference.xml";
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