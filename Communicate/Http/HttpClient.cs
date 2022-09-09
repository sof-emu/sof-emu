using Data.Interfaces;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Communicate.Http
{
    public class HttpClient : IHttpClient, IDisposable
    {
        protected RestClient Client;

        public HttpClient(string baseURL, string api_token)
        {
            Client = new RestClient(baseURL);
            Client.UseNewtonsoftJson();
            Client.AddDefaultHeaders(new Dictionary<string, string>()
            {
                {"x-api-token", api_token}
            });
        }

        public async Task<T> Get<T>(string path)
        {
            //var request = new RestRequest(path);
            var response = Client.GetJsonAsync<T>(path);
            return response.Result;
        }

        public async void Post<T>()
        {

        }

        public void Dispose()
        {
            
        }
    }
}
