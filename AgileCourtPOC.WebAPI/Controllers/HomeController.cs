using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgileCourtPOC.Utilities;

namespace AgileCourtPOC.WebAPI.Controllers
{
    public class HomeController : Controller
    {

        private IAuthentication _authentication;
        public HomeController(IAuthentication authentication)
        {
            _authentication = authentication;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public bool Login(string username,string password)
        {
            return _authentication.IsValidUser(username, password);
        }


    }
}
