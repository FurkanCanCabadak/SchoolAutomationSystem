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
        public double Pay { get; set; }//Fakülte okuma bedeli.
        public List<Lesson> Lesson { get; set; }//Fakülteye ait ders listesi.
        public List<Department> Department { get; set; }
    }
}