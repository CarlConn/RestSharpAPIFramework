using Newtonsoft.Json;
using RestAPIFramework.Models;
using RestSharp;

namespace RestAPIFramework.Actions
{
    public class Actions
    {

        private string endPoint = "api/users?page=2";
        public Users GetUsers()
        {
            var helper = new Helpers.Helpers();
            var client = helper.SetUrl(endPoint);
            var request = helper.CreateGetRequest(endPoint);
            request.RequestFormat = DataFormat.Json;
            var response = helper.GetResponse(client, request);
            var users = helper.GetContent<Users>(response);
            return users;
        }
    }
}