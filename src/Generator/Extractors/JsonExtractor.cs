using System;
using System.Collections.Generic;
using System.Linq;
using Generator.API;
using Generator.Tools;
using D = System.Collections.Generic.SortedDictionary<string, Generator.API.Decoded>;

namespace Generator.Extractors
{
    public sealed class JsonExtractor : IExtractor, IDisposable
    {
        private readonly IExtractor _extractor;
        private readonly string _file;
        private readonly D _cache;

        public JsonExtractor(IExtractor extractor)
        {
            _extractor = extractor;
            var name = extractor.GetType().Name.Replace("Extractor", "");
            _file = $"cache_{name}.json";
            _cache = JsonTool.FromFile<D>(_file, true) ?? new D();
        }

        public async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            if (byteArrays is not IReadOnlyList<byte[]> list)
                throw new InvalidOperationException($"Not a list! {byteArrays.GetType().FullName}");
            
            var ba = list
                .Select(l => (a: l, c: IsArgCached(l, out var d) ? d : null))
                .ToArray();
            
            var cached = ba.Where(y => y.c != null).Select(x => x.c);
            foreach (var item in cached)
            {
                yield return [item!];
            }
            
            var missing = ba.Where(y => y.c == null).Select(x => x.a);
            await foreach (var real in _extractor.Decode(missing))
            {
                var isDirty = false;
                foreach (var decoded in real)
                {
                    if (decoded.Offset != 0) continue;
                    var rHex = decoded.Hex;
                    if (!_cache.ContainsKey(rHex)) isDirty = true;
                    _cache[rHex] = decoded;
                }
                if (isDirty) Save();
                yield return real;
            }
        }

        private bool IsArgCached(byte[] array, out Decoded? found)
        {
            var hex = array.ToStr();
            if (_cache.TryGetValue(hex, out found))
                return true;

            if (_cache.FirstOrDefault(e => hex.StartsWith(e.Key))
                    is var (_, val) && (found = val) != null)
                return true;

            return false;
        }

        private void Save()
        {
            JsonTool.ToFile(_file, _cache, true);
        }

        public void Dispose()
        {
            Save();
        }

        public IEnumerable<Decoded[]> All
            => _cache.Values.Select(d => new[] { d });
    }
}