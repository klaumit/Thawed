using System.Text.RegularExpressions;

namespace Extracting
{
    internal static class TextTool
    {
        public static string CleanUp(string txt)
        {
            return Regex.Replace(txt, @"\s+", " ");
        }
    }
}