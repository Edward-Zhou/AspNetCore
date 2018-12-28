using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRWebClient.Models;

namespace SignalRWebClient.Controllers
{
    public class HomeController : Controller
    {
        static Action<string> OnReceivedAction = OnReceived;

        public async Task<IActionResult> Index()
        {
            var hubConnectionBuilder = new HubConnectionBuilder();
            var hubConnection = hubConnectionBuilder.WithUrl("http://localhost:61045/timeHub", options => {
                options.UseDefaultCredentials = true;
            }).Build();
            await hubConnection.StartAsync();
            
            return View();
        }
        static void OnReceived(string message)
        {
            Console.WriteLine($"{ message }");
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
    }
}
