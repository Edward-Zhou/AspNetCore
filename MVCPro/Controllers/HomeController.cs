using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCPro.ActionFilters;
using MVCPro.Models;

namespace MVCPro.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            //var t = Task.Run(() => { return Task.FromException(new Exception("ab")); });

            //try
            //{
            //    await t;
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //    var x = 0;
            //}
            return View();
        }

            [TypeFilter(typeof(FileDownloadCompleteActionFilter))]
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
        public async Task<ContentResult> HtmlView()
        {
            using (var formDataContent = new MultipartFormDataContent())
            {
                HttpClient client = new HttpClient();
                Article article = new Article { ArticleName = "AN" };

                formDataContent.Add(new StringContent("AN", Encoding.UTF8, "application/json"), "ArticleName");
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsync(@"https://localhost:44393/Articles/Create", formDataContent);
                    return new ContentResult
                    {
                        ContentType = "text/html",
                        StatusCode = (int)response.StatusCode,
                        Content = await response.Content.ReadAsStringAsync()
                    };

                }
            }
        }

        public async Task<IActionResult> RequestLoggerActionFilter()
        {
            return CreatedAtAction("Contact", null);
        }
    }
}
