using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupPro
{
    public class RequestSecondMiddleware: RequestMiddleware
    {

        public RequestSecondMiddleware(RequestDelegate next):base(next)
        {

        }        
    }
}
