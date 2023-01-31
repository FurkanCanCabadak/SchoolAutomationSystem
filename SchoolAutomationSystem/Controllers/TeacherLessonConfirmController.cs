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
    public class TeacherLessonConfirmController : Controller
    {
        DataAccess db = new DataAccess();
        SelectionLessonRepository selectionLessonRepository = new SelectionLessonRepository();
        StudentRepository studentRepository = new StudentRepository();

        // GET: TeacherLessonConfirm
        public ActionResult Index()
        {
            var students = db.Student.Where(x=>x.IsStatus==true&&x.IsDelete==false).ToList();
            return View(students);
        }
        public ActionResult Delete(int id)
        {
            var selectionLesson = db.SelectionLesson.Where(x=>x.StudentId==id).ToList();
            if (selectionLesson.Count != 0)
            {
                foreach (var item in selectionLesson)
                {
                    item.IsDelete = true;
                    selectionLessonRepository.Edit(item);
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            
            var user = studentRepository.Detail(id);
            if (user != null)
            {
                var model = new StudentLessonSelectionLesson();
                model.SingleStudent = user;
                model.SelectionLessonList = db.SelectionLesson.Where(x => x.StudentId == id&&x.IsStatus==false).ToList();
                model.LessonList = db.Lesson.Where(x => x.IsDelete == false && x.IsStatus == true).ToList();
                return View(model);
            }
            TempData["Message"] = "Student didnt select any lesson";
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(int StudentId,int LessonId)
        {
            var lesson = selectionLessonRepository.DetailwithId(StudentId,LessonId);
            lesson.IsStatus = true;
               
            TempData["Message"] = selectionLessonRepository.Edit(lesson) ?
                                   "Student Lesson Confirm Successful" :
                                   "Student Lesson Confirm Failed";
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}