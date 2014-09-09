using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseWindowsService;

namespace MyWindowsService
{
    class MyWindowsService : BaseWindowsService.BaseWindowsService<MyWindowsService>
    {
        public override void DoYourMagic(string[] args)
        {
            //TODO: This is the code that will execute on the interval defined in ActionSleep
           throw new NotImplementedException();           
        }

        public static void Main(string[] args)
        {
            MyWindowsService myService = new MyWindowsService();
            myService.Go(args);
        }
    }
}
