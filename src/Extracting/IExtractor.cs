using System.Threading.Tasks;

namespace Extracting
{
    public interface IExtractor
    {
        Task<object> Decode(byte[] bytes);
    }
}