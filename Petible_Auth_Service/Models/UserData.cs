using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_Auth_Service.Models
{
    public class UserData
    {
        public string uid;
        public string role;

        public UserData(string uid, string role)
        {
            this.uid = uid;
            this.role = role;
        }
    }
}
