using System;
using System.Collections.Generic;
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





            var items = BuildInstructs().ToArray();
            Desc.SetInstructs(items);










            var bytes = ExecDump.Assemble(a =>
            {
                a.mov(new AssemblerRegister16(Register.AX), 129);
                a.add(new AssemblerRegister8(Register.AH), new AssemblerRegister8(Register.BL));
                a.ret();
            });

            Console.WriteLine(Convert.ToHexString(bytes));
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
    }
}