﻿using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class SelectionLessonRepository : IGenericRepository<SelectionLesson>
    {
        DataAccess db = new DataAccess();

        public bool Add(SelectionLesson entity)
        {
            bool result = false;
            try
            {
                var selectionLesson = new SelectionLesson();

                selectionLesson.VisaNote = entity.VisaNote;
                selectionLesson.FinalNote = entity.FinalNote;
                selectionLesson.StudentId = entity.StudentId;
                selectionLesson.SelectionTime = entity.SelectionTime;
                selectionLesson.LessonId = entity.LessonId;
                db.SelectionLesson.Add(selectionLesson);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var selectionLesson = db.SelectionLesson.Find(id);
            if (selectionLesson != null)
            {
                selectionLesson.IsDelete = true;
                db.SaveChanges();
                result = true;

            }
            return result;
        }

        public SelectionLesson Detail(int id)
        {
            var selectionLesson = db.SelectionLesson.Find(id);

            return selectionLesson;
        }

        public bool Edit(SelectionLesson entity)
        {
            bool result = false;
            try
            {
                var selectionLesson = new SelectionLesson();
                selectionLesson.VisaNote = entity.VisaNote;
                selectionLesson.FinalNote = entity.FinalNote;
                selectionLesson.StudentId = entity.StudentId;
                selectionLesson.SelectionTime = entity.SelectionTime;
                selectionLesson.LessonId = entity.LessonId;

                db.SelectionLesson.Add(selectionLesson);
                db.SaveChanges();
                result = true;
            }
            catch { }


            return result;
        }

        public List<SelectionLesson> List()
        {
            return db.SelectionLesson.Where(x => x.IsDelete == false).ToList();
        }
        public List<SelectionLesson> List(int id)
        {
            return db.SelectionLesson.Where(x => x.IsDelete == false&& x.StudentId==id).ToList();
        }
    }
}