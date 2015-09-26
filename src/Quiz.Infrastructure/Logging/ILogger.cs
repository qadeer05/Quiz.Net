using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Logging
{
    public interface ILogger
    {
        void LogError(string errorMessage);
        void LogException(Exception ex);
        void LogInformation(string information);
    }
}
