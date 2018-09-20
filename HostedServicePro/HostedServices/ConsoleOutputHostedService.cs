using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedServicePro.HostedServices
{
    public class ConsoleOutputHostedService : IHostedService
    {
        private Timer _timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("ConsoleOutputHostedService is Start!!!");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("ConsoleOutputHostedService is Stop!!!");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            Console.WriteLine("ConsoleOutputHostedService is Running!!!");
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
