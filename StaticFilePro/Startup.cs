using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace StaticFilePro
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();

            app.UseStaticFiles();
            //cat in external outside wwwroot
            //configure UseStaticFiles before invoking middleware
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "External")),
                RequestPath = "/External"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "External")),
                RequestPath = "/External"
            });

            //cat in wwwroot
            app.Use(async (context, next) => {
                await context.Response.WriteAsync($"<img src='images/cat.jpg' alt='ASP.NET' class='img-responsive' />");
                await next();
            });

            app.Use(async (context, next) => {
                await context.Response.WriteAsync($"<img src='external/cat.jpg' alt='ASP.NET' class='img-responsive' />");
                await next();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
