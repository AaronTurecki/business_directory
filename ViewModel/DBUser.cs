using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication2.ViewModel
{
    public class DBUser
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SessionID { get; set; }

        public DBUser(string userName, string password, string sessionID)
        {
            UserName = userName;
            Password = password;
            SessionID = sessionID;
        }
        public DBUser()
        {
        }
    }
}