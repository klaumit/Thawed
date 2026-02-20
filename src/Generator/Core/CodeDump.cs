using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Linq;
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
            await w.WriteLineAsync("using A = Iced.Intel.Assembler;");
            await w.WriteLineAsync();
            await w.WriteLineAsync("namespace Thawed.Auto");
            await w.WriteLineAsync("{");
            await w.WriteLineAsync("public static class Fuzzer");
            await w.WriteLineAsync("{");
            var methods = typeof(Assembler).GetMethods();
            bool isFirst = true;
            foreach (var (name, desc) in Desc.GetOpCodeNames())
            {
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
                    if (name.Equals(key) && meth.GetParameters().Length == 0)
                    {
                        await w.WriteLineAsync($"a.{meth.Name}();");
                    }
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
    }
}