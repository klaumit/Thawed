namespace Unasmsys
{
	public record Decoded(
		short Offset,
		int Count,
		string Hex,
		string Dis,
		int Left
	);
}