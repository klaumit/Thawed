using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Threading.Tasks;

namespace Generator.Common
{
    public sealed class CodeWriter : IDisposable, IAsyncDisposable
    {
        private readonly StringWriter _s;
        private readonly IndentedTextWriter _w;

        public CodeWriter()
        {
            _s = new StringWriter();
            _w = new IndentedTextWriter(_s);
        }

        public async Task WriteLineAsync(string? line = null)
        {
            var txt = line ?? string.Empty;
            if (txt.StartsWith('}'))
                _w.Indent--;
            await _w.WriteLineAsync(txt);
            if (txt.StartsWith('{') && !txt.Contains('}'))
                _w.Indent++;
        }

        public override string ToString()
        {
            return _s.ToString();
        }

        public void Dispose()
        {
            _s.Dispose();
            _w.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _s.DisposeAsync();
            await _w.DisposeAsync();
        }
    }
}