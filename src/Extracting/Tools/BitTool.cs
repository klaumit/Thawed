using System;

namespace Extracting.Tools
{
    public static class BitTool
    {
        public static byte[] AsShortB(int arg)
        {
            var val = (short)arg;
            return BitConverter.GetBytes(val);
        }
    }
}