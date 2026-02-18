using System;
using System.Threading.Tasks;
using Generator.Meta;
using Generator.Tools;
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


            Console.WriteLine(JsonTool.ToJson(Desc.GetOpCodeNames()));
            Console.WriteLine(JsonTool.ToJson(Desc.GetOpCodeAliases()));
            Console.WriteLine(JsonTool.ToJson(Desc.GetOpCodeGroups()));
            Console.WriteLine(JsonTool.ToJson(Desc.GetOpCodeModes()));
            Console.WriteLine(JsonTool.ToJson(Desc.GetOpCodeDescs()));

            
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