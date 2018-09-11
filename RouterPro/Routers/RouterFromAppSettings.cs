using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouterPro.Routers
{
    public class RouterFromAppSettings : IRouter
    {
        private readonly IRouter _defaulRouter;
        private readonly IConfiguration _config;
        public RouterFromAppSettings(IRouter defaulRouter
            , IConfiguration config)
        {
            _defaulRouter = defaulRouter;
            _config = config;
        }
        public async Task RouteAsync(RouteContext context)
        {
            var controller = _config.GetSection("Router").GetValue<string>("Controller");
            var action = _config.GetSection("Router").GetValue<string>("Action");
            context.RouteData.Values["controller"] = controller;
            context.RouteData.Values["action"] = action;
            await _defaulRouter.RouteAsync(context);
        }
        public VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return _defaulRouter.GetVirtualPath(context);
        }
    }
}
