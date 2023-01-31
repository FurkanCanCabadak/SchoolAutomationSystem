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
    public class TeacherGiveNoteController : Controller
    {
        TeacherRepository teacherRepository =new TeacherRepository();
        SelectionLessonRepository selectionLessonRepository =new SelectionLessonRepository();
        DataAccess db = new DataAccess();
        // GET: TeacherGiveNote
        public ActionResult Index()
        {
            var teacher = teacherRepository.DetailwithName(User.Identity.Name);
            var model = new StudentLessonSelectionLesson();
            model.LessonList = db.Lesson.Where(x => x.IsDelete == false && x.IsStatus == true).ToList();
            model.NoteList = db.Note.Where(x=>x.IsDelete==false&&x.IsStatus==true).ToList();
            model.SelectionLessonList= db.SelectionLesson.Where(x=>x.IsStatus==true&&x.IsDelete==false&&x.LessonId==teacher.LessonId).ToList();
            model.StudentList=db.Student.Where(x => x.IsDelete == false && x.IsStatus == true).ToList();
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var selectionLesson = selectionLessonRepository.Detail(id);
            if (selectionLesson != null)
            {

                return View(selectionLesson);
            }
            TempData["Message"] = "Not Found Selection Lesson";
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Edit(SelectionLesson selectionLesson)
        {
            TempData["Message"] = selectionLessonRepository.EditNote(selectionLesson) ?
                                   "Note Edited Successful" :
                                   "Note Edit Failed";

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}