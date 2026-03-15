namespace Thawed.Args
{
    public sealed class ShortArg : Arg
    {
        public ushort Val { get; }

        public ShortArg(ushort val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = $"{Val:X4}";
            return txt;
        }
    }
}