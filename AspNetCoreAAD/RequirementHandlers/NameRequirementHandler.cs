using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAAD.RequirementHandlers
{
    public class NameRequirementHandler : AuthorizationHandler<NameRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NameRequirement requirement)
        {
            var authorizationFilterContext = context.Resource as AuthorizationFilterContext;
            if (authorizationFilterContext != null)
            {
                HttpContext httpContext = authorizationFilterContext.HttpContext;
                string userName = httpContext.User.Identity.Name; // ALWAYS NULL

                //Do some validation here with the user name value
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
