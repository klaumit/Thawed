namespace Thawed.Args
{
    public abstract class Arg
    {
        public static implicit operator Arg(Register reg) => new RegArg(reg);
    }
}
        