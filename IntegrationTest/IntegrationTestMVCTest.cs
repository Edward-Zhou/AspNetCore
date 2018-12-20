using IntegrationTestMVC;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestFixture]
    public class IntegrationTestMVCTest
    {
        [Test]
        public async Task Test()
        {
            var path = Assembly.Load(new AssemblyName("IntegrationTestMVC")).Location;
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                                .UseContentRoot(@"D:\Edward\SourceCode\AspNetCore\Tests\IntegrationTestMVC")
                                .UseStartup<Startup>()
                );
            var configuration = server.Host.Services.GetRequiredService<IConfiguration>();
            var connection = configuration.GetConnectionString("DefaultConnection");
            var testReg = server.Host.Services.GetRequiredService<ITestReg>();
            var test = testReg.HelloWorld();
            var response = await server.CreateClient().GetAsync(@"/test");
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);

            var result = await response.Content.ReadAsStringAsync();

        }
    }
}
