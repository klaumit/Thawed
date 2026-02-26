using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Generator.Extractors;
using Generator.Tools;
using Iced.Intel;
using E = Generator.Tools.ExtTool;
using static Iced.Intel.AssemblerRegisters;
using A = Iced.Intel.Assembler;
using AR8 = Iced.Intel.AssemblerRegister8;
using AR16 = Iced.Intel.AssemblerRegister16;
using AMO = Iced.Intel.AssemblerMemoryOperand;

namespace Crppy
{
    internal static class Program
    {
        private static readonly WinExtractor Win = new();

        private static async Task Main(string[] args)
        {
            var byteArrays = FuzzerX.AddFuzzy([]);
            await foreach (var lines in Win.Decode(byteArrays))
            {
                foreach (var line in lines)
                {
                    if (line.Offset != 0) continue;
                    var bytes = Convert.FromHexString(line.Hex);
                    var parts = line.Dis.Split("  ", 2);
                    var op = parts[0].Trim();
                    var ag = parts[1].Trim();
                    var bin = bytes.Format('b');
                    var oct = bytes.Format('o');
                    var hex = bytes.Format('h');
                    Console.WriteLine($" {bin} | {oct} | {hex} | {op,-5} | {ag}");
                }
            }
        }
    }
}