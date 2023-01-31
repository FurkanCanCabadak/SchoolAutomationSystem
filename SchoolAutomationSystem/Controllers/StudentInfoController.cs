using SchoolAutomationSystem.Models.EntityModel;
using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class StudentInfoController : Controller
    {
        StudentRepository studentRepository= new StudentRepository();
        // GET: StudentInfo
        public ActionResult Index()
        {
            return View(studentRepository.DetailwithName(User.Identity.Name));
        }
        public ActionResult Edit(int id)
        {
            var student = studentRepository.Detail(id);
            if (student != null)
            {
                
                return View(student);
            }
            TempData["Message"] = "Not Found Student";
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            TempData["Message"] = studentRepository.EditSelf(student) ?
                                   "Student Edit Successful" :
                                   "Student Edit Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}