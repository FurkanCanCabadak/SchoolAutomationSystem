using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Role:AbstractGeneric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Admin> Admin { get; set;}
        public List<Student> Student { get; set; }
    }
}