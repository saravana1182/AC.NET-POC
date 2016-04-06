using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourtPOC.Infrastructure.Authentication
{
    public class FormAuthentication : IAuthentication
    {
        public bool IsValidUser(string username, string password)
        {
            if (username.Equals("FormAuthenticate", StringComparison.OrdinalIgnoreCase) && password.Equals("FormAuthenticate", StringComparison.OrdinalIgnoreCase))
            {


                return true;


            }
            return false;
        }
    }
}
