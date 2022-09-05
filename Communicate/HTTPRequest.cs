using RestSharp;
using System.Collections.Generic;

namespace Communicate
{
    public class HTTPRequest
    {
        protected RestClient Client;

        public HTTPRequest(string baseURL, string api_token)
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
