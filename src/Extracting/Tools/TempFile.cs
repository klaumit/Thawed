using System;
using Fil = System.IO.File;

namespace Extracting.Tools
{
    public sealed class TempFile : IDisposable
    {
        public string File { get; }
        public int Size { get; }

        public TempFile(string dir, byte[] bytes)
        {
            File = FileTool.WriteNewFile(dir, bytes);
            Size = bytes.Length;
        }

        public void Dispose()
        {
            if (!Fil.Exists(File))
                return;
            Fil.Delete(File);
        }
    }
}