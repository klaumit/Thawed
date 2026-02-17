using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Extracting.Tools
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

        public static string WriteNewFile(string tmpDir, byte[] bytes)
        {
            var ticks = DateTime.Now.Ticks;
            var file = Path.Combine(tmpDir, $"a{ticks}.bin");
            File.WriteAllBytes(file, bytes);
            return file;
        }

        public static IEnumerable<TempFile> Wrap(this IEnumerable<byte[]> arrays, string dir)
        {
            return arrays.Select(a => new TempFile(dir, a));
        }

        public static string GetPath<T>()
        {
            var type = typeof(T);
            var asm = type.Assembly;
            var loc = asm.Location;
            var dll = Path.GetFullPath(loc);
            return Path.GetDirectoryName(dll)!;
        }
    }
}