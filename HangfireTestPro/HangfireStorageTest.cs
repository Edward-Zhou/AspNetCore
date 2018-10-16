using HangfirePro;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Hangfire.AspNetCore;
namespace HangfireTestPro
{
    public class HangfireStorageTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public HangfireStorageTest(CustomWebApplicationFactory<Startup> factory)
        {

            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task IndexRendersCorrectTitle()
        {
            var response = await _client.GetAsync("/Home/Index");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Send Email", responseString);
        }
    }
}
