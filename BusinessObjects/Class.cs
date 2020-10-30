using BusinessObjects.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Class
    {
        public Guid ClassID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string ClassName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public Status Status { get; set; }

        public string TeacherID { get; set; }

        public List<Test> Tests { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

    }
}