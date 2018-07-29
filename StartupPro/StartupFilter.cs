using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupPro
{
    public class StartupFilter
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, RequestStartupFilter>();
            //services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseMiddleware<RequestMiddleware>();
            //app.UseMvc();
            app.UseMiddleware<RequestSecondMiddleware>();
        }
    }
}
