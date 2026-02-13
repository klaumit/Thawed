using System.Threading.Tasks;

namespace Extracting.API
{
    public interface IExtractor
    {
        Task<object> Decode(byte[] bytes);
    }
}