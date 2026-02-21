using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thawed.Auto;
using Xunit;

namespace Thawed.UnitTests
{
    public class DecoderTest
    {
        public static IEnumerable<object[]> AllOpcodes =>
            Enum.GetValues<Opcode>().Except([default]).Take(3).Select(d => new object[] { d });

        [Theory]
        [MemberData(nameof(AllOpcodes))]
        public async Task ShouldDecode(Opcode op)
        {
            var cpu = op.ToString().ToLowerInvariant();
            
         
            
            
            
            
            
            
            
            
            
            throw new InvalidOperationException(cpu + " !");

        }
    }
}