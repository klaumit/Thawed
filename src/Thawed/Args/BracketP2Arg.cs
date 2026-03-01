namespace Thawed.Args
{
    public sealed class BracketP2Arg : Arg
    {
        public Arg Val1 { get; }
        public Arg Val2 { get; }
        public Arg Val3 { get; }

        public BracketP2Arg(Arg val1, Arg val2, Arg val3)
        {
            Val1 = val1;
            Val2 = val2;
            Val3 = val3;
        }

        public override string ToString()
        {
            var txt = $"[{Val1}+{Val2}+{Val3}]";
            return txt;
        }
    }
}