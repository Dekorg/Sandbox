using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratchpad
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerService logger = new LoggerService();
            
            logger.Log("Critical log", TraceEventType.Critical); //Oh S**t
            logger.Log("Error log", TraceEventType.Error);  //Exceptions
            logger.Log("Warning log", TraceEventType.Warning); //Log unusual data, missing configs, etc.
            logger.Log("Information log", TraceEventType.Information); //Managers
            logger.Log("Verbose log", TraceEventType.Verbose); //Accessors

        }
    }

    public class LoggerService
    {
        public LoggerService()
        {
            LogWriterFactory logWriterFactory = new LogWriterFactory();
            var logWriter = logWriterFactory.Create();
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.SetLogWriter(logWriter, false);
        }

        public string TestMe(string input)
        {
            return input + ", Logger";
        }

        /// <summary>
        /// log to a custom Category
        /// </summary>
        /// <param name="message"></param>
        /// <param name="severity"></param>
        /// <param name="category"></param>
        public void Log(string message, TraceEventType severity)
        {
            var logEntry = new LogEntry();
            logEntry.Severity = severity;
            logEntry.Categories.Add("General");
            logEntry.Message = message;
            logEntry.TimeStamp = DateTime.Now;
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(logEntry);
        }
    }
}
