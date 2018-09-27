using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VG.Serilog.Sinks.EntityFrameworkCore;

namespace SerilogPro.Extensions
{
    public static class EntityFrameworkCoreSinkExtensions
    {
        public static LoggerConfiguration EntityFrameworkCoreSink(
                  this LoggerSinkConfiguration loggerConfiguration,
                  IServiceProvider serviceProvider,
                  IFormatProvider formatProvider = null)
        {
            return loggerConfiguration.Sink(new EntityFrameworkCoreSink(serviceProvider, formatProvider, 10 , TimeSpan.FromSeconds(10)));
        }
    }
}
