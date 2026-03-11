namespace Thawed.Args
{
    public sealed class HideArg : Arg
    {
        public Arg Val { get; }

        public HideArg(Arg val)
        {
            Val = val;
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}