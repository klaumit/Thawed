namespace Thawed.Args
{
    public sealed class DwordPtrArg : Arg
    {
        public Arg Val { get; }

        public DwordPtrArg(Arg val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = $"DWord Ptr {Val}";
            return txt;
        }
    }
}