using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class IntegrationTestMVCUnitTest : IClassFixture<WebApplicationFactory<TestStartup>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<TestStartup> _factory;

        public IntegrationTestMVCUnitTest(WebApplicationFactory<TestStartup> factory)
        {

            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task IndexRendersCorrectTitle()
        {
            var response = await _client.GetAsync(@"/test");
        }

        [Test]
        public async Task Test()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<IntegrationTestMVC.TestStartup>()
                .UseContentRoot(@"D:\Edward\SourceCode\AspNetCore\Tests\IntegrationTestMVC")
                .UseEnvironment("Development")
                .UseUrls("http://localhost:5000")
                .UseConfiguration(new ConfigurationBuilder()
                    .SetBasePath(@"D:\Edward\SourceCode\AspNetCore\Tests\IntegrationTestMVC") // @"C:\Users\usuario\source\repos\CreditCardApp\CreditCardApp"
                    .AddJsonFile("appsettings.json")
                    .Build()));
            var response = await server.CreateClient().GetAsync(@"/test");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task UploadFileTest()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                        .UseStartup<IntegrationTestMVC.TestStartup>()
                        .UseContentRoot(@"D:\Edward\SourceCode\AspNetCore\Tests\IntegrationTestMVC")
                        .UseEnvironment("Development")
                        .UseUrls("http://localhost:5000")
                        .UseConfiguration(new ConfigurationBuilder()
                            .SetBasePath(@"D:\Edward\SourceCode\AspNetCore\Tests\IntegrationTestMVC") // @"C:\Users\usuario\source\repos\CreditCardApp\CreditCardApp"
                            .AddJsonFile("appsettings.json")
                            .Build()));

            // Arrange
            var expectedContent = "1";
            var expectedContentType = "application/json; charset=utf-8";

            var url = "/AddFile";
            var client = server.CreateClient();

            // Act
            var file = System.IO.File.OpenRead(@"C:\Users\edwardzh\Desktop\T1.PNG");
            HttpContent fileStreamContent = new StreamContent(file);

            var formData = new MultipartFormDataContent
                            {
                                { fileStreamContent, "file", "file.pdf" }
                            };

            var response = await client.PostAsync(url, formData);

            fileStreamContent.Dispose();
            formData.Dispose();

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
        }

        [Xunit.Theory]
        [InlineData("http://localhost/api/v1/Book/")]
        public async Task TestHttp(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act           

            var body = "{}";
            using (var content = new StringContent(body, Encoding.UTF8, "application/json"))
            {

                var response = await client.PostAsync(url, content);

                // Assert
                response.EnsureSuccessStatusCode(); //Failed here with internal server error
                Xunit.Assert.Equal(StatusCodes.Status200OK,
                    (int)(response.StatusCode));
            }
        }
    }
}
