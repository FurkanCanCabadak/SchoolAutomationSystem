using SchoolAutomationSystem.DataAccessLayer;
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
    public class StudentAffairStudentController : Controller
    {
        DataAccess db = new DataAccess();
        StudentRepository studentRepository = new StudentRepository();
        DepartmentRepository departmentRepository = new DepartmentRepository();
        // GET: StudentAffairStudent
        public ActionResult Index()
        {
            var model = new StudentDepartment();
            model.DepartmentList = departmentRepository.List();
            model.StudentList = db.Student.Where(x=>x.IsDelete==false&&x.IsGraduate==false).ToList();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            TempData["Message"] = studentRepository.Delete(id) ?
                                    "Student Deleted Successful" :
                                    "Student Deletion Failed";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(Student student)
        {

            TempData["Message"] = studentRepository.Add(student) ?
                                    "Student Added Successful" :
                                    "Student Insert Failed";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("~/AdminTeacher/Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var student = studentRepository.Detail(id);
            if (student != null)
            {
                var model = new StudentDepartment();
                model.DepartmentList = departmentRepository.List();
                model.SingleStudent = db.Student.FirstOrDefault(x => x.Id == id);
                return View(model);
            }
            TempData["Message"] = "Not Found Student";
            return RedirectToAction("Index");

        }
        [HttpPost]
        [Route("~/AdminTeacher/Edit/{id:int}")]
        public ActionResult Edit(Student student)
        {
            TempData["Message"] = studentRepository.Edit(student) ?
                                   "Student Edit Successful" :
                                   "Student Edit Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}