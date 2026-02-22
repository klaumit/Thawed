namespace Thawed
{
    public sealed class ArrayReader : IByteReader
    {
        private byte[] _bytes;
        private int _index;

        public ArrayReader(byte[] bytes)
        {
            Reset(bytes);
            _bytes ??= [];
        }

        public byte ReadOne() => _bytes[_index++];

        public override string ToString() => _bytes.ToHexString();

        public void Reset(byte[] bytes)
        {
            _bytes = bytes;
            _index = 0;
        }
    }
}