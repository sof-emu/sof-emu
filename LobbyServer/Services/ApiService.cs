using Communicate.Http;
using Data.Interfaces;

namespace LobbyServer.Services
{
    public class ApiService : IService
    {
        protected HttpClient Client;

        public ApiService()
        {
            string host = Configs.Config.GetString("api", "host");
            string port = Configs.Config.GetString("api", "port");
            string token = Configs.Config.GetString("api", "token");

            string baseURL = $"{host}:{port}";

            Client = new HttpClient(baseURL, token);
        }
    }
}