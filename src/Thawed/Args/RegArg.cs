namespace Thawed.Args
{
    public sealed class RegArg : Arg
    {
        public Register Val { get; }

        public RegArg(Register val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = Val.ToString().ToUpperInvariant();
            return txt;
        }
    }
}