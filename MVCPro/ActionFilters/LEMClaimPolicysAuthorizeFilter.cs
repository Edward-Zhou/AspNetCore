using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class LEMClaimPolicysAuthorizeFilter : IAsyncAuthorizationFilter
    {
        public ELocation[] Locations { get; private set; }
        public EEntity[] Entitys { get; private set; }

        public LEMClaimPolicysAuthorizeFilter(ELocation[] eLocations, EEntity[] eEntities = null)
        {
            Locations = eLocations;
            Entitys = eEntities;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //handle your logic here
            var _authorization = context.HttpContext.RequestServices.GetService(typeof(IAuthorizationService));
            return;
        }

    }
}
