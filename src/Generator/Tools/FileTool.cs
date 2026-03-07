using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Generator.Common;

namespace Generator.Tools
{
    public static class FileTool
    {
        public static string? CreateOrGetDir(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;
            var path = Path.GetFullPath(name);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path;
        }

        public static string WriteNewFile(string tmpDir, byte[] bytes, char p)
        {
            var ticks = DateTime.Now.Ticks;
            var file = Path.Combine(tmpDir, $"{p}{ticks}.bin");
            File.WriteAllBytes(file, bytes);
            return file;
        }

        public static IEnumerable<TempFile> Wrap(this IEnumerable<byte[]> arrays, string dir, char p = 'a')
        {
            return arrays.Select(a => new TempFile(dir, a, p));
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