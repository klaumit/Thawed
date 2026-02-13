using System.Collections.Generic;
using System.Threading.Tasks;
using Extracting.API;
using Iced.Intel;

namespace Extracting.Extractors
{
    public sealed class IcedExtractor : IExtractor
    {
        public Task<object> Decode(IEnumerable<byte[]> byteArrays)
        {
            var res = DecodeSync(byteArrays);
            return Task.FromResult(res);
        }

        public object DecodeSync(IEnumerable<byte[]> byteArrays)
        {
            foreach (var bytes in byteArrays)
            {
                const int bit = 16;
                var reader = new ByteArrayCodeReader(bytes);
                const ulong ip = 0;
                const DecoderOptions opt = DecoderOptions.NoInvalidCheck;
                var decoder = Decoder.Create(bit, reader, ip, opt);
                var instr = decoder.Decode();

                throw new System.NotImplementedException(instr.ToString());
            }

            throw new System.NotImplementedException();
        }
    }
}