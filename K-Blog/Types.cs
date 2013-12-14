using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_Blog
{
    public class Types
    {
        public class User
        {
            public string FirstName {get; set;} 
            public string LastName {get; set;} 
            public string Email {get;set;}
            public bool IsPrivate {get;set;} 
            public string UserGUID {get;set;}
            public string LastSignOut { get; set; }
        }
    }
}