using AgileCourtPOC.Infrastructure.Authentication;
using Microsoft.Practices.Unity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourtPOC.Infrastructure
{
    public class InfrastructureIOCConfiguration
    {
        public static void RegisterComponents(IUnityContainer container)
        {
             container.RegisterType<ILogger>(new InjectionFactory(_=>LogManager.GetCurrentClassLogger()));
             container.RegisterType<IAuthentication, FormAuthentication>();

        }
    }
}
