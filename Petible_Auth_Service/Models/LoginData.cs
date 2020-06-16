using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_Auth_Service.Models
{
    public class LoginData
    {
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        public string returnSecureToken { get; set; }
    }
}
