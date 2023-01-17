﻿using SchoolAutomationSystem.Models.Abstract;
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
        public int AdminNumber { get; set; }//Bu numara ve password ile giriş yapılacak.
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}