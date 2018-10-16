using Hangfire;
using Hangfire.MemoryStorage;
using HangfirePro;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireTestPro
{
    public class StartupTest : Startup
    {
        public StartupTest(IConfiguration configuration) :base(configuration)
        {

        }
        protected override void ConfigureHangfire(IServiceCollection services)
        {
            services.AddHangfire(x => x.UseMemoryStorage());
        }
    }
}
