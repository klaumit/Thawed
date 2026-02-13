using System.Collections.Generic;
using System.Threading.Tasks;

namespace Extracting.API
{
    public interface IExtractor
    {
        Task<object> Decode(IEnumerable<byte[]> byteArrays);
    }
}