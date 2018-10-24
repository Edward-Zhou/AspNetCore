using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedServicePro.HostedServices
{
    public class ConsoleBackgroundService: BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("ConsoleBackgroundService is Running!!!");
                await Task.Delay(10 * 1000);
            }
        }
    }
}
