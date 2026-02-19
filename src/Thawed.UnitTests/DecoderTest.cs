using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Thawed.UnitTests
{
    public class DecoderTest
    {
        private readonly ITestOutputHelper _outta;
        public DecoderTest(ITestOutputHelper outta) => _outta = outta;

        [Theory]
        [InlineData("x")]
        [InlineData("y")]
        public async Task ShouldDecode(string dialect)
        {
            var cpu = dialect.ToLowerInvariant();
            _outta.WriteLine(cpu);
        }
    }
}