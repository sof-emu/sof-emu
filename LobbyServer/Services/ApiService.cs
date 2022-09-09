using Communicate.Http;
using Data.Interfaces;
using Data.Models.Server;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyServer.Services
{
    public class ApiService
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

        public async Task<List<ServerModel>> RequestServerList()
        {
            List<ServerModel> list = await  Client.Get<List<ServerModel>>("/api/server");
            return list.ToList();
        }

        public async Task<ServerModel> RequestServer(int serverId)
        {
            return await Client
                .Get<ServerModel>($"/api/server/{serverId}");
        }
    }
}