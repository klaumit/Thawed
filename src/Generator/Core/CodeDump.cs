using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generator.Common;
using Generator.Meta;
using Generator.Tools;
using static Generator.Tools.CsvTool;
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
            await w.WriteLineAsync("using A = Thawed.Args.Arg;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("// ReSharper disable RedundantAssignment");
            await w.WriteLineAsync("// ReSharper disable InconsistentNaming");
            await w.WriteLineAsync();
            await w.WriteLineAsync("namespace Thawed.Auto");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("internal static class Instruct");
            await w.WriteLineAsync("{");
            var items = GetInstrDict();
            var first = true;
            foreach (var pair in items)
            {
                if (first)
                    first = false;
                else
                    await w.WriteLineAsync();
                var lbl = pair.Key.Title();
                await w.WriteLineAsync($"internal static I {lbl}(params A[] args)");
                await w.WriteLineAsync("{");
                await w.WriteLineAsync($"return new I(O.{lbl}, args);");
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
            await w.WriteLineAsync("using R = Thawed.Register;");
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

            const string defect = "???";
            var extracted = LoadCsv("Win.csv");
            var tree = BuildTree(extracted);
            foreach (var fN in tree.Nodes ?? [])
            {
                var fRg = fN.Raw?.GroupBy(x => x.Hex);
                var fR = fRg?.FirstOrDefault()?.FirstOrDefault();
                var op = fR?.Op ?? "";
                if (fR != null && op != defect && !op.EndsWith(':'))
                {
                    var meth = $"I.{op.Title()}";
                    var mArgs = string.Join(", ", ParseArgs(fR.Arg));
                    await w.WriteLineAsync($"0x{fR.Hex} => {meth}({mArgs}),");
                }
                else
                {
                    await w.WriteLineAsync($"0x{fN.Hex} => null,");
                }
            }

            await w.WriteLineAsync("};");
            await w.WriteLineAsync();
            await w.WriteLineAsync("return fail ? throw new DecodeException(b0) : i;");
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");

            var fuzF = Path.Combine(outDir, "IntelDecoder.cs");
            await File.WriteAllTextAsync(fuzF, w.ToString(), Encoding.UTF8);
        }

        private static string[] ToParts(string hex)
        {
            return hex.Chunk(2).Select(h => $"{h[0]}{h[1]}").ToArray();
        }

        private static IEnumerable<string?> ParseArgs(string? args)
        {
            foreach (var arg in (args ?? "").Split(','))
            {
                var ia = arg switch
                {
                    "AX" => "R.ax",
                    "BX" => "R.bx",
                    "CX" => "R.cx",
                    "DX" => "R.dx",
                    "AL" => "R.al",
                    "CS" => "R.cs",
                    "DS" => "R.ds",
                    "ES" => "R.es",
                    "SS" => "R.ss",
                    "BP" => "R.bp",
                    "SP" => "R.sp",
                    "DI" => "R.di",
                    "SI" => "R.si",
                    "" => null,
                    _ => $"? /* {arg} */"
                };
                yield return ia;
            }
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

        private static Dictionary<string, Extracted[]> LoadCsv(string name)
        {
            return FromFile<Extracted>(Path.Combine(GetPath<Options>(), "tmp", name))
                .OrderBy(x => x.Hex)
                .GroupBy(x => x.Hex)
                .ToDictionary(k => k.Key!, v => v.ToArray());
        }

        private static HashNode BuildTree(Dictionary<string, Extracted[]> extracted)
        {
            var tree = new HashNode();
            foreach (var (hex, value) in extracted)
            {
                var parts = ToParts(hex);
                var curr = string.Empty;
                var cuIt = tree;
                foreach (var part in parts)
                {
                    curr += part;
                    var exist = (cuIt.Nodes ??= [])
                        .FirstOrDefault(n => n.Hex != null && n.Hex.Equals(part));
                    if (exist == null)
                        cuIt.Nodes.Add(cuIt = new HashNode { Path = curr, Hex = part });
                    else
                        cuIt = exist;
                    var set = cuIt.Raw ??= [];
                    foreach (var one in value.Where(v => v.Hex!.Equals(curr)))
                        set.Add(one);
                }
            }
            return tree;
        }
    }
}