using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.DataAccessLayer
{
    public class DataAccess:DbContext
    {
        
        public DataAccess() : base("DbConnection") { }
        public DbSet<Role> Role { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<StudentAffair> StudentAffair { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<SelectionLesson> SelectionLesson { get; set; }
    }
}