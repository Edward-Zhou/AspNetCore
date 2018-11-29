using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTest
{
    [TestFixture]
    public class IntegrationTestMVCTest
    {
        [Test]
        public async Task Test()
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder()
                .UseStartup<TestStartup>()
                );
            var response = await server.CreateClient().GetAsync(@"/test");
            var result = await response.Content.ReadAsStringAsync();
        }
    }
}
