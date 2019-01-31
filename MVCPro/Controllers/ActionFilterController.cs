using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCPro.ActionFilters;
using MVCPro.Models;

namespace MVCPro.Controllers
{
    public class ActionFilterController : Controller
    {
        // GET: ActionFilter
        [LEMClaimAuthorize(new ELocation[] { ELocation.Indy, ELocation.Columbus })]
        public ActionResult One()
        {
            return View();
        }
        [LEMClaimAuthorize(new ELocation[] { ELocation.Indy, ELocation.Columbus }, new EEntity[] { EEntity.JobTool })]
        public ActionResult Two()
        {
            return View();
        }
        [LEMClaimFilterAuthorize(new ELocation[] { ELocation.Indy, ELocation.Columbus })]
        public ActionResult Three()
        {
            return View();
        }
        [LEMClaimFilterAuthorize(new ELocation[] { ELocation.Indy, ELocation.Columbus }, new EEntity[] { EEntity.JobTool })]
        public ActionResult Four()
        {
            return View();
        }
        [ParameterTypeFilter]
        public ActionResult NoParameter()
        {
            return Ok("Test");
        }
        [ParameterTypeFilter("T1","T2")]
        public ActionResult Parameter()
        {
            return Ok("Test");
        }
        [TypeFilter(typeof(RequestLoggerActionFilter))]
        public List<Book> RequestLogger()
        {
            //return Ok("RequestLoggerActionFilter");
            return new List<Book>{
                new Book{ Id = 1, Title = "B1"},
                new Book{ Id = 2, Title = "B2"},
                new Book{ Id = 3, Title = "B3"}
            };
        }
        public ActionResult MultipleParameters()
        {
            var parameters = HttpContext.Request.Query;
            return Ok(parameters.ToList());
        }

        [ServiceFilter(typeof(EnumFilter<Category>))]
        public async Task<IActionResult> Category()
        {
            return Ok();
        }
        [ServiceFilter(typeof(EnumFilter<CategoryParent>))]
        public async Task<IActionResult> CategoryParent()
        {
            return Ok();
        }
        [ServiceFilter(typeof(ParameterReplaceActionFilter))]
        [HttpGet]
        public async Task<IActionResult> ParameterReplace(string dataComingFromActionFilter)
        {
            return Ok();
        }
    }
}