using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models.EntityModel
{
    public class StudentLessonSelectionLesson
    {
        public Student SingleStudent { get; set; }
        public Lesson SingleLesson { get; set; }
        public List<Lesson> LessonList { get; set; }
        public SelectionLesson SingleSelectionLesson { get; set; }
        public List<SelectionLesson> SelectionLessonList { get; set; }
        public List<Note> NoteList { get; set; }
    }
}