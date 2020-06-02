using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_Auth_Service.Models
{
    public class UserData
    {
        public string email;
        public string password;
        public string role;

        public UserData(string email, string password, string role)
        {
            this.email = email;
            this.role = role;
            this.password = password;
        }
    }
}
