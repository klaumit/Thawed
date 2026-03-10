using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Tools
{
    public static class BitTool
    {
        public static string[] SplitP(string txt, int len = 2)
            => txt.Chunk(len).Select(c => new string(c)).ToArray();

        public static byte[] AsByte(int arg)
        {
            return [(byte)arg];
        }

        public static byte[] AsShort(int arg)
        {
            return BitConverter.GetBytes((short)arg);
        }

        public static string Format(this IEnumerable<byte> bytes, char mode, string sep = " ")
            => string.Join(sep, bytes.Select(b => mode switch
            {
                'b' => Convert.ToString(b, 2).PadLeft(8, '0'),
                'o' => Convert.ToString(b, 8).PadLeft(3, '0'),
                'h' => Convert.ToString(b, 16).PadLeft(2, '0'),
                _ => throw new InvalidOperationException($"{mode} ?!")
            }));

        public static string ToStr(this byte[] bytes)
        {
            return Convert.ToHexString(bytes);
        }

        public static byte[]? ParseHex(string txt)
        {
            try
            {
                return Convert.FromHexString(txt);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static byte[] ParseBin(string txt)
        {
            return txt.Replace(" ", "").Chunk(8).Select(c =>
                Convert.ToByte(new string(c), 2)).ToArray();
        }
    }
}