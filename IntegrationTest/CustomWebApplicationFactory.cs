using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IntegrationTest
{
    public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

            });
            base.ConfigureWebHost(builder);
        }
        public new HttpClient CreateClient()
        {
            var cookieContainer = new CookieContainer();
            var uri = new Uri("https://localhost:44344/Identity/Account/Login");
            var httpClientHandler = new HttpClientHandler
            {
                CookieContainer = cookieContainer
            };
            HttpClient httpClient = new HttpClient(httpClientHandler);
            var verificationToken = GetVerificationToken(httpClient, "https://localhost:44344/Identity/Account/Login");
            var contentToSend = new FormUrlEncodedContent(new[]
                    {
                                new KeyValuePair<string, string>("Email", "test@outlook.com"),
                                new KeyValuePair<string, string>("Password", "1qaz@WSX"),
                                new KeyValuePair<string, string>("__RequestVerificationToken", verificationToken),
                            });
            var response = httpClient.PostAsync("https://localhost:44344/Identity/Account/Login", contentToSend).Result;
            var cookies = cookieContainer.GetCookies(new Uri("https://localhost:44344/Identity/Account/Login"));
            cookieContainer.Add(cookies);
            var client = new HttpClient(httpClientHandler);
            return client;
        }
        private string GetVerificationToken(HttpClient client, string url)
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            var verificationToken =response.Content.ReadAsStringAsync().Result;
            if (verificationToken != null && verificationToken.Length > 0)
            {
                verificationToken = verificationToken.Substring(verificationToken.IndexOf("__RequestVerificationToken"));
                verificationToken = verificationToken.Substring(verificationToken.IndexOf("value=\"") + 7);
                verificationToken = verificationToken.Substring(0, verificationToken.IndexOf("\""));
            }
            return verificationToken;
        }
    }
}
