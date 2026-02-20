using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Generator.Meta;
using Generator.Tools;
using Iced.Intel;
using static Generator.Tools.FileTool;
using CodeWriter = Generator.Common.CodeWriter;

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

            Console.WriteLine(" TODO "); // TODO


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
                var mName = name.Title();
                await w.WriteLineAsync($"public static void Do{mName}(A a)");
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
                    await w.WriteLineAsync($"a.{mcName}({mArgs});");
                }
                await w.WriteLineAsync("}");
            }
            await w.WriteLineAsync("}");
            await w.WriteLineAsync("}");

            var fuzF = Path.Combine(outDir, "Fuzzer.cs");
            await File.WriteAllTextAsync(fuzF, w.ToString(), Encoding.UTF8);


            // TODO

            var bytes = ExecDump.Assemble(a =>
            {
                a.mov(new AssemblerRegister16(Register.AX), 129);
                a.add(new AssemblerRegister8(Register.AH), new AssemblerRegister8(Register.BL));
                a.ret();
            });
            Console.WriteLine(Convert.ToHexString(bytes));
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
                    "Iced.Intel.AssemblerRegister8" => "new AR8(R.AX)",
                    "Iced.Intel.AssemblerRegister16" => "new AR16(R.BX)",
                    "Iced.Intel.AssemblerRegister32" => "new AR32(R.CX)",
                    "Iced.Intel.AssemblerRegister64" => "new AR64(R.DX)",
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