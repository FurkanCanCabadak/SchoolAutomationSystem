using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class StudentSelectionLessonController : Controller
    {
        DataAccess db = new DataAccess();   
        SelectionLessonRepository selectionLessonRepository = new SelectionLessonRepository();
        LessonRepository lessonRepository= new LessonRepository();
        StudentRepository studentRepository= new StudentRepository();
        // GET: StudentSelectionLesson
        public ActionResult Index()
        {
            var student = studentRepository.DetailwithName(User.Identity.Name);
            if (student!=null)
            {
                var lesson = db.Lesson.Where(x => x.SelectionalTerm <= student.Term).ToList();
                return View(lesson);
            }
            return View();
        }
        public ActionResult Add(int id)
        {

            var lesson = lessonRepository.Detail(id);
            if (lesson != null)
            {
                return View(lesson);
            }
            TempData["Message"] = "Not Found Lesson";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(int Id,string Name)
        {
            SelectionLesson lesson = new SelectionLesson()
            {
                StudentId = studentRepository.DetailwithName(User.Identity.Name).Id,
                LessonId = lessonRepository.Detail(Id).Id
            };
            TempData["Message"] = selectionLessonRepository.Add(lesson) ?
                                    "Lesson Added Successful" :
                                    "Lesson Insert Failed";
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}