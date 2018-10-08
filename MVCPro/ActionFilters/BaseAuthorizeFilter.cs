using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class BaseAuthorizeFilter : IAuthorizationFilter, IActionFilter
    {
        public static ClaimsIdentity _User;
        public static IHttpContextAccessor _accessor;

        public BaseAuthorizeFilter(IUserResolverService userService, IHttpContextAccessor accessor)
        {
            _User = userService.GetUser();
            _accessor = accessor;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }
    }
}
