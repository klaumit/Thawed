namespace Thawed.Args
{
    public sealed class IntArg : Arg
    {
        public int Val { get; }

        public IntArg(int val)
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