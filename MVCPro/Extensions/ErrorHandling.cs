using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.Extensions
{
    public static class ErrorHandling
    {
        public static void ShowApplicationError(this HttpResponse response, string exceptionMessage, string innerException)
        {
            var result = JsonConvert.SerializeObject(new { error = exceptionMessage, detail = innerException });
            response.HttpContext.Response.WriteAsync(result);
        }
    }
}
