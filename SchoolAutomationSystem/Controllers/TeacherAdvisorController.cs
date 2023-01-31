using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Models.EntityModel;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class TeacherAdvisorController : Controller
    {
        DataAccess db = new DataAccess();
        TeacherRepository teacherRepository= new TeacherRepository();
        StudentRepository studentRepository= new StudentRepository();
        // GET: TeacherAdvisor
        public ActionResult Index()
        {
            var model = new TeacherStudent();
            model.StudentList = db.Student.Where(x=>x.AdvisorId==0).ToList();
            model.SingleTeacher = teacherRepository.DetailwithName(User.Identity.Name);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var student = studentRepository.Detail(id);
            if (student != null)
            {
                var model = new TeacherStudent();
                model.StudentList = db.Student.Where(x => x.AdvisorId == 0).ToList();
                model.SingleTeacher = teacherRepository.DetailwithName(User.Identity.Name);
                return View(model);
            }
            TempData["Message"] = "Not Found Student";
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            TempData["Message"] = studentRepository.AdvisorChange(student) ?
                                   "Student Advisor Updated Successful" :
                                   "Student Advisor Update Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}