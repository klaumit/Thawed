namespace Unasmsys.Core
{
	internal interface IFile
	{
		string Name { get; }
		byte[] Bytes { get; }
	}
}