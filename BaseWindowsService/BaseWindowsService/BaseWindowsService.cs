using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseWindowsService
{
    public abstract partial class BaseWindowsService : ServiceBase
    {
        private bool stopping;
        private bool sleeping;
        private ManualResetEvent stoppedEvent = new ManualResetEvent(false);

        public BaseWindowsService(string[] args)
        {
            InitializeComponent();
            this.ServiceName = this.GetType().Name;
            Register(args);
        }

        public void Register(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                // if no arguments exist run service as normal
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                   this
                };
                ServiceBase.Run(ServicesToRun);
            }
            else if (args[0].Equals("debug", StringComparison.CurrentCultureIgnoreCase))
            {
                // if debug arguments exist run as a console app (debugging)               
                StartService(args);

                Console.WriteLine("Press enter to stop service");
                Console.ReadLine();

                StopService();
                Environment.Exit(0);
            }
            else if (args[0].Equals("i", StringComparison.CurrentCultureIgnoreCase))
            {
                //install
                ServiceInstaller.InstallService(this.ServiceName);

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
                Environment.Exit(0);

            }
            else if (args[0].Equals("u", StringComparison.CurrentCultureIgnoreCase))
            {
                //uninstall
                ServiceInstaller.UninstallService(this.ServiceName);

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
                Environment.Exit(0);

            }
        }

        protected override void OnStart(string[] args)
        {
            StartService(args);
        }

        protected override void OnStop()
        {
            StopService();
        }

        protected abstract void DoYourMagic(string[] args);

        private void StartService(string[] args)
        {
            Logger.Log(string.Format("Starting {0} work thread.", this.ServiceName), TraceEventType.Information);
            ThreadPool.QueueUserWorkItem(delegate
            {
                DoWork(args);
            }, null);
        }

        private void StopService()
        {
            int wait = Convert.ToInt32(ConfigurationManager.AppSettings["StopServiceWait"]);
            Logger.Log(string.Format("Requesting {0} work thread stop.", this.ServiceName), TraceEventType.Information);
            this.stopping = true;

            //if we are sleeping , just kill it
            if (this.sleeping)
            {
                Logger.Log(string.Format("Stopping {0} work thread.", this.ServiceName), TraceEventType.Information);
                this.stoppedEvent.Set();
            }
            else if (!this.stoppedEvent.WaitOne(wait))
            {
                Logger.Log(string.Format("Requested {0} work thread stop timed out.", this.ServiceName), TraceEventType.Information);
            }
        }

        private void DoWork(string[] args)
        {
            int wait = Convert.ToInt32(ConfigurationManager.AppSettings["ActionSleep"]);

            while (!this.stopping)
            {
                DoYourMagic(args);

                sleeping = true;
                Thread.Sleep(wait);
                sleeping = false;
            }

            Logger.Log(string.Format("Stopping {0} work thread.", this.ServiceName), TraceEventType.Information);
            this.stoppedEvent.Set();
        }
    }
}
