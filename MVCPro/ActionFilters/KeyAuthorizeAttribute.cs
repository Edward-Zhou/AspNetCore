using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class KeyAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private static IEnumerable<string> _apiKeys = new List<string>
        {
            "Key1"
        };

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var req = context.HttpContext.Request;
            req.EnableRewind();

            using (var reader = new StreamReader(req.Body, Encoding.UTF8, true, 1024, true))
            {
                var bodyStr = reader.ReadToEnd();
                var isAuthorized = _apiKeys.Any(apiKey => bodyStr.Contains(apiKey));
                if (!isAuthorized)
                {
                    context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                    return;
                }
            }

            req.Body.Position = 0;
        }
    }
}
