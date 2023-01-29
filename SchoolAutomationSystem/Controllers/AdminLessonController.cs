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
    public class AdminLessonController : Controller
    {
        DataAccess db = new DataAccess();
        LessonRepository lessonRepository=new LessonRepository();
        DepartmentRepository departmentRepository=new DepartmentRepository();
        // GET: AdminLesson
        public ActionResult Index()
        {
            LessonDepartment model = new LessonDepartment();
            model.LessonList=lessonRepository.List();
            model.DepartmentList=departmentRepository.List();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Lesson lesson)
        {
            TempData["Message"] = lessonRepository.Add(lesson) ?
                                    "Lesson Added Successful" :
                                    "Lesson Insert Failed";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id) 
        {
            TempData["Message"] = lessonRepository.Delete(id) ?
                                    "Lesson Deleted Successful" :
                                    "Lesson Delete Failed";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lesson= lessonRepository.Detail(id);
            if (lesson!=null)
            {
                var model = new LessonDepartment();
                model.LessonList = lessonRepository.List();
                model.DepartmentList = departmentRepository.List();
                model.SingleLesson= lesson;
                model.SingleDepartment = departmentRepository.Detail(lesson.DepartmentId);
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Lesson lesson)
        {
            TempData["Message"] = lessonRepository.Edit(lesson) ?
                                  "Lesson Edit Successfull" :
                                  "Lesson Edit Failed";
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}