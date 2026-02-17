namespace Generator.API
{
    public record Decoded(
        string Input,
        short Offset,
        int Count,
        string Hex,
        string Dis,
        int Left
    );
}
