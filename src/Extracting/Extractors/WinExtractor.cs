using System.Threading.Tasks;
using Extracting.API;

namespace Extracting.Extractors
{
    public sealed class WinExtractor : IExtractor
    {
        public Task<object> Decode(byte[] bytes)
        {
            throw new System.NotImplementedException();
        }
    }
}