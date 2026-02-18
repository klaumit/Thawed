using System.Collections.Generic;
using System.IO;
using static Generator.Tools.FileTool;
using static Generator.Tools.JsonTool;

namespace Generator.Meta
{
    public sealed class Desc
    {
        private static readonly string Dir = Path.GetFullPath(
            Path.Combine(GetPath<Desc>(), "..", "..", "..", "Meta")
        );

        // instructs.csv

        public static string[] GetOpCodeNames()
            => FromFile<string[]>(Path.Combine(Dir, "opCodeNames.json"));

        public static IDictionary<string, string> GetOpCodeAliases()
            => FromFile<SortedDictionary<string, string>>(Path.Combine(Dir, "opCodeAliases.json"));

        public static IDictionary<string, string[]> GetOpCodeGroups()
            => FromFile<SortedDictionary<string, string[]>>(Path.Combine(Dir, "opCodeGroups.json"));

        public static IDictionary<string, string[]> GetOpCodeModes()
            => FromFile<SortedDictionary<string, string[]>>(Path.Combine(Dir, "opRmModes.json"));

        public static IDictionary<string, string[][]> GetOpCodeDescs()
            => FromFile<SortedDictionary<string, string[][]>>(Path.Combine(Dir, "opCodeDescs.json"));
    }
}