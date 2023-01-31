using SchoolAutomationSystem.Models.EntityModel;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SchoolAutomationSystem.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository studentRepository= new StudentRepository();
        // GET: Student
        public ActionResult Index()
        {
            return View(studentRepository.DetailwithName(User.Identity.Name));
        }
        
        
    }
}