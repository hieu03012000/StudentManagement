using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Student.Data
{
    public class ClassModel
    {
        public Guid ClassID { get; set; }
        public string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public string TeacherID { get; set; }
        public PersonModel Teacher { get; set; }
    }
}