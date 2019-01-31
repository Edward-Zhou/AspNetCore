using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace StaticFilePro
{
    public class StartupAuthorize
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/Archive", subApp => {
                subApp.Use(async (context, next) =>
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    }
                    else if(context.Request.Path.StartsWithSegments("/Archive/User1") && context.User.Identity.Name != "User1")
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    }
                });
            });
            
            app.UseStaticFiles();

            app.Use(async (context, next) => {
                await context.Response.WriteAsync($"<img src='Archive/User1/T1.PNG' alt='ASP.NET' class='img-responsive' />");
                await next();
            });

            app.Use(async (context, next) => {
                await context.Response.WriteAsync($"<img src='Archive/User2/Result.PNG' alt='ASP.NET' class='img-responsive' />");
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
