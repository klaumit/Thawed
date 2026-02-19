using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper;

namespace Generator.Tools
{
    internal static class CsvTool
    {
        private static readonly CultureInfo Cult = CultureInfo.InvariantCulture;

        internal static T[] FromFile<T>(string file)
        {
            using var reader = File.OpenText(file);
            using var csv = new CsvReader(reader, Cult);
            return csv.GetRecords<T>().ToArray();
        }

        internal static void ToFile<T>(string file, IEnumerable<T> items)
        {
            using var writer = File.CreateText(file);
            using var csv = new CsvWriter(writer, Cult);
            csv.WriteRecords(items);
        }
    }
}