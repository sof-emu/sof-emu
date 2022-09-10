using Communicate.Http;
using Data.Interfaces;
using Data.Models.Account;
using Data.Models.Server;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LobbyServer.Services
{
    public class ApiService
    {
        /// <summary>
        /// 
        /// </summary>
        protected HttpClient Client;

        /// <summary>
        /// 
        /// </summary>
        public ApiService()
        {
            string host = Configs.Config.GetString("api", "host");
            string port = Configs.Config.GetString("api", "port");
            string token = Configs.Config.GetString("api", "token");

            string baseURL = $"{host}:{port}";

            Client = new HttpClient(baseURL, token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<AccountData> RequestAccountData(string username)
        {
            var account = await Client.Get<AccountData>($"/api/account/{username}");
            return account;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ServerModel>> RequestServerList()
        {
            List<ServerModel> list = await  Client.Get<List<ServerModel>>("/api/server");
            return list.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public async Task<ServerModel> RequestServer(int serverId)
        {
            return await Client
                .Get<ServerModel>($"/api/server/{serverId}");
        }
    }
}