using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogPro.Extensions
{
    public static class LogExtensions
    {
        public static void PrefixLogDebug(this ILogger logger, string message, string prefix = "Edward", params object[] args)
        {
            logger.LogDebug($"{prefix} {message}");
        }
    }
}
