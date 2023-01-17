using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolAutomationSystem.Models.Abstract
{
    abstract public class AbstractGeneric
    {
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}