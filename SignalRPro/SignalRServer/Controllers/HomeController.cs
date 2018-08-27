using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;
using SignalRServer.Models;

namespace SignalRServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly TimeHub _timeHub;
        public HomeController(TimeHub timeHub)
        {
            _timeHub = timeHub;
        }
        public IActionResult Index()
        {
            Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    try
                    {
                        await _timeHub.UpdateTime(DateTime.Now.ToShortDateString());
                        Thread.Sleep(2000);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            });
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
