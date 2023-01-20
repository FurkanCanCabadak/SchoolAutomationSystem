using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Faculty:AbstractGeneric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime SelectionStart { get; set; }
        public DateTime SelectionEnd { get; set; }
        public List<Department> Department { get; set; }//Fakülteye ait bölümler.
    }
}