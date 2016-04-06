using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using AgileCourtPOC.Data.Repository;
using AgileCourtPOC.Data.Interfaces;
using System.Data.Entity;

namespace AgileCourtPOC.Data
{
    public class DataIOCConfiguration
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            // var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

           container.RegisterType(typeof(IRepository<,>),typeof(EntityFrameWorkSQLRepository<,>)).RegisterInstance(new PerResolveLifetimeManager());
            
        }


    }
}
