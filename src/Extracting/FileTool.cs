using System;
using System.IO;
using System.Threading.Tasks;

namespace Extracting
{
    internal static class FileTool
    {
        public static string CreateOrGetDir(string name)
        {
            var path = Path.GetFullPath(name);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public static async Task<string> WriteNewFile(string tmpDir, byte[] bytes)
        {
            var ticks = DateTime.Now.Ticks;
            var file = Path.Combine(tmpDir, $"a{ticks}.bin");
            await File.WriteAllBytesAsync(file, bytes);
            return file;
        }
    }
}