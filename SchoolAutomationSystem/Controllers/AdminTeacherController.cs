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
            var modal = new TeacherRoleLesson();
            modal.TeacherList = teacherRepository.List();
            modal.RoleList = roleRepository.List();
            modal.LessonList= lessonRepository.List();
            return View(modal);
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
        public ActionResult Edit(int id)
        {
            var teacher = teacherRepository.Detail(id);
            if (teacher != null)
            {
                return View(teacher);
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            ViewBag.Message = teacherRepository.Edit(teacher) ?
                                   "Role Edit Successful" :
                                   "Role Edit Failed";

            return View(teacherRepository.Detail(teacher.Id));
        }

    }
}