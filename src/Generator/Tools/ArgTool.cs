using System;
using System.Collections.Generic;

namespace Generator.Tools
{
    public static class ArgTool
    {
        public static IDictionary<string, string> ParseDict(string? txt)
        {
            var dict = new SortedDictionary<string, string>();
            foreach (var part in txt?.Split(';') ?? [])
            {
                var pt = part.Split('=', 2);
                if (pt.Length != 2)
                    continue;
                var key = pt[0].Trim();
                var val = pt[1].Trim();
                if (key.Length < 1 || val.Length < 1)
                    continue;
                dict[key] = val;
            }
            return dict;
        }

        public static T? As<T>(this IDictionary<string, string> dict, string name)
            => dict.TryGetValue(name, out var value) ? As<T>(value) : default;

        private static T? As<T>(string value)
        {
            var type = $"{typeof(T)}";
            object? obj = null;
            switch (type)
            {
                case "System.Nullable`1[System.Boolean]":
                    if (bool.TryParse(value, out var b)) obj = b;
                    break;
                case "System.Nullable`1[System.Int32]":
                    if (int.TryParse(value, out var i)) obj = i;
                    break;
                default:
                    throw new InvalidOperationException($"{type} '{value}'");
            }
            return (T?)obj;
        }
    }
}