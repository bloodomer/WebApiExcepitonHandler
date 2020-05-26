using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WebApiExcepitonHandler
{
    public class Login
    {
        internal const string Password = "123456";
        public static bool UserNameAndPassword(string name, string password)
        {
            if (name == "odeniz" && password == "1234")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}