using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RouterPro.Routers
{
    public class SubDomainRouteHandler : MvcAttributeRouteHandler
    {

        public SubDomainRouteHandler(IActionInvokerFactory actionInvokerFactory, IActionSelector actionSelector, DiagnosticSource diagnosticSource, ILoggerFactory loggerFactory) : base(actionInvokerFactory, actionSelector, diagnosticSource, loggerFactory)
        {
        }

        public new VirtualPathData GetVirtualPath(VirtualPathContext context)
        {
            return base.GetVirtualPath(context);
        }

        public new Task RouteAsync(RouteContext context)
        {
            context.RouteData.Values.Add("SubDomain","stackoverflow");
            return base.RouteAsync(context);
        }
    }
}
