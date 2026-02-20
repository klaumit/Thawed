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

        public TempFile(string dir, byte[] bytes)
        {
            File = FileTool.WriteNewFile(dir, Bytes = bytes);
        }

        public void Dispose()
        {
            if (!Fil.Exists(File))
                return;
            Fil.Delete(File);
        }
    }
}