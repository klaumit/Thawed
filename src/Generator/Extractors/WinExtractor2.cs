using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CliWrap;
using CliWrap.Buffered;
using Generator.API;
using Generator.Tools;

namespace Generator.Extractors
{
    public sealed class WinSiExtractor : WinBaseExtractor, IExtractor
    {
        public override IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            throw new NotImplementedException();
        }
    }
}