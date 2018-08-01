using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro
{
    public class StartupMap
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app)
        {
            //Map with Action<IApplicationBuilder>
            app.Map("/map1", MapHandler1);
            //Map with anonymous method
            app.Map("/map2", map => {
                map.Run(async context => {
                    await context.Response.WriteAsync($"This is Request from Map2");
                });
            });
            //MapWhen
            app.MapWhen(context => context.Request.Path.Value.Contains("mapwhen"),
                builder =>
                {
                    builder.Run(async context =>
                    {
                        await context.Response.WriteAsync($"This is Request from MapWhen");
                    });
                });
            //Nested Map
            app.Map("/level1", level1app => {
                level1app.Map("/level2", level2app =>
                {
                    level2app.Run(async context => {
                        await context.Response.WriteAsync($"This is Request from level1/level2");
                    });
                });

                level1app.Run(async conext => {
                    await conext.Response.WriteAsync($"There is no mapped path after /level1");
                });
            });

            app.Run(async context => {
                await context.Response.WriteAsync($"There is no mapped Path");
            });
        }

        private static void MapHandler1(IApplicationBuilder app)
        {
            app.Run(async context => {
                await context.Response.WriteAsync($"This is Request from Map1");
            });
        }
    }
}
