using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCPro.Services
{
    public interface IUserResolverService
    {
        ClaimsIdentity GetUser();
    }
}
