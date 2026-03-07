using System;
using Generator.Tools;
using Fil = System.IO.File;

namespace Generator.Common
{
    public sealed class TempFile : IDisposable
    {
        public string File { get; }
        public byte[] Bytes { get; }
        public int Size => Bytes.Length;

        public TempFile(string dir, byte[] bytes, char prefix)
        {
            File = FileTool.WriteNewFile(dir, Bytes = bytes, prefix);
        }

        public void Dispose()
        {
            if (!Fil.Exists(File))
                return;
            Fil.Delete(File);
        }
    }
}