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

        private JsonExtractor(IExtractor extractor)
        {
            _extractor = extractor;
            var name = extractor.GetType().Name.Replace("Extractor", "");
            _file = $"cache_{name}.json";
            _cache = JsonTool.FromFile<D>(_file, true) ?? new D();
        }

        public async IAsyncEnumerable<Decoded[]> Decode(IEnumerable<byte[]> byteArrays)
        {
            foreach (var byteArray in byteArrays)
            {
                var hex = byteArray.ToStr();
                if (_cache.TryGetValue(hex, out var found))
                {
                    yield return [found];
                    continue;
                }
                if (_cache.FirstOrDefault(e => hex.StartsWith(e.Key))
                    is { Value: not null } partly)
                {
                    yield return [partly.Value];
                    continue;
                }
                await foreach (var real in _extractor.Decode([byteArray]))
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
        }

        private void Save()
        {
            JsonTool.ToFile(_file, _cache, true);
        }

        public void Dispose()
        {
            Save();
        }
    }
}