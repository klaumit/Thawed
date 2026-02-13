using System.Linq;
using System.Text.RegularExpressions;

namespace Extracting.Tools
{
    internal static class TextTool
    {
        public static string CleanUp(string txt)
        {
            return Regex.Replace(txt, @"\s+", " ");
        }

        public static string[] ToLines(string text)
        {
            var lines = text.Trim().Split('\n');
            lines = lines.Select(l => l.Trim()).ToArray();
            return lines;
        }

        public static string[] ToCol(string one)
        {
            var item = one.TrimStart('"').TrimEnd('"');
            return item.Split("\",\"");
        }
    }
}