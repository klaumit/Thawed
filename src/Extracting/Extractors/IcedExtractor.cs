using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extracting.API;
using Iced.Intel;
using Unasmsys;

namespace Extracting.Extractors
{
    public sealed class IcedExtractor : IExtractor
    {
        public Task<object> Decode(IEnumerable<byte[]> byteArrays)
        {
            var res = DecodeSync(byteArrays);
            return Task.FromResult<object>(res);
        }

        public IEnumerable<Decoded[]> DecodeSync(IEnumerable<byte[]> byteArrays)
        {
            foreach (var bytes in byteArrays)
                yield return DecodeOne(bytes).ToArray();
        }

        private static IEnumerable<Decoded> DecodeOne(byte[] bytes)
        {
            const int bit = 16;
            var reader = new ByteArrayCodeReader(bytes);
            const ulong ip = 0;
            const DecoderOptions opt = DecoderOptions.NoInvalidCheck;
            var decoder = Decoder.Create(bit, reader, ip, opt);
            short offset = 0;
            var left = bytes.Length;
            while (decoder.Decode() is var instr)
            {
                if (decoder.LastError == DecoderError.NoMoreBytes)
                    break;
                var dis = instr.ToString();
                var count = instr.Length;
                var part = bytes.Skip(offset).Take(count).ToArray();
                var hex = Convert.ToHexString(part);
                left -= count;
                var res = new Decoded(offset, count, hex, dis, left);
                offset = (short)(offset + count);
                yield return res;
            }
        }
    }
}