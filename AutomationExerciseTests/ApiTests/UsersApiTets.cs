using NUnit.Framework;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Net;

namespace AutomationExerciseTests.Tests.ApiTests
{
    public class UsersApiTests
    {
        private HttpClient _client;
        [SetUp]
        public void Setup()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in")
            };
        }
        [TearDown]
        public void Teardown()
        {
            _client.Dispose();
        }

        [Test]
        [Category("API")]

        public async Task GetUsers_ShouldReturnListOfUsers()
        {
            var stopwatch = Stopwatch.StartNew();
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/users?page=2");
            request.Headers.Add("x-api-key", "reqres-free-v1");

           var response = await _client.SendAsync(request);

            stopwatch.Stop();

            // Response time
            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(3000) , "The response took more than 3 seconds.");

            // Status code
            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK), "status code is not OK");

            // Headers
            Assert.That(response.Content.Headers.ContentType.ToString(), Is.EqualTo("application/json; charset=utf-8"));

            // Body
            var json = JObject.Parse(await response.Content.ReadAsStringAsync());
            Assert.That(json["data"], Is.Not.Null, "data property not found");
            Assert.That(json["data"].HasValues, Is.True, "data property is empty");
        }   
        [Test]
        [Category("API")]

        public async Task GetSingleUser_ShouldReturnUserDatax()
        {
         var stopwatch = Stopwatch.StartNew();
         
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/users/2");
            request.Headers.Add("x-api-key", "reqres-free-v1");

            var response = await _client.SendAsync(request);
            
            stopwatch.Stop();

            // Response time
            Assert.That(stopwatch.ElapsedMilliseconds, Is.LessThan(3000), "the response took more than 3 seconds.");

            // Status code
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "status code is not OK");

            //Headers
            Assert.That(response.Content.Headers.ContentType.ToString(), Is.EqualTo("application/json; charset=utf-8"));

            // Body
            var json = JObject.Parse(await response.Content.ReadAsStringAsync());
            var user = json["data"];

            Assert.That(user, Is.Not.Null, "data property not found");
            Assert.That(user["email"]?.ToString(), Does.Contain("@reqres.in"), "invalid email");
            Assert.That(user["first_name"]?.ToString(), Is.Not.Null, "name is empty");
            Assert.That(user["avatar"]?.ToString(), Does.Contain("https://"), "avatar url is not valid");
        }
    }
}
       