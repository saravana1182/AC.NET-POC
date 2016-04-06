using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.WebAPI;
using AgileCourtPOC.WebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;

using AgileCourtPOC.Infrastructure.Authentication;
namespace AgileCourtPOC.WebAPI.Tests.Controllers
{
    [TestClass]
    public class AuthenticationControllerTest
    {

        private IAuthentication Authentication;

        [TestInitialize]
        public void Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<IAuthentication, LDAPAuthenticationTest>();

            Authentication=container.Resolve<IAuthentication>();
        }


        [TestMethod]
        public void ShouldReturnTrueWhenCredentialsAreValid()
        {
            var controller = new AuthenticationController(Authentication);

            var result=controller.Post(new Models.LoginViewModel() { UserName="LDAPAuthenticate",Password= "LDAPAuthenticate" });

            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void ShouldReturnFalseWhenCredentialsAreInValid()
        {
            var controller = new AuthenticationController(Authentication);

            var result = controller.Post(new Models.LoginViewModel() { UserName = "InvalidUser", Password = "InvalidUser" });

            Assert.AreEqual(false, result);

        }

    }

    internal class LDAPAuthenticationTest : IAuthentication
    {
        public bool IsValidUser(string username, string password)
        {
            if (username.Equals("LDAPAuthenticate", StringComparison.OrdinalIgnoreCase) && password.Equals("LDAPAuthenticate", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }
    }

}
