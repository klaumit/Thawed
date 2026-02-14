using System;

namespace Extracting.Tools
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
    }
}