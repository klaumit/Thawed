using System;
using System.Linq;

namespace Thawed
{
    public sealed class DecodeException : Exception
    {
        public DecodeException(params byte?[] bytes)
            : base($"[{string.Join(" ", bytes.Select(b => $"{b:X2}"))}] not decoded!")
        {
        }
    }
}