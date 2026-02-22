using System;
using Thawed.Auto;
using I = Thawed.Instruction;

namespace Thawed
{
    internal static class InstructH
    {
        public static I? Bad(byte b0)
        {
            throw new NotImplementedException($"{b0} ?!");
        }

        public static I Aam()
        {
            return new I(Opcode.Aam);
        }

        public static I Aad()
        {
            return new I(Opcode.Aad);
        }

        public static I Aaa()
        {
            return new I(Opcode.Aaa);
        }
    }
}