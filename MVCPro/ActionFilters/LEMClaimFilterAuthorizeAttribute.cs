using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class LEMClaimFilterAuthorizeAttribute : TypeFilterAttribute
    {
        public LEMClaimFilterAuthorizeAttribute(ELocation[] eLocations, EEntity[] eEntities = null) : base(typeof(LEMClaimPolicysAuthorizeFilter))
        {
            if (eEntities == null)
            {
                Arguments = new object[] { eLocations };
            }
            else
            {
                Arguments = new object[] { eLocations, eEntities };
            }
        }
    }
}
