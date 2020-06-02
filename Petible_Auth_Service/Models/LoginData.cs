using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_Auth_Service.Models
{
    public class LoginData
    {
        public string uid;
        public string password;

        public LoginData(string uid, string password)
        {
            this.uid = uid;
            this.password = password;
        }
    }
}
