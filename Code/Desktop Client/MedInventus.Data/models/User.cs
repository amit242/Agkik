using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agkik.businesslogic.models
{
    public class User : ResponseWrapper
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }

    public enum Role
    {
        Admin, Manager, SalesMan, Other
    }
}
