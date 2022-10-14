using Data.Structures.Template.Server;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LobbyServer.Services
{
    public class ApiService
    {
        /// <summary>
        /// 
        /// </summary>
        protected RestClient Client;

        /// <summary>
        /// 
        /// </summary>
        public ApiService()
        {
            string host = Configs.Config.GetString("api", "host");
            string port = Configs.Config.GetString("api", "port");
            string token = Configs.Config.GetString("api", "token");

            Client = new RestClient($"{host}:{port}");
            Client.UseNewtonsoftJson();
            Client.AddDefaultHeaders(new Dictionary<string, string>()
            {
                {"x-api-token", token}
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ServerModel>> RequestServerList()
        {
            var request = new RestRequest("/api/server");
            var list = await Client.GetAsync<List<ServerModel>>(request);

            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverId"></param>
        /// <returns></returns>
        public async Task<ServerModel> RequestServer(int serverId)
        {
            var request = new RestRequest($"/api/server/{serverId}");
            var server = await Client.GetAsync<ServerModel>(request);

            return server;
        }
    }
}