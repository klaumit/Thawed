using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper;

namespace Generator.Tools
{
    internal static class CsvTool
    {
        private static readonly CultureInfo Cult = CultureInfo.InvariantCulture;

        internal static T[] FromFile<T>(string file, bool format = false)
        {
            using var reader = File.OpenText(file);
            using var csv = new CsvReader(reader, Cult);
            return csv.GetRecords<T>().ToArray();
        }
    }
}