using Communicate.Interfaces;
using Data.Structures.Template.Server;
using Nini.Config;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.Generic;

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
    }
}
