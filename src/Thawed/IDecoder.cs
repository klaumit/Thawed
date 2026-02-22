namespace Thawed
{
    public interface IDecoder
    {
        Instruction? Decode(IByteReader reader, bool fail);
    }
}