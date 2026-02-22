namespace Thawed.Args
{
    public sealed class BracketArg : Arg
    {
        public Arg Val { get; }

        public BracketArg(Arg val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = $"[{Val}]";
            return txt;
        }
    }
}