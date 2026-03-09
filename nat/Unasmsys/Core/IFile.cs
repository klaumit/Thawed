namespace Unasmsys.Core
{
	public interface IFile
	{
		string Name { get; }
		byte[] Bytes { get; }
	}
}