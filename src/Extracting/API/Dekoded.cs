namespace Extracting.API
{
    public record Dekoded(
        string Input,
        short Offset,
        int Count,
        string Hex,
        string Dis,
        int Left
    );
}