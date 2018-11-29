using IntegrationTestWithIdentity;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
namespace IntegrationTest
{
    public class IntegrationTestWithIdentityTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public IntegrationTestWithIdentityTest(CustomWebApplicationFactory<Startup> factory)
        {

            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task IndexRendersCorrectTitle()
        {
            var response = await _client.GetAsync("https://localhost:44344/About");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Send Email", responseString);
        }        

    }
}
