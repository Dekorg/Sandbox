using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseWindowsService
{
    public class Logger
    {
        public static void Log(string message, TraceEventType severity)
        {
            //TODO: implement your logger here
            Console.WriteLine(string.Format("{0}: {1}", Enum.GetName(typeof(TraceEventType), severity), message));
        }
    }
}
