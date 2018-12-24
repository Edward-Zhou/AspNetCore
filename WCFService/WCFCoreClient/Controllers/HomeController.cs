using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using NTLMWebService;
using WCFCoreClient.Models;

namespace WCFCoreClient.Controllers
{
    public class HomeController : Controller
    {
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
                   int dwLogonType, int dwLogonProvider, out SafeAccessTokenHandle phToken);
        const int LOGON32_PROVIDER_DEFAULT = 0;
        //This parameter causes LogonUser to create a primary token.   
        const int LOGON32_LOGON_INTERACTIVE = 2;
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            SafeAccessTokenHandle safeAccessTokenHandle;
            bool returnValue = LogonUser("edwardzh", "wicresoft", "Ed@1122",
                LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT,
                out safeAccessTokenHandle);
            WindowsIdentity.RunImpersonated(safeAccessTokenHandle, () =>
            {
                NTLMWebServiceSoapClient client = new NTLMWebServiceSoapClient(NTLMWebServiceSoapClient.EndpointConfiguration.NTLMWebServiceSoap);
                var result = client.HelloWorldAsync().Result;
                ViewData["Message"] = result.Body.HelloWorldResult;
            });

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
