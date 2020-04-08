using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_Auth_Service.Models
{
    public class UserData
    {
        public string username;
        public string password;
        public UserData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
