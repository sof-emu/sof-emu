using Communicate.Http;
using Data.Interfaces;
using Data.Models.Server;
using Nini.Config;

namespace GameServer.Services
{
    public class ApiService : IService
    {
        protected HttpClient Client;
        protected IConfig ApiConfig;

        public ApiService()
        {
            ApiConfig = Program.Config["api"].Configs["api"];

            string host = ApiConfig.GetString("api", "host");
            string port = ApiConfig.GetString("api", "port");
            string token = ApiConfig.GetString("api", "token");

            string baseURL = $"{host}:{port}";

            Client = new HttpClient(baseURL, token);
        }

        public void SendServerInfo(ServerModel server)
        {
            //
        }
    }
}
