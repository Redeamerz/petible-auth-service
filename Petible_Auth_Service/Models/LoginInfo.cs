using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_Auth_Service.Models
{
    public class LoginInfo
    {
        public string kind { get; set; }
        public string localId { get; set; }
        public string email { get; set; }
        public string displayName { get; set; }
        public string idToken { get; set; }
        public bool regisered { get; set; }
        public string refreshToken { get; set; }
        public string expiresIn { get; set; }
        public string role { get; set; }
    }
}
