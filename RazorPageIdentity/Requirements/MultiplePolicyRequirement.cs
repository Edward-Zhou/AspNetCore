using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageIdentity.Requirements
{
    public class MultiplePolicyRequirement : IAuthorizationRequirement
    {
        public string Policys { get; private set; }
        public bool IsAnd { get; private set; }


        public MultiplePolicyRequirement(string policys, bool isAnd = false)
        {
            Policys = policys;
            IsAnd = isAnd;
        }
    }
}
