namespace Thawed.Args
{
    public sealed class ByteArg : Arg
    {
        public byte Val { get; }

        public ByteArg(byte val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = $"{Val:X2}";
            return txt;
        }
    }
}