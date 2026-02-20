using System;
using System.Threading.Tasks;
using Generator.Tools;
using System.Collections.Generic;
using System.Linq;
using Generator.Meta;
using System.IO;
using System.Reflection;
using System.Text;
using Iced.Intel;
using CodeWriter = Generator.Common.CodeWriter;

namespace Generator.Core
{
    internal static class DocDump
    {
        internal static async Task Run(Options o)
        {
            if (FileTool.CreateOrGetDir(o.OutputDir) is not { } outDir)
            {
                await Console.Error.WriteLineAsync("No output dir given!");
                return;
            }

            var items = BuildInstructs().ToArray();
            Desc.SetInstructs(items);

            await GenerateFuzzer(outDir);

            Console.WriteLine("Done.");
        }

        private static IEnumerable<Instruct> BuildInstructs()
        {
            const string m = "-";
            var descs = Desc.GetOpCodeDescs();
            var groups = Desc.GetOpCodeGroups();
            var aliases = Desc.GetOpCodeAliases()
                .Select(a => (k: a.Key.Split('/'), v: a.Value.Split('/')))
                .ToArray();
            foreach (var (name, txt) in Desc.GetOpCodeNames())
            {
                var sun = descs.TryGetValue(name, out var sub) ? sub : [[m, m, m, m, m]];
                var grp = groups.TryGetValue(name, out var tmp1) ? tmp1.Last() : m;
                var ali = aliases.FirstOrDefault(a => a.k.Any(t => t.Equals(name)));
                var alia = new SortedSet<string>(ali.k.Concat(ali.v));
                alia.Remove(name);
                if (alia.Count == 0) alia.Add(m);
                foreach (var ssn in sun)
                {
                    yield return new Instruct
                    {
                        Label = name, Group = grp, Aliases = string.Join(" | ", alia),
                        Format = ssn[0], Hex = ssn[1], Instruction = ssn[2],
                        Bytes = ssn[3], Cycles = ssn[4], Description = txt
                    };
                }
            }
        }

        private static async Task GenerateFuzzer(string outDir)
        {
            var w = new CodeWriter();
            await w.WriteLineAsync("using System;");
            await w.WriteLineAsync("using Iced.Intel;");
            await w.WriteLineAsync("using R = Iced.Intel.Register;");
            await w.WriteLineAsync("using L = Iced.Intel.Label;");
            await w.WriteLineAsync("using A = Iced.Intel.Assembler;");
            await w.WriteLineAsync("using AR8 = Iced.Intel.AssemblerRegister8;");
            await w.WriteLineAsync("using AR16 = Iced.Intel.AssemblerRegister16;");
            await w.WriteLineAsync("using AR32 = Iced.Intel.AssemblerRegister32;");
            await w.WriteLineAsync("using AR64 = Iced.Intel.AssemblerRegister64;");
            await w.WriteLineAsync("using ARCR = Iced.Intel.AssemblerRegisterCR;");
            await w.WriteLineAsync("using ARDR = Iced.Intel.AssemblerRegisterDR;");
            await w.WriteLineAsync("using ARTR = Iced.Intel.AssemblerRegisterTR;");
            await w.WriteLineAsync("using AMO = Iced.Intel.AssemblerMemoryOperand;");
            await w.WriteLineAsync("using ARS = Iced.Intel.AssemblerRegisterSegment;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("// ReSharper disable RedundantCast");
            await w.WriteLineAsync();
            await w.WriteLineAsync("namespace Thawed.Auto");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("public static class Fuzzer");
            await w.WriteLineAsync("{");
            var gen = new List<string>();
            var methods = typeof(Assembler).GetMethods();
            var isFirst = true;
            foreach (var (nam, desc) in Desc.GetOpCodeNames())
            {
                var name = nam;
                if (name is "CS" or "DS" or "ES" or "SS" or "LOCK" or "REP" or "REPNE")
                    continue;
                if (name == "XLAT")
                    name = "XLATB";
                if (isFirst)
                    isFirst = false;
                else
                    await w.WriteLineAsync();
                await w.WriteLineAsync("/// <summary>");
                await w.WriteLineAsync($"/// {desc}");
                await w.WriteLineAsync("/// </summary>");
                var mName = $"Do{name.Title()}";
                await w.WriteLineAsync($"public static void {mName}(Action<Action<A>> f)");
                gen.Add(mName);
                await w.WriteLineAsync("{");
                foreach (var meth in methods)
                {
                    var key = meth.Name.ToUpperInvariant();
                    if (!name.Equals(key))
                        continue;
                    var mArgs = FuzzArgs(meth);
                    var mcName = meth.Name;
                    if (mcName is "int" or "in" or "out")
                        mcName = $"@{mcName}";
                    await w.WriteLineAsync($"f(a => a.{mcName}({mArgs}));");
                }
                await w.WriteLineAsync("}");
            }
            await w.WriteLineAsync();
            await w.WriteLineAsync("public static void DoAll(Action<Action<A>> a)");
            await w.WriteLineAsync("{");
            foreach (var ggg in gen)
            {
                await w.WriteLineAsync($"{ggg}(a);");
            }
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");

            var fuzF = Path.Combine(outDir, "Fuzzer.cs");
            await File.WriteAllTextAsync(fuzF, w.ToString(), Encoding.UTF8);
        }

        private static string FuzzArgs(MethodInfo meth)
        {
            var par = meth.GetParameters();
            var list = new List<string>();
            foreach (var prm in par)
            {
                var pt = prm.ParameterType;
                var arg = pt.FullName switch
                {
                    "System.SByte" => "(sbyte)9",
                    "System.Int16" => "(short)9",
                    "System.Int32" => "(int)9",
                    "System.Int64" => "(long)9",
                    "System.Byte" => "(byte)9",
                    "System.UInt16" => "(ushort)9",
                    "System.UInt32" => "(uint)9",
                    "System.UInt64" => "(ulong)9",
                    "Iced.Intel.AssemblerRegister8" => "new AR8(R.AH)",
                    "Iced.Intel.AssemblerRegister16" => "new AR16(R.BX)",
                    "Iced.Intel.AssemblerRegister32" => "new AR32(R.ECX)",
                    "Iced.Intel.AssemblerRegister64" => "new AR64(R.RDX)",
                    "Iced.Intel.AssemblerRegisterCR" => "new ARCR()",
                    "Iced.Intel.AssemblerRegisterDR" => "new ARDR()",
                    "Iced.Intel.AssemblerRegisterTR" => "new ARTR()",
                    "Iced.Intel.AssemblerMemoryOperand" => "new AMO()",
                    "Iced.Intel.AssemblerRegisterSegment" => "new ARS()",
                    "Iced.Intel.Label" => "new L()",
                    _ => pt.FullName!
                };
                list.Add(arg);
            }
            return string.Join(", ", list);
        }
    }
}