using SchoolAutomationSystem.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models
{
    public class Note : AbstractGeneric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
    }
}