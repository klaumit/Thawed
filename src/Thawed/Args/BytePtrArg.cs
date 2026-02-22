namespace Thawed.Args
{
    public sealed class BytePtrArg : Arg
    {
        public Arg Val { get; }

        public BytePtrArg(Arg val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = $"Byte Ptr {Val}";
            return txt;
        }
    }
}