using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using RouterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouterPro.Routers
{
    public class StringRouter : IRouter
    {
        private readonly IRouter _defaultRouter;
        private readonly IServiceProvider _serviceProvider;
        public StringRouter(IRouter defaultRouter
            , IServiceProvider serviceProvider)
        {
            _defaultRouter = defaultRouter;
            _serviceProvider = serviceProvider;
        }

        public async Task RouteAsync(RouteContext context)
        {           
            var dbContext = context.HttpContext.RequestServices.GetRequiredService<RouterProContext>();
            var products = dbContext.Product.ToList();
            await _defaultRouter.RouteAsync(context);
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return _defaultRouter.GetVirtualPath(context);
        }
    }
}
