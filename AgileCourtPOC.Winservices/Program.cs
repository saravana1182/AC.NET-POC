using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Unity;

namespace AgileCourtPOC.Winservices
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            

            HostFactory.Run(c =>
            {


                // Configure the Windows Service.
                c.SetServiceName("AgileCourt");
                c.SetDisplayName("Agile Court POC Azure Service");
                c.SetDescription("Service for azure bus");
                c.StartAutomatically();
                c.RunAsLocalSystem();
                c.UseNLog();

                // Configure the hosted service.
                c.Service(settings => new Service());

                Console.Write("Started");


            });
        }
    }
}
