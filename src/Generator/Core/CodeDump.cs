using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Meta;
using Generator.Tools;
using CodeWriter = Generator.Common.CodeWriter;
using static Generator.Tools.FileTool;

namespace Generator.Core
{
    internal static class CodeDump
    {
        internal static async Task Run(Options o)
        {
            if (CreateOrGetDir(o.OutputDir) is not { } outDir)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            if (CreateOrGetDir(o.InputDir) is not { } inpDir)
            {
                await Console.Error.WriteLineAsync("No input dir given!");
                return;
            }

            await GenerateEnum(outDir);

            Console.WriteLine("Done.");
        }

        private static async Task GenerateEnum(string outDir)
        {
            var w = new CodeWriter();
            await w.WriteLineAsync("using System;");
            await w.WriteLineAsync("using System.Collections.Generic;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("// ReSharper disable InconsistentNaming");
            await w.WriteLineAsync("// ReSharper disable IdentifierTypo");
            await w.WriteLineAsync();
            await w.WriteLineAsync("namespace Thawed.Auto");
            await w.WriteLineAsync("{");
            var instrGroups = Desc.GetInstructs()
                .OrderBy(i => i.Label)
                .GroupBy(i => i.Label)
                .ToArray();
            await w.WriteLineAsync("public enum Opcode");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("None = 0,");
            foreach (var ig in instrGroups)
            {
                await w.WriteLineAsync();
                var suf = ig.Key == instrGroups.Last().Key ? "" : ",";
                var instruct = ig.First();
                var etk = instruct.Label?.Title();
                await w.WriteLineAsync($"{etk}{suf}");
            }
            await w.WriteLineAsync("}");
            await w.WriteLineAsync();
            await w.WriteLineAsync("public static class OpcodeExt");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("public static string ToName(this Opcode code) => _names[code];");
            await w.WriteLineAsync();
            await w.WriteLineAsync("private static readonly Dictionary<Opcode, string> _names = new()");
            await w.WriteLineAsync("{");
            foreach (var ig in instrGroups)
            {
                var suf = ig.Key == instrGroups.Last().Key ? "" : ",";
                var instruct = ig.First();
                var etk = instruct.Label?.Title();
                var etv = instruct.Label;
                await w.WriteLineAsync($"{{ Opcode.{etk}, \"{etv}\" }}{suf}");
            }
            await w.WriteLineAsync("};");
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");

            var fuzF = Path.Combine(outDir, "Opcode.cs");
            await File.WriteAllTextAsync(fuzF, w.ToString(), Encoding.UTF8);





            /*
               using D = SuperHot.Dialect;
               using O = SuperHot.OpMeta;

                    /// <summary>
                    /// Add binary
                    /// <remarks>Arithmetic</remarks>
                    /// </summary>
                    [O([D.Sh,D.Sh2,D.Sh2a,D.Sh2e,D.Sh3,D.Sh3e,D.Sh4,D.Sh4a], 2, "#0,r0", "#-100,r10")]
                    Add,
               */
        }
    }
}