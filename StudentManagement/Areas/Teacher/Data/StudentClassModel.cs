using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Areas.Teacher.Data
{
    public class StudentClassModel
    {
        public Guid ID { get; set; }
        public string ClassID { get; set; }
        public string StudentID { get; set; }
        public PersonModel Student { get; set; }
        public ClassModel Class { get; set; }
        public IEnumerable<SelectListItem> AvailableStudents { get; set; }
    }
}