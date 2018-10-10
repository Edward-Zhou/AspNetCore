using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAAD.RequirementHandlers
{
    public class AllowAnonymousWithPolicyAttribute : TypeFilterAttribute, IAllowAnonymous
    {
        public AllowAnonymousWithPolicyAttribute(string Policy) : base(typeof(AllowAnonymousWithPolicyFilter))
        {
            Arguments = new object[] { Policy };
        }
    }
}
