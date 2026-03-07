using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Tools
{
    public static class IterTool
    {
        public static IEnumerable<T> Go<T>(int offset, int count, Func<int, T> func)
        {
            for (var i = offset; i < offset + count; i++)
                yield return func(i);
        }

        internal static int[] Iter16Bit()
        {
            return Enumerable.Range(ushort.MinValue, ushort.MaxValue + 1).ToArray();
        }

        internal static int[] Iter8Bit()
        {
            return Enumerable.Range(byte.MinValue, byte.MaxValue + 1).ToArray();
        }

        public static IEnumerable<byte[]> IterRandom(this Random rnd, int count)
        {
            for (var i = 0; i < count; i++)
                yield return Convert.FromHexString($"{rnd.NextInt64():X16}");
        }
    }
}