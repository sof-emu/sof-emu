using RestSharp;
using System.Collections.Generic;

namespace Communicate.Http
{
    public class HttpClient
    {
        protected RestClient Client;

        public HttpClient(string baseURL, string api_token)
        {
            Client = new RestClient(baseURL);
            Client.AddDefaultHeaders(new Dictionary<string, string>()
            {
                {"x-api-token", api_token}
            });
        }

        public RestResponse Get(string path)
        {
            var request = new RestRequest(path);
            return Client.Get(request);
        }
    }
}
