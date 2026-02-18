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

        /*
           opCodeAliases.json
           opCodeDescs.json
           opCodeGroups.json
           opRmModes.json
         */

    }
}