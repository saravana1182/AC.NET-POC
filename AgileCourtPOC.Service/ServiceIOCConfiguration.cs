using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Service.Interface;
using Microsoft.Practices.Unity;

namespace AgileCourtPOC.Service
{
    public class ServiceIOCConfiguration
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            // var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            container.RegisterType<IValidationCategoryCodeService, ValidationCategoryCodeService>();
         
            container.RegisterType<IValidationCodeService, ValidationCodeService>();
         
            container.RegisterType<IValidationGroupCodeService, ValidationGroupCodeService>();
         

           





        }
    }
}
