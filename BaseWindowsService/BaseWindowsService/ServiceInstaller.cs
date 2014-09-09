using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BaseWindowsService
{
    public static class ServiceInstaller
    {
        public static bool IsServiceInstalled(string serviceName)
        {
            return ServiceController.GetServices().Any(s => s.ServiceName == serviceName);
        }

        public static void InstallService(string serviceName)
        {
            if (IsServiceInstalled(serviceName))
            {
                UninstallService(serviceName);
            }

            Install(serviceName, Assembly.GetEntryAssembly().Location);
        }

        public static void UninstallService(string serviceName)
        {
            Delete(serviceName);
        }

        private static void Install(string serviceName, string path)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} {1} ", "Create", serviceName);

            builder.AppendFormat("binPath= \"{0}\"  ", path);
            builder.AppendFormat("displayName= \"{0}\"  ", serviceName);

            ExecuteSC(builder.ToString());
        }

        private static void Delete(string serviceName)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0} {1} ", "Delete", serviceName);

            ExecuteSC(builder.ToString());
        }

        private static void ExecuteSC(string args)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = @"sc.exe";
                process.StartInfo.Arguments = args;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Verb = "runas"; //elevate privileges
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
            }
        }
    }
}
