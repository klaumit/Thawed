using System.Collections.Generic;

namespace Generator.API
{
    public interface IExtractor
    {
        IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays);
    }
}