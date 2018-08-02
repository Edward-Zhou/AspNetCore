using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using MiddlewarePro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewarePro.Middlewares
{
    public class MiddlewareDependency
    {
        private readonly ISingletonService _singletonSvc;
        private readonly IScopedService _scopedSvc;
        private readonly RequestDelegate _next;
        /// <summary>
        /// should not inject scoped service in middleware constructor, otherwise, it will throw exception
        /// Cannot resolve scoped service 'MiddlewarePro.Services.IScopedService' from root provider
        /// we should inject scoped service by `InvokeAsync` method
        /// </summary>
        /// <param name="next"></param>
        /// <param name="singletonSvc"></param>
        public MiddlewareDependency(RequestDelegate next
            , ISingletonService singletonSvc
            //, IScopedService scopedSvc
            )
        {
            _next = next;
            _singletonSvc = singletonSvc;
            //_scopedSvc = scopedSvc;
        }

        public async Task InvokeAsync(HttpContext context, IScopedService scopedService)
        {
            var singleton = _singletonSvc.GetData();
            var scoped = scopedService.GetData();

            await context.Response.WriteAsync($"Singleton Data is { singleton }; Scoped Data is { scoped }");
        }
    }
}
