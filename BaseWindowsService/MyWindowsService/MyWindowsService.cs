using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MyWindowsService
{
    public class MyWindowsService
        : BaseWindowsService.BaseWindowsService
    {
        public MyWindowsService(string[] args)
            : base(args)
        {

        }

        protected override void DoYourMagic(string[] args)
        {
            //TODO: This is the code that will execute on the interval defined in ActionSleep
            throw new NotImplementedException();            
        }
    }
}
