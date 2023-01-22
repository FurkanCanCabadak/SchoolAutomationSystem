using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Admin:AbstractGeneric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}