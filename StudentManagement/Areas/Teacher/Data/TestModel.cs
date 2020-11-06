using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Teacher.Data
{
    public class TestModel
    {
        public Guid TestID { get; set; }
        public string TestTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TeacherID { get; set; }
        public Guid ClassID { get; set; }
        public Status Status { get; set; }
        public PersonModel Teacher { get; set; }
        public ClassModel Class { get; set; }
        //public List<Answer> Answers { get; set; }
    }
}