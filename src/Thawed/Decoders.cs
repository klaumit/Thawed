using Thawed.Auto;

namespace Thawed
{
	public static class Decoders
	{
		public static IDecoder GetDecoder()
		{
			return new IntelDecoder();
		}
	}
}