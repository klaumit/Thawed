using System;
using System.Collections.Generic;
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
            await GenerateDecoder(outDir);
            await GenerateInstruct(outDir);

            Console.WriteLine("Done.");
        }

        private static async Task GenerateInstruct(string outDir)
        {
            var w = new CodeWriter();
            await w.WriteLineAsync("using System;");
            await w.WriteLineAsync("using Thawed.Auto;");
            await w.WriteLineAsync("using I = Thawed.Instruction;");
            await w.WriteLineAsync("using H = Thawed.InstructH;");
            await w.WriteLineAsync("using O = Thawed.Auto.Opcode;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("// ReSharper disable RedundantAssignment");
            await w.WriteLineAsync("// ReSharper disable InconsistentNaming");
            await w.WriteLineAsync();
            await w.WriteLineAsync("namespace Thawed.Auto");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("internal static class Instruct");
            await w.WriteLineAsync("{");
            var items = GetInstrDict();
            bool first = true;
            foreach (var pair in items)
            {
                if (first)
                    first = false;
                else
                    await w.WriteLineAsync();
                var lbl = pair.Key.Title();
                await w.WriteLineAsync($"internal static Instruction {lbl}()");
                await w.WriteLineAsync("{");
                await w.WriteLineAsync($" // {pair.Value.Length}");
                await w.WriteLineAsync($"return new I(O.{lbl});");
                await w.WriteLineAsync("}");
            }
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");

            var fuzF = Path.Combine(outDir, "Instruct.cs");
            await File.WriteAllTextAsync(fuzF, w.ToString(), Encoding.UTF8);
        }

        private static async Task GenerateDecoder(string outDir)
        {
            var w = new CodeWriter();
            await w.WriteLineAsync("using System;");
            await w.WriteLineAsync("using Thawed.Auto;");
            await w.WriteLineAsync("using I = Thawed.Auto.Instruct;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("// ReSharper disable RedundantAssignment");
            await w.WriteLineAsync("// ReSharper disable InconsistentNaming");
            await w.WriteLineAsync();
            await w.WriteLineAsync("namespace Thawed.Auto");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("/// <summary>");
            await w.WriteLineAsync("/// Decoder for Intel");
            await w.WriteLineAsync("/// </summary>");
            await w.WriteLineAsync("internal sealed class IntelDecoder : IDecoder");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("public Instruction? Decode(IByteReader r, bool fail)");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("byte b0 = 0;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("var i = (b0 = r.ReadOne()) switch");
            await w.WriteLineAsync("{");
            foreach (var one in Desc.GetInstructs())
            {
                var hex = one.Hex ?? string.Empty;
                if (one.Bytes == "1" && hex.Length / 2 == 1 && !hex.Contains("x"))
                {
                    var lbl = one.Label ?? string.Empty;
                    await w.WriteLineAsync($"0x{hex} => I.{lbl.Title()}(),");
                }
            }
            await w.WriteLineAsync("_ => null");
            await w.WriteLineAsync("};");
            await w.WriteLineAsync();
            await w.WriteLineAsync("return fail ? throw new DecodeException(b0) : i;");
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");

            var fuzF = Path.Combine(outDir, "IntelDecoder.cs");
            await File.WriteAllTextAsync(fuzF, w.ToString(), Encoding.UTF8);
        }

        private static async Task GenerateEnum(string outDir)
        {
            var w = new CodeWriter();
            await w.WriteLineAsync("using System.Collections.Generic;");
            await w.WriteLineAsync("using O = Thawed.OpMeta;");
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
                await w.WriteLineAsync("/// <summary>");
                await w.WriteLineAsync($"/// {instruct.Description}");
                await w.WriteLineAsync($"/// <remarks>{instruct.Group}</remarks>");
                await w.WriteLineAsync("/// </summary>");
                foreach (var i in ig.OrderBy(i => i.Instruction?.Length)
                             .ThenBy(i => i.Instruction))
                {
                    var t = $"[O(\"{i.Format}\", \"{i.Hex}\", \"{i.Instruction}\")]";
                    await w.WriteLineAsync(t);
                }
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
        }

        private static Dictionary<string, Instruct[]> GetInstrDict()
        {
            return Desc.GetInstructs()
                .OrderBy(x => x.Label)
                .GroupBy(x => x.Label)
                .ToDictionary(k => k.Key!, v => v.ToArray());
        }
    }
}