namespace Thawed.Args
{
    public abstract class Arg
    {
        public static implicit operator Arg(Register v) => new RegArg(v);

        public static implicit operator Arg(byte v) => new ByteArg(v);
        
        public static implicit operator Arg(int v) => new IntArg(v);
    }
}