using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.DataAccessLayer
{
    public class DataAccess:DbContext
    {
        
        public DataAccess() : base("DbConnection") { }
    }
}