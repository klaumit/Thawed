using System.Threading.Tasks;

namespace Extracting
{
    public interface IExtractor
    {
        Task<string> Decode(byte[] bytes);
    }
}