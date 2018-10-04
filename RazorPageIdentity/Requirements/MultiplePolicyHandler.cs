using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageIdentity.Requirements
{
    public class MultiplePolicyHandler : AuthorizationHandler<MultiplePolicyRequirement>
    {
        private IAuthorizationService _authorization;
        public MultiplePolicyHandler(IAuthorizationService authorization)
        {
            _authorization = authorization;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                   MultiplePolicyRequirement requirement)
        {
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
