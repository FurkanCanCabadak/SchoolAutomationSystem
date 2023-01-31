using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Student:User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Image { get; set; }
        public string TCNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AdvisorId { get; set; }//Danışman öğretmen.
        public int Term { get; set; }//Öğrencinin kaçıncı dönemde olduğu.
        public double Scholarship { get; set; } //Burs oranı.
        public int TotalCredit { get; set; } = 0;//Derslerden topladığı kredi miktarı.
        public bool IsPayment { get; set; }//Harcı yatırıp yatırmadığı.
        public bool IsGraduate { get; set; }//Mezun olup olmadığı.
        
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<SelectionLesson> SelectionLesson { get; set; }//Seçilen derslerin listesi
    }
}