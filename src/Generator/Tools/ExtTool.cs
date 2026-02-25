using System;
using System.IO;
using Iced.Intel;

namespace Generator.Tools
{
    public static class ExtTool
    {
        private const BlockEncoderOptions Beo = BlockEncoderOptions.DontFixBranches;

        public static byte[]? GetBytes(this Action<Assembler> func)
        {
            var asm = new Assembler(16);
            func(asm);
            const ulong rip = 0;
            using var stream = new MemoryStream();
            var writer = new StreamCodeWriter(stream);
            try
            {
                asm.Assemble(writer, rip, Beo);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            return stream.ToArray();
        }
    }
}