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
    [RoutePrefix("AdminTeacher")]
    [Route("{action=Index}")]
    public class AdminTeacherController : Controller
    {
        TeacherRepository teacherRepository=new TeacherRepository();
        RoleRepository roleRepository=new RoleRepository();
        LessonRepository lessonRepository=new LessonRepository();
        // GET: AdminTeacher
        public ActionResult Index()
        {
            var model = new TeacherRoleLesson();
            model.TeacherList = teacherRepository.List();
            model.LessonList= lessonRepository.List();
            model.RoleList= roleRepository.List();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            TempData["Message"] = teacherRepository.Delete(id) ?
                                    "Teacher Deleted Successful" :
                                    "Teacher Deletion Failed";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(Teacher teacher)
        {

            TempData["Message"] = teacherRepository.Add(teacher) ?
                                    "Teacher Added Successful" :
                                    "Teacher Insert Failed";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("~/AdminTeacher/Edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            var teacher = teacherRepository.Detail(id);
            if (teacher != null)
            {
                TeacherRoleLesson model = new TeacherRoleLesson();
                model.TeacherList = teacherRepository.List();
                model.LessonList = lessonRepository.List();
                model.RoleList = roleRepository.List();
                model.SingleTeacher= teacher;
                model.SingleLesson = lessonRepository.Detail(teacher.LessonId);
                model.SingleRole = roleRepository.Detail(teacher.RoleId);
                return View(model);
            }
            TempData["Message"] = "Not Found Teacher";
            return RedirectToAction("Index");

        }
        [HttpPost]
        [Route("~/AdminTeacher/Edit/{id:int}")]
        public ActionResult Edit(Teacher teacher)
        {
            ViewBag.Message = teacherRepository.Edit(teacher) ?
                                   "Teacher Edit Successful" :
                                   "Teacher Edit Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }

    }
}