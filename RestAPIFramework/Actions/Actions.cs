using Newtonsoft.Json;
using RestAPIFramework.Models;
using RestSharp;

namespace RestAPIFramework.Actions
{
    public class Actions
    {
        //private string endPoint = "api/users?page=2";
        private readonly Helpers.Helpers _helpers; 

        public Actions()
        {
            _helpers = new Helpers.Helpers();
        }

        public GetListUsers GetUsers(string endPoint)
        {
            var helper = new Helpers.Helpers();
            var client = helper.SetUrl();
            var request = helper.CreateGetRequest(endPoint);
            var response = helper.GetResponse(client, request);
            var users = helper.GetContent<GetListUsers>(response);
            return users;
        }

        public CreateUserListResponse CreateNewUser(CreateUserListRequest payLoad)
        {
            var client = _helpers.SetUrl();
            var request = _helpers.CreatePostRequest("api/users", payLoad);
            var response = _helpers.GetResponse(client, request);
            var createUser = _helpers.GetContent<CreateUserListResponse>(response);
            return createUser;
        }
        
        public CreateUserListResponse UpdateUser(CreateUserListRequest payLoad)
        {
            var client = _helpers.SetUrl();
            var request = _helpers.CreatePutRequest("api/users", payLoad);
            var response = _helpers.GetResponse(client, request);
            var createUser = _helpers.GetContent<CreateUserListResponse>(response);
            return createUser;
        }
    }
}