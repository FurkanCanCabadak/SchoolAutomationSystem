using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; } //Dersin kredisi.
        public int SelectionalYear { get; set; }//Dersin seçilmesi için gereken en düşük sınıf.
        public int DepartmentId { get; set; }//dersin ait olduğu fakülte.
        public Department Department { get; set; }
        public List<Teacher> Teacher { get; set; }//Dersi veren öğretmenler.
        public List<SelectionLesson> SelectionLesson { get; set; }//Seçilen derslerin listesi
    }
}