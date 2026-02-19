using CsvHelper.Configuration.Attributes;

// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global

namespace Generator.Meta
{
    public sealed record Instruct
    {
        [Index(0)] public string? Group { get; set; }

        [Index(1)] public string? Label { get; set; }

        [Index(2)] public string? Description { get; set; }

        [Index(3)] public string? Format { get; set; }

        [Index(4)] public string? Summary { get; set; }

        [Index(5)] public string? Instruction { get; set; }

        [Index(6)] public string? States { get; set; }

        [Index(7)] public string? Aliases { get; set; }

        [Index(8)] public string? UsedIn { get; set; }
    }
}