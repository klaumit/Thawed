using System;
using System.Linq;
using System.Threading.Tasks;
using Generator.Meta;
using Iced.Intel;
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

            Console.WriteLine(" TODO "); // TODO

            
            var type = typeof(Assembler);
            var names = Desc.GetOpCodeNames();
            foreach (var meth in type.GetMethods())
            {
                var key = meth.Name.ToUpperInvariant();
                if (names.ContainsKey(key) && meth.GetParameters().Length == 0)
                {
                    Console.WriteLine(" * " + meth);
                }
            }
            

            





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