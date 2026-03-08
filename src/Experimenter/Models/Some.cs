using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;
using Generator.Tools;
using static System.IO.Directory;

namespace Experimenter.Models
{
    public class MyInstr
    {
        [Index(0)] public string? Binary { get; set; }
        [Index(1)] public string? Octal { get; set; }
        [Index(2)] public string? Hex { get; set; }
        [Index(3)] public string? Op { get; set; }
        [Index(4)] public string? Args { get; set; }
    }

    public class WinInstr
    {
        [Index(0)] public string? App { get; set; }
        [Index(1)] public string? Input { get; set; }
        [Index(2)] public string? Offset { get; set; }
        [Index(3)] public string? Count { get; set; }
        [Index(4)] public string? Hex { get; set; }
        [Index(5)] public string? Op { get; set; }
        [Index(6)] public string? Arg { get; set; }
        [Index(7)] public string? Left { get; set; }
    }

    public class IntelInstr
    {
        [Index(0)] public string? Group { get; set; }
        [Index(1)] public string? Label { get; set; }
        [Index(2)] public string? Description { get; set; }
        [Index(3)] public string? Format { get; set; }
        [Index(4)] public string? Hex { get; set; }
        [Index(5)] public string? Instruction { get; set; }
        [Index(6)] public string? Bytes { get; set; }
        [Index(7)] public string? Cycles { get; set; }
        [Index(8)] public string? Aliases { get; set; }
    }

    public record MyInstrR(string Hex, string Op, string Arg);

    public record OpGroup(string Op, string Group);

    public record OpName(string Op, string Desc);

    public record OpBin(string Bin, string Op);

    public record OpHex(string Hex, string Op);

    public record Cached(string I, int O, int C, string H, string D, int L);

    public record Sample(string C, string H, string M, string A);

    public record SampleR(string N, string K, string C, string H, string M, string A);
}