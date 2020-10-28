using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Teacher : Person
    {
        public virtual List<Test> Tests { get; set; }
        public virtual List<Class> Classes { get; set; }
    }
}