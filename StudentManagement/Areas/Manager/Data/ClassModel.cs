using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Areas.Manager.Data
{
    public class ClassModel
    {
        public Guid ClassID { get; set; }

        [Required(ErrorMessage = "Class name is required.")]
        [StringLength(100, ErrorMessage = "Class name can be at most 100 characters")]
        public string ClassName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public Status Status { get; set; }
        public string TeacherID { get; set; }

        public PersonModel Teacher { get; set; }
    }
}