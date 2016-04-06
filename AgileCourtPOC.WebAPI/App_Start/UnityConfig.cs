using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using AgileCourtPOC.Data;
using AgileCourtPOC.Service;
using AgileCourtPOC.Infrastructure;

namespace AgileCourtPOC.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			IUnityContainer container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DataIOCConfiguration.RegisterComponents(container);
            ServiceIOCConfiguration.RegisterComponents(container);
            InfrastructureIOCConfiguration.RegisterComponents(container);       
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}