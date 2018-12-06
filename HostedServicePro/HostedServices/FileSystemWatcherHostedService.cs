using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedServicePro.HostedServices
{
    public class FileSystemWatcherHostedService : BackgroundService
    {
        private readonly IHostingEnvironment _env;
        private readonly ILogger<FileSystemWatcherHostedService> _logger;
        private FileSystemWatcher _fsw;

        public FileSystemWatcherHostedService(IHostingEnvironment env, ILogger<FileSystemWatcherHostedService> logger)
        {
            _env = env;
            _logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Creating new FSW");
            var path = Path.Combine(_env.ContentRootPath, "WebData");
            _fsw = new FileSystemWatcher(path, "*.json");
            _fsw.Created += _fsw_Created;
            _fsw.Changed += _fsw_Changed;
            _fsw.Renamed += _fsw_Renamed;
            _fsw.Error += _fsw_Error;
            _fsw.EnableRaisingEvents = true;
            return Task.CompletedTask;
        }

        private void _fsw_Error(object sender, ErrorEventArgs e) => _logger.LogInformation("File error");
        private void _fsw_Renamed(object sender, RenamedEventArgs e) => _logger.LogInformation("File Renamed");
        private void _fsw_Changed(object sender, FileSystemEventArgs e) => _logger.LogInformation("File changed");
        private void _fsw_Created(object sender, FileSystemEventArgs e) => _logger.LogInformation("File created");
    }
}
