using System;
using System.Collections.Generic;
using Generator.API;

namespace Generator.Tools
{
    public static class ExtTool
    {
        public static IAsyncEnumerable<Decoded[]>? TryDecode(this IExtractor e, byte[][] arrays)
        {
            try
            {
                return e.Decode(arrays);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}