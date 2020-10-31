using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Test
    {
        public Guid TestID { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 3)]
        public string TestTitle { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string TeacherID { get; set; }
        public Guid ClassID { get; set; }
        public Status Status { get; set; }

        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public List<Answer> Answers { get; set; }

    }
}