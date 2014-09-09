using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseWindowsService;

namespace MyWindowsService
{
    class Program 
    {
        public static void Main(string[] args)
        {
            MyWindowsService myService = new MyWindowsService(args);            
        }
    }
}
