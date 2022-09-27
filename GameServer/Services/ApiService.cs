using Communicate.Interfaces;
using Data.Models.Account;
using Data.Models.Creature;
using Data.Models.Player;
using Data.Models.Server;
using Nini.Config;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameServer.Services
{
    public class ApiService : IApiService
    {
        protected RestClient Client;
        protected IConfig ApiConfig;

        public ApiService()
        {
            ApiConfig = GameServer.Config["api"].Configs["api"];

            string host = ApiConfig.GetString("host");
            string port = ApiConfig.GetString("port");
            string token = ApiConfig.GetString("token");

            Client = new RestClient($"{host}:{port}");
            Client.UseNewtonsoftJson();
            Client.AddDefaultHeaders(new Dictionary<string, string>()
            {
                {"x-api-token", token}
            });
        }

        public void Action()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="server"></param>
        public void SendServerInfo(ServerModel server)
        {
            var request = new RestRequest("/api/server")
                .AddJsonBody(server);

            Client.Post(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<AccountData> RequestAccountData(string username)
        {
            var request = new RestRequest($"/api/account/{username}");
            AccountData accountData = await Client.GetAsync<AccountData>(request);
            return accountData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> CheckNameExist(string name)
        {
            var request = new RestRequest($"/api/player/{name}/exist");
            bool result = await Client.GetAsync<bool>(request);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Player>> GetPlayerFromAccountId(int id)
        {
            var request = new RestRequest($"/api/player/account_id/{id}");
            var list = await Client.GetAsync<List<Player>>(request);

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public async Task<GameStats> GetPlayerStats(int playerId)
        {
            var request = new RestRequest($"/api/player/{playerId}/stats");
            var stats = await Client.GetAsync<GameStats>(request);

            return stats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="stats"></param>
        /// <returns></returns>
        public async Task<Player> SendCreatePlayer(Player player, GameStats stats)
        {
            var request = new RestRequest("/api/player")
                .AddJsonBody(player);

            player = await Client.PostAsync<Player>(request);

            request = new RestRequest($"/api/player/{player.Id}/stats")
                .AddJsonBody(stats);

            await Client.PostAsync(request);

            return player;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> SendDeletePlayer(int index, string password)
        {
            var request = new RestRequest($"/api/player/{index}/{password}");
            var result = await Client.DeleteAsync<bool>(request);

            return result;
        }
    }
}
