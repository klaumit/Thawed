using System.Collections.Generic;
using Unasmsys;

namespace Extracting.API
{
    public interface IExtractor
    {
        IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays);
    }
}