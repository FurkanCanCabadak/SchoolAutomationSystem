using SchoolAutomationSystem.DataAccessLayer;
using SchoolAutomationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Repository
{
    public class NoteRepository : IGenericRepository<Note>
    {
        DataAccess db = new DataAccess();
        public bool Add(Note entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Note Detail(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Note entity)
        {
            throw new NotImplementedException();
        }

        public List<Note> List()
        {
            return db.Note.Where(x=>x.IsDelete==false).ToList();
        }
    }
}