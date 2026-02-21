using System;

namespace Thawed
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public sealed class OpMeta : Attribute
    {
        public OpMeta(string format, string hex, string bin)
        {
            Format = format;
            Hex = hex;
            Bin = bin;
        }

        public string Format { get; }
        public string Hex { get; }
        public string Bin { get; }
    }
}