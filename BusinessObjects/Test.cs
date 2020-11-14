using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Test
    {
        public Guid TestID { get; set; }
        public string TestTitle { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TeacherID { get; set; }
        public Guid ClassID { get; set; }
        public Status Status { get; set; }
        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public List<Answer> Answers { get; set; }

    }
}