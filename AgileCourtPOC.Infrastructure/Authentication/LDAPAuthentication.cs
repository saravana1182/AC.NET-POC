using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourtPOC.Infrastructure.Authentication
{
    public class LDAPAuthentication : IAuthentication
    {
        public bool IsValidUser(string username, string password)
        {
            if(username.Equals("LDAPAuthenticate",StringComparison.OrdinalIgnoreCase) && password.Equals("LDAPAuthenticate", StringComparison.OrdinalIgnoreCase))
            {

                return true;
            }
            return false;
        }
    }
}
