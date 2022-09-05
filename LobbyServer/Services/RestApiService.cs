using Communicate;
using Data.Interfaces;

namespace LobbyServer.Services
{
    public class RestApiService : IService
    {
        protected HTTPRequest Client;

        public RestApiService()
        {
            string host = Configs.Config.GetString("restapi", "host");
            string port = Configs.Config.GetString("restapi", "port");
            string token = Configs.Config.GetString("restapi", "token");

            string baseURL = $"{host}:{port}";

            Client = new HTTPRequest(baseURL, token);
        }
    }
}
