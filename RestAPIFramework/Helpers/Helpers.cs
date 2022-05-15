using System.IO;
using Newtonsoft.Json;
using RestAPIFramework.Models;
using RestSharp;

namespace RestAPIFramework.Helpers
{
    public class Helpers
    {
        private RestClient _client;
        private RestRequest _request;
        private readonly string baseURL = "https://reqres.in/";

        public RestClient SetUrl(string endPoint)
        {
            //var uri = Path.Combine(baseURL, endPoint);
            _client = new RestClient(baseURL);
            return _client;
        }

        public RestRequest CreateGetRequest(string endPoint)
        {
            _request = new RestRequest(endPoint, Method.Get);
            _request.AddHeader("Accept", "application/json");
            return _request;
        }

        public RestResponse GetResponse(RestClient restClient, RestRequest restRequest)
        {
            var x = restClient.Execute(restRequest);
            return x;
        }

        public T GetContent<T>(RestResponse restResponse)
        {
            var content = restResponse.Content;
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}