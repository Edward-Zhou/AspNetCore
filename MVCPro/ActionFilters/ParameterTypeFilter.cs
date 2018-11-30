using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class ParameterTypeFilter: TypeFilterAttribute
    {
        public ParameterTypeFilter() : base(typeof(ParameterActionFilter))
        {
        }

        public ParameterTypeFilter(string para1, string para2):base(typeof(ParameterActionFilter))
        {
            Arguments = new object[] { para1, para2 };
        }
    }
}
