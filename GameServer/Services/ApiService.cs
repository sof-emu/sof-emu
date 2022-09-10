using Communicate.Http;
using Data.Interfaces;
using Data.Models.Account;
using Data.Models.Server;
using Nini.Config;
using System.Threading.Tasks;

namespace GameServer.Services
{
    public class ApiService : IService
    {
        protected HttpClient Client;
        protected IConfig ApiConfig;

        public ApiService()
        {
            ApiConfig = GameServer.Config["api"].Configs["api"];

            string host = ApiConfig.GetString("host");
            string port = ApiConfig.GetString("port");
            string token = ApiConfig.GetString("token");

            string baseURL = $"{host}:{port}";

            Client = new HttpClient(baseURL, token);
        }

        public void SendServerInfo(ServerModel server)
        {
            Client.Post("/api/server", server);
        }

        public async Task<AccountData> RequestAccountData(string username)
        {
            var account = await Client.Get<AccountData>($"/api/account/{username}");
            return account;
        }
    }
}
