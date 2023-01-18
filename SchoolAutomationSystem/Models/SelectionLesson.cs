using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class SelectionLesson:AbstractGeneric
    {
        public int Id { get; set; }
        public double VisaNote { get; set; }
        public double FinalNote { get; set; }
        public int StudentId { get; set; }//Dersi seçen öğrenci.
        public Student Student { get; set; }
        public int LessonId { get; set; }//Seçilen ders.
        public Lesson Lesson { get; set; }
    }
}