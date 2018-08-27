using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRConsoleClient
{
    class Program
    {
        static Action<string> OnReceivedAction = OnReceived;
        static void Main(string[] args)
        {
            //Connect().Wait();
            Connect();
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        private static async void Connect()
        {
            var hubConnectionBuilder = new HubConnectionBuilder();
            var hubConnection = hubConnectionBuilder.WithUrl("http://localhost:61045/timeHub").Build();
            await hubConnection.StartAsync();
            //await hubConnection.SendAsync("UpdateTime", $"From Client");
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
