using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petible_Auth_Service.Models
{
    public class UserData
    {
        public string uid;

        public UserData(string uid)
        {
            this.uid = uid;
        }
    }
}
