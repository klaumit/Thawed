using System;
using System.Collections.Generic;

namespace Extracting.Tools
{
    public static class IterTool
    {
        public static IEnumerable<T> Go<T>(int offset, int count, Func<int, T> func)
        {
            for (var i = offset; i < offset + count; i++)
                yield return func(i);
        }
    }
}