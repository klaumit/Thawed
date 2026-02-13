using System.Threading.Tasks;
using Iced.Intel;

namespace Extracting
{
    public sealed class IcedExtractor : IExtractor
    {
        public Task<object> Decode(byte[] bytes)
        {
            var res = DecodeSync(bytes);
            return Task.FromResult(res);
        }

        private static object DecodeSync(byte[] bytes)
        {
            const int bit = 16;
            var reader = new ByteArrayCodeReader(bytes);
            const ulong ip = 0;
            const DecoderOptions opt = DecoderOptions.NoInvalidCheck;
            var decoder = Decoder.Create(bit, reader, ip, opt);
            var instr = decoder.Decode();
            return instr.ToString();
        }
    }
}