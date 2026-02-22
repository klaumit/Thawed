namespace Thawed.Args
{
    public sealed class WordPtrArg : Arg
    {
        public Arg Val { get; }

        public WordPtrArg(Arg val)
        {
            Val = val;
        }

        public override string ToString()
        {
            var txt = $"Word Ptr {Val}";
            return txt;
        }
    }
}