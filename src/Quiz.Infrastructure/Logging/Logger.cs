using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Logging
{
    public class Logger : ILogger
    {

        public void LogError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
        }

        public void LogException(Exception ex)
        {
            Console.WriteLine(string.Format("{0}  -  {1}", ex.Message, ex.StackTrace));
        }

        public void LogInformation(string information)
        {
            Console.WriteLine(information);
        }
    }
}
