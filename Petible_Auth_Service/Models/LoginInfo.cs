using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_Auth_Service.Models
{
    public class LoginInfo
    {
        public string kind;
        public string localId;
        public string email;
        public string displayName;
        public string idToken;
        public bool regisered;
        public string refreshToken;
        public string expiresIn;
        public string role;
    }
}
