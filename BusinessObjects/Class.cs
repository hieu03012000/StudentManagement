using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Class
    {
        public Guid ClassID { get; set; }
        public string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Status Status { get; set; }

        public string TeacherID { get; set; }

        public List<Test> Tests { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

    }
}