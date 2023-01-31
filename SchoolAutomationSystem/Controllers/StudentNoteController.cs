using SchoolAutomationSystem.Models.EntityModel;
using SchoolAutomationSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolAutomationSystem.Controllers
{
    public class StudentNoteController : Controller
    {
        StudentRepository studentRepository=new StudentRepository();
        SelectionLessonRepository selectionLessonRepository=new SelectionLessonRepository();
        LessonRepository lessonRepository=new LessonRepository();
        NoteRepository noteRepository = new NoteRepository();
        // GET: StudentNote
        public ActionResult Index()
        {
            var student = studentRepository.DetailwithName(User.Identity.Name);
            if (student!=null)
            {
                var model = new StudentLessonSelectionLesson();
                model.SingleStudent = student;
                model.SelectionLessonList = selectionLessonRepository.List(student.Id);
                model.LessonList = lessonRepository.List();
                model.NoteList=noteRepository.List();
                return View(model);
            }
            return View("Index","Student");
        }
    }
}