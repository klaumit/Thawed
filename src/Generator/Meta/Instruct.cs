using CsvHelper.Configuration.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global

namespace Generator.Meta
{
    public sealed record Instruct
    {
        [Index(0)] public string? Group { get; set; }

        [Index(1)] public string? Label { get; set; }

        [Index(2)] public string? Instruction { get; set; }

        [Index(3)] public string? Hex { get; set; }

        [Index(4)] public string? Bin { get; set; }

        [Index(5)] public string? Bytes { get; set; }

        [Index(6)] public string? Cycles { get; set; }

        [Index(7)] public string? Aliases { get; set; }
    }
}