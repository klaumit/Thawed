namespace Thawed.Args
{
    public sealed class FarArg : Arg
    {
        public Arg Val { get; }

        public FarArg(Arg val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = $"FAR {Val}";
            return txt;
        }
    }
}