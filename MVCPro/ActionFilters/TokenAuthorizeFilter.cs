using Microsoft.AspNetCore.Http;
using MVCPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class TokenAuthorizeFilter : BaseAuthorizeFilter
    {
        public TokenAuthorizeFilter(IUserResolverService userService
            , IHttpContextAccessor accessor):base(userService, accessor)
        {
            var identity = _User;
        }
    }
}
