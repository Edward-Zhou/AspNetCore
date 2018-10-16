using HangfirePro;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Hangfire.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HangfireTestPro
{
    public class HangfireStorageStartupTest : IClassFixture<CustomWebApplicationFactory<StartupTest>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<StartupTest> _factory;

        public HangfireStorageStartupTest(CustomWebApplicationFactory<StartupTest> factory)
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
