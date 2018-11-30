using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Authorization;

namespace GraphQLNet.Extensions
{
    public class DenyAnonymousRequirement :  Microsoft.AspNetCore.Authorization.IAuthorizationRequirement
    {
        public Task Authorize(AuthorizationContext context)
        {
            var user = context.User;
            var userIsAnonymous =
                user?.Identity == null ||
                !user.Identities.Any(i => i.IsAuthenticated);
            if (userIsAnonymous)
            {
                context.ReportError($"User is not authorized");
            }
            return Task.CompletedTask;
        }
    }
}
