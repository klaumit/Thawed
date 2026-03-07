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

        private static byte[] Clone(byte[] buffer)
        {
            return (byte[])buffer.Clone();
        }

        public static IEnumerable<byte[]> IterArray(int size, int begin = 0, int end = 255)
        {
            if (size < 1) yield break;
            var buffer = new byte[size];
            for (var i1 = begin; i1 <= end; i1++)
            {
                buffer[0] = (byte)i1;
                if (size <= 1)
                {
                    yield return Clone(buffer);
                    continue;
                }
                for (var i2 = begin; i2 <= end; i2++)
                {
                    buffer[1] = (byte)i2;
                    if (size <= 2)
                    {
                        yield return Clone(buffer);
                        continue;
                    }
                    for (var i3 = begin; i3 <= end; i3++)
                    {
                        buffer[2] = (byte)i3;
                        if (size <= 3)
                        {
                            yield return Clone(buffer);
                            continue;
                        }
                        for (var i4 = begin; i4 <= end; i4++)
                        {
                            buffer[3] = (byte)i4;
                            if (size <= 4)
                            {
                                yield return Clone(buffer);
                                continue;
                            }
                            for (var i5 = begin; i5 <= end; i5++)
                            {
                                buffer[4] = (byte)i5;
                                if (size <= 5)
                                {
                                    yield return Clone(buffer);
                                    continue;
                                }
                                for (var i6 = begin; i6 <= end; i6++)
                                {
                                    buffer[5] = (byte)i6;
                                    if (size <= 6)
                                    {
                                        yield return Clone(buffer);
                                        continue;
                                    }
                                    for (var i7 = begin; i7 <= end; i7++)
                                    {
                                        buffer[6] = (byte)i7;
                                        if (size <= 7)
                                        {
                                            yield return Clone(buffer);
                                            continue;
                                        }
                                        for (var i8 = begin; i8 <= end; i8++)
                                        {
                                            buffer[7] = (byte)i8;
                                            if (size <= 8)
                                            {
                                                yield return Clone(buffer);
                                                continue;
                                            }
                                            for (var i9 = begin; i9 <= end; i9++)
                                            {
                                                buffer[8] = (byte)i9;
                                                if (size <= 9)
                                                {
                                                    yield return Clone(buffer);
                                                    continue;
                                                }
                                                yield break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}