using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.Infrastructure.Logging;

namespace Quiz.Infrastructure.Services
{
    public static class LoggingService
    {
        private static ILogger _logger = new Logger();

        public static void LogError(string errorMessage)
        {
            _logger.LogError(errorMessage);
        }

        public static void LogException(Exception ex)
        {
            _logger.LogException(ex);
        }

        public static void LogInformation(string information)
        {
            _logger.LogInformation(information);
        }
    }
}
