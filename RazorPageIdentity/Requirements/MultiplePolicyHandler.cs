using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RazorPageIdentity.Requirements
{
    public class MultiplePolicyHandler : AuthorizationHandler<MultiplePolicyRequirement>
    {
        private IAuthorizationService _authorization;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MultiplePolicyHandler(IAuthorizationService authorization
            , IHttpContextAccessor httpContextAccessor)
        {
            _authorization = authorization;
            _httpContextAccessor = httpContextAccessor;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   MultiplePolicyRequirement requirement)
        {
            _httpContextAccessor.HttpContext.Response.Redirect("/Home/About");
            var policys = requirement.Policys.Split(";").ToList();
            if (requirement.IsAnd)
            {
                foreach (var policy in policys)
                {
                    var authorized = await _authorization.AuthorizeAsync(context.User, policy);
                    if (!authorized.Succeeded)
                    {
                        context.Fail();
                        return;
                    }

                }
            }
            else
            {
                foreach (var policy in policys)
                {
                    var authorized = await _authorization.AuthorizeAsync(context.User, policy);
                    if (authorized.Succeeded)
                    {
                        context.Succeed(requirement);
                        return;
                    }

                }
            }
        }
    }
}
