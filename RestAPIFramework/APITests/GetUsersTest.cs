using System.Net;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestAPIFramework.Models;
using RestSharp;

namespace RestAPIFramework.APITests
{
    [TestClass]
    public class GetUsersTest
    {
        private string _endPoint;
        private HttpStatusCode _statusCode;
        
        [TestMethod]
        public void GetUsers()
        {
            _endPoint = "api/users?page=2";
            var action = new Actions.Actions();
            var restResponse = action.GetUsers(_endPoint);
            restResponse.page.Should().Be(2);
        }

        [TestMethod]
        public void GetSingleUserTest()
        {
            _endPoint = "api/users=1";
            var action = new Actions.Actions();
            var restResponse = action.GetUsers(_endPoint);
            restResponse.data[0].id.Should().Be(1);
            restResponse.data[0].email.Should().BeNull();
        }

        [TestMethod]
        public void GetSingleUserNotFoundTest()
        {
            _endPoint = "api/users/23";
            var action = new Actions.Actions();
            var restResponse = action.GetUsers(_endPoint);
        }

        [TestMethod]
        public  void GetUsers1()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("api/users?page=2", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);
            var content = response.Content;
            var  x = JsonConvert.DeserializeObject<GetListUsers>(content);
            Assert.AreEqual(2, x.page);
        }

        [TestMethod]
        public void CreateNewUserTest()
        {
            var body = new CreateUserListRequest()
            {
                name = "morpheus",
                job = "leader"
            };
            
            var action = new Actions.Actions();
            var response = action.CreateNewUser(body);
            response.name.Should().Be("morpheus");
        }
        
        [TestMethod]
        public void UpdateUserTest()
        {
            var body = new CreateUserListRequest()
            {
                name = "morpheus",
                job = "zion resident"
            };
            
            var action = new Actions.Actions();
            var response = action.CreateNewUser(body);
            response.job.Should().Be("zion resident");
        }
}
}