using System.Collections.Generic;

namespace Extracting.API
{
    public interface IExtractor
    {
        IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays);
    }
}