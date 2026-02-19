using System;
using System.Threading.Tasks;
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