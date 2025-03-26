using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrkTravel
{
    internal class LoginDetails
    {
        public bool loginAuth { get; set; }
        public string username { get; set; }

        public LoginDetails (bool loginAuth, string username)
        {
            this.loginAuth = loginAuth;
            this.username = username;
        }
    }
}
