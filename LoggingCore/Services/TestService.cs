using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingCore.Services
{
    public class TestService : ITestService
    {
        private readonly ILogger logger;
        public TestService(ILogger<TestService> logger)
        {
            this.logger = logger;
        }

        public Task SomeFunction()
        {
            logger.LogInformation("Do some function");
            return Task.CompletedTask;
        }
    }
}
