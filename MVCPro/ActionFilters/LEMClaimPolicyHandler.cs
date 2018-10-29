using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class LEMClaimPolicyHandler : AuthorizationHandler<LEMClaimRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LEMClaimRequirement requirement)
        {
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }
    }
}
