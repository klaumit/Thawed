namespace Unasmsys
{
	internal record Decoded(
		short Offset,
		int Count,
		string Hex,
		string Dis,
		int Left
	);
}