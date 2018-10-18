using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HangfirePro.Models;
using Hangfire;

namespace HangfirePro.Controllers
{
    public class HomeController : Controller
    {
        private IBackgroundJobClient _backgroundJobClient;
        public HomeController(IBackgroundJobClient backgroundJobClient)
        {
            _backgroundJobClient = backgroundJobClient;
        }
        public IActionResult Index()
        {
            //BackgroundJob.Enqueue(() => Console.WriteLine("BackgroundJob!"));
            //_backgroundJobClient.Enqueue(() => Console.WriteLine("IBackgroundJobClient!"));
            return Ok("Send Email");
            //return View();
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
