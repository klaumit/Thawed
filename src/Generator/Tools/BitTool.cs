using System;

namespace Generator.Tools
{
    public static class BitTool
    {
        public static byte[] AsByte(int arg)
        {
            return [(byte)arg];
        }

        public static byte[] AsShort(int arg)
        {
            return BitConverter.GetBytes((short)arg);
        }

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
    }
}