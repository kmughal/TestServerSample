using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Calling_HomeCtrl_GetMethod_Should_Return_HelloWorldText()
        {
            var text = await GetFakeHelloWorldResponse();
            Assert.Equal(text,"Hello World");
        }


        private async Task<string> GetFakeHelloWorldResponse()
        {
            var client = CreatTestServerAndClient();
            var response = await client.GetAsync("/Home/Get");
            var helloWorldText = await response.Content.ReadAsStringAsync();
            return helloWorldText;

        }

        private HttpClient CreatTestServerAndClient()
        {
            var builder = new WebHostBuilder()
                       .UseContentRoot(@"../../../../Web")
                       .UseEnvironment("Development")
                       .UseStartup<Web.Startup>();

            TestServer testServer = new TestServer(builder);
            
            HttpClient client = testServer.CreateClient();
            return client;
        }
    }
}
