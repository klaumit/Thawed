namespace Thawed.Args
{
    public sealed class DispArg : Arg
    {
        public OpWidth Val { get; }

        public DispArg(OpWidth val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = Val.ToSymbol();
            return txt;
        }
    }
}