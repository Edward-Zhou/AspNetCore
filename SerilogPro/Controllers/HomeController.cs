using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogPro.Models;

namespace SerilogPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _log;
        public HomeController(ILogger<HomeController> log)
        {
            _log = log;
        }
        //[Authorize]
        public IActionResult Index()
        {
            _log.LogInformation("Hello, world!");
            Log.Logger.Information("Log From Serialog");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            var log = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.RollingFile(@"C:\Windows\Temp\testlog\log_001.txt")
                    .CreateLogger();

            log.Debug("Created logger1...");

            var log1 = new LoggerConfiguration()
                     .MinimumLevel.Debug()
                    .WriteTo.RollingFile(@"C:\Windows\Temp\testlog\log.txt", Serilog.Events.LogEventLevel.Debug)
                    .CreateLogger();

            log1.Debug("Created logger2...");


            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
