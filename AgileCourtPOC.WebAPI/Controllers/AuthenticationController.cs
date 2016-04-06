using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgileCourtPOC.Infrastructure.Authentication;
using AgileCourtPOC.WebAPI.Models;

namespace AgileCourtPOC.WebAPI.Controllers
{
    public class AuthenticationController : ApiController
    {
        private IAuthentication _authentication;
        public AuthenticationController(IAuthentication authentication)
        {
            _authentication = authentication;

        }

        [HttpPost]
        [AllowAnonymous]
        public bool Post([FromBody] LoginViewModel model)
        {
           // string password = "";
            var valid = _authentication.IsValidUser(model.UserName, model.Password);
            return valid;
        }
    }
}
