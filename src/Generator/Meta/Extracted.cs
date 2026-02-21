using CsvHelper.Configuration.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global

namespace Generator.Meta
{
    public sealed record Extracted
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
}