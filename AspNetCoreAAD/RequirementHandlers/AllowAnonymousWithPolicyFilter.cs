using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAAD.RequirementHandlers
{
    public class AllowAnonymousWithPolicyFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorizationService _authorization;
        public string Policy { get; private set; }

        public AllowAnonymousWithPolicyFilter(string policy, IAuthorizationService authorization)
        {
            Policy = policy;
            _authorization = authorization;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var authorized = await _authorization.AuthorizeAsync(context.HttpContext.User, Policy);
            if (!authorized.Succeeded)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
