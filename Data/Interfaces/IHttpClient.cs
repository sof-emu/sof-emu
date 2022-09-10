using RestSharp;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IHttpClient
    {
        Task<T> Get<T>(string path);
        void Post(string path, object obj);
    }
}
