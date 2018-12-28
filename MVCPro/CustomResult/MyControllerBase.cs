using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCPro.CustomResult
{
    public class MyControllerBase: Controller
    {
        [NonAction]
        public virtual UpdatedAtActionResult UpdatedAtAction(string actionName, object value)
        => UpdatedAtAction(actionName, routeValues: null, value: value);

        [NonAction]
        public virtual UpdatedAtActionResult UpdatedAtAction(string actionName, object routeValues, object value)
                => UpdatedAtAction(actionName, controllerName: null, routeValues: routeValues, value: value);

        [NonAction]
        public virtual UpdatedAtActionResult UpdatedAtAction(
                        string actionName,
                        string controllerName,
                        object routeValues,
                        object value)
                        => new UpdatedAtActionResult(actionName, controllerName, routeValues, value);
    }
}
