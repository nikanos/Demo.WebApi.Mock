using Demo.WebApi.Mock;
using Microsoft.Owin.Hosting;
using System;
using System.Security.Principal;

namespace Demo.WebApi.MockHost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string listenAddressLocal = "http://localhost:9000/";
            string listenAddressAny = "http://*:9000/";
            string listenAddress = IsAdmin ? listenAddressAny : listenAddressLocal;

            using (WebApp.Start<Startup>(url: listenAddress))
            {
                Console.WriteLine($"Started listening to {listenAddress}");
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }
        }

        static bool IsAdmin => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }
}
