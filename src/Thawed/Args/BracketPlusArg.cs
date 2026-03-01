namespace Thawed.Args
{
    public sealed class BracketP1Arg : Arg
    {
        public Arg Val1 { get; }
        public Arg Val2 { get; internal set; }

        public BracketP1Arg(Arg val1, Arg val2)
        {
            Val1 = val1;
            Val2 = val2;
        }

        public override string ToString()
        {
            var txt = $"[{Val1}+{Val2}]";
            return txt;
        }
    }
}