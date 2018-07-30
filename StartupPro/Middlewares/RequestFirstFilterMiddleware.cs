using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupPro
{
    public class RequestFirstFilterMiddleware : RequestMiddleware
    {

        public RequestFirstFilterMiddleware(RequestDelegate next):base(next)
        {

        }        
    }
}
