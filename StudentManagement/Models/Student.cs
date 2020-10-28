using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Student : Person
    {
        public virtual List<Answer> Answers { get; set; }
        public virtual List<Class> Classes { get; set; }

    }
}