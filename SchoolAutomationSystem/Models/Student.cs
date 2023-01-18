using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Student:AbstractGeneric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int StudentNumber { get; set; }
        public string TCNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Scholarship { get; set; } //Burs oranı.
        public int TotalCredit { get; set; } = 0;//Derslerden topladığı kredi miktarı.
        public bool IsPayment { get; set; }//Harcı yatırıp yatırmadığı.
        public bool IsGraduate { get; set; }//Mezun olup olmadığı.
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<SelectionLesson> SelectionLesson { get; set; }//Seçilen derslerin listesi
    }
}