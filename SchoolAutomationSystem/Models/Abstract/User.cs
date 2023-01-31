using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models.Abstract
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}