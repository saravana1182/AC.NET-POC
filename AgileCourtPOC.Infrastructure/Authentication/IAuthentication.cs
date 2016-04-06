using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCourtPOC.Infrastructure.Authentication
{
    public interface IAuthentication
    {
        bool IsValidUser(string username, string password);
    }

    public enum InvalidLoginReasonCodes
    {
      Invalid=0, //Either Username or password is wrong
      Locked=1  //Account locked for n Number of Attempts with Invalid Credential


    }
}
