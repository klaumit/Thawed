using CsvHelper.Configuration.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global

namespace PdfMan
{
    public sealed record Clone
    {
        [Index(0)] public string? Op { get; set; }

        [Index(1)] public string? Mnemonic { get; set; }

        [Index(2)] public string? Opcode { get; set; }

        [Index(3)] public string? Size { get; set; }

        [Index(4)] public string? Latency { get; set; }

        [Index(5)] public string? C { get; set; }
        [Index(6)] public string? P { get; set; }
        [Index(7)] public string? A { get; set; }
        [Index(8)] public string? Z { get; set; }
        [Index(9)] public string? S { get; set; }
        [Index(10)] public string? T { get; set; }
        [Index(11)] public string? I { get; set; }
        [Index(12)] public string? D { get; set; }
        [Index(13)] public string? O { get; set; }
    }
}
