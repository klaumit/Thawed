using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Generator
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
    }
}