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

        internal static T FromFile<T>(string file, bool format = false)
        {
            var txt = File.ReadAllText(file, Encoding.UTF8);
            var cfg = GetConfig(format);
            return JsonConvert.DeserializeObject<T>(txt, cfg)!;
        }
    }
}