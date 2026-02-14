using System.Collections.Generic;

namespace Extracting.API
{
    public interface IExtractor
    {
        IAsyncEnumerable<Dekoded[]> Decode(IEnumerable<byte[]> byteArrays);
    }
}