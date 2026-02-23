using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Generator.Tools
{
    internal static class JsonTool
    {
        private static JsonSerializerSettings GetConfig(bool format)
        {
            return new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Converters = { new StringEnumConverter() },
                Formatting = format ? Formatting.Indented : Formatting.None
            };
        }

        internal static string ToJson(object? obj, bool format = false)
        {
            var cfg = GetConfig(format);
            return JsonConvert.SerializeObject(obj, cfg);
        }

        public static void ToFile<T>(string file, T obj, bool format = false)
        {
            var cfg = GetConfig(format);
            var txt = JsonConvert.SerializeObject(obj, cfg);
            File.WriteAllText(file, txt, Encoding.UTF8);
        }

        public static T? FromFile<T>(string file, bool format = false)
        {
            if (!File.Exists(file)) return default;
            var txt = File.ReadAllText(file, Encoding.UTF8);
            if (string.IsNullOrWhiteSpace(txt)) return default;
            var cfg = GetConfig(format);
            return JsonConvert.DeserializeObject<T>(txt, cfg)!;
        }
    }
}