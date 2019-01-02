using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.ActionFilters
{
    public class EnumFilter<T> : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var type = typeof(T);
            //throw new NotImplementedException();
        }
    }

    public class Category
    {
        public string Name { get; set; }
    }
    public class CategoryParent
    {
        public string Name { get; set; }
    }

}
