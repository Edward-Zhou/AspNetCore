using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelBindingPro.Binders;
using ModelBindingPro.Models;

namespace ModelBindingPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RouteSchedule()
        {
            var preCheckParams = new
            {
                Requirements = new List<string> { "S1", "S2" },
                WeightValues = new Dictionary<string, int>
                {
                    {"T1",1 }
                }
            };
            return RedirectToAction("GetSchedule", new { requirements = preCheckParams.Requirements, weightValues = preCheckParams.WeightValues });
        }

        public IActionResult GetSchedule(List<string> requirements, Dictionary<string, int> weightValues)
        {
            var result = Request.Query.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            return Ok();
        }
    }
}
