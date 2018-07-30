using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartupPro
{
    public class RequestFirstMiddleware : RequestMiddleware
    {

        public RequestFirstMiddleware(RequestDelegate next):base(next)
        {

        }        
    }
}
