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
        [TestMethod]
        public void GetUsers()
        {
            var action = new Actions.Actions();
            var restResponse = action.GetUsers();
            Assert.AreEqual(2, restResponse.page);
        }
        
        [TestMethod]
        public  void GetUsers1()
        {
            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("api/users?page=2", Method.Get);
            request.AddHeader("Accept", "application/json");
            RestResponse response = client.Execute(request);
            var content = response.Content;
            var  x = JsonConvert.DeserializeObject<Users>(content);
            Assert.AreEqual(2, x.page);
        }
}
}