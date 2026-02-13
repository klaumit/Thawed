using System;
using Fil = System.IO.File;

namespace Extracting.Tools
{
    public sealed class TempFile : IDisposable
    {
        public string File { get; }

        public TempFile(string dir, byte[] bytes)
        {
            File = FileTool.WriteNewFile(dir, bytes);
        }

        public void Dispose()
        {
            if (!Fil.Exists(File))
                return;
            Fil.Delete(File);
        }
    }
}