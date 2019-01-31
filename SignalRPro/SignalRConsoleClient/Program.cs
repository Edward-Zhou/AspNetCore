using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SignalRConsoleClient
{
    class Program
    {
        static Action<string> OnReceivedAction = OnReceived;
        static void Main(string[] args)
        {
            //Connect().Wait();
            Console.WriteLine(WindowsIdentity.GetCurrent().Name);
            //WindowsIdentity.RunImpersonated(WindowsIdentity.GetCurrent().AccessToken, Connect);
            Connect();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        private static async void Connect()
        {
            var hubConnectionBuilder = new HubConnectionBuilder();
            #region Worked
            var hubConnection = hubConnectionBuilder.WithUrl("https://localhost:44381/timeHub", options =>
            {
                options.UseDefaultCredentials = true;
                //options.Credentials = new NetworkCredential("xx", "xx", "xx");
            }).Build();
            #endregion
            #region Non-Worked
            ////https://localhost:44381/timeHub
            //var hubConnection = hubConnectionBuilder.WithUrl("http://localhost:61045/timeHub", options =>
            //{                
            //    options.UseDefaultCredentials = true;
            //    options.HttpMessageHandlerFactory = messageHandler =>
            //    {
            //        //messageHandler = new HttpClientHandler() {
            //        //    Credentials = new NetworkCredential("edwardzh", "Ed@1122", "wicresoft"),
            //        //    UseDefaultCredentials = true                        
            //        //};
            //        //return messageHandler;
            //        return new CredentialDelegatingHandler(messageHandler);
            //    };
            //    //options.Credentials = new NetworkCredential("xx", "xx", "xx");
            //}).Build();
            #endregion
            #region Create Connection
            #endregion
            await hubConnection.StartAsync();
            await hubConnection.SendAsync("UpdateTime", $"From Client");
            var item1 = new Dictionary<string, object> {
                { "T1", new { Name = "TT1" } },
                { "T2", new { Name = "TT2" } },
                { "T3", new { Name = "TT3" } },
            };
            var item2 = new Dictionary<string, object> {
                { "T11", new { Name = "TT11" } },
                { "T12", new { Name = "TT12" } },
                { "T13", new { Name = "TT13" } },
            };

            await hubConnection.SendAsync("SendMessage", new Message {
                MessageId = 1,
                Items = new List<Dictionary<string, object>> {
                    item1,
                    item2
                },
                TextMessages = new List<string> {
                    "H1",
                    "H2"
                }
            });
            var on = hubConnection.On("ReceiveMessage", OnReceivedAction);
            Console.WriteLine($"Client is Start");
            Console.ReadLine();
            on.Dispose();
            await hubConnection.StopAsync();
        }

        static void OnReceived(string message)
        {
            Console.WriteLine($"{ message }");
        }
    }
}
