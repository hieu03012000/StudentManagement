using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Areas.Teacher.Data
{
    public class TestModel
    {
        public Guid TestID { get; set; }

        [Required(ErrorMessage = "Test Title is required.")]
        [StringLength(100, ErrorMessage = "Test Title can be at most 100 characters")]
        public string TestTitle { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string TeacherID { get; set; }
        public Guid ClassID { get; set; }
        public Status Status { get; set; }
        public PersonModel Teacher { get; set; }
        public ClassModel Class { get; set; }
        public int TotalAnswers { get; set; }
    }
}