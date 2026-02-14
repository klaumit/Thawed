using System;
using System.Collections.Generic;
using System.Linq;
using Extracting.API;
using Extracting.Tools;
using Iced.Intel;

#pragma warning disable CS1998

namespace Extracting.Extractors
{
    public sealed class IcedExtractor : IExtractor
    {
        public async IAsyncEnumerable<Dekoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var bytes in byteArrays)
                yield return DecodeOne(bytes).ToArray();
        }

        private static IEnumerable<Dekoded> DecodeOne(byte[] bytes)
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
                var res = new Dekoded(bytes.ToStr(), offset, count, hex, dis, left);
                offset = (short)(offset + count);
                yield return res;
            }
        }
    }
}