namespace Generator.API
{
    public record Decoded(

        /* Input */
        string I,

        /* Offset */
        short O,

        /* Count */
        int C,

        /* Hex */
        string H,

        /* Dis */
        string D,

        /* Left */
        int L
    );
}
