﻿using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Areas.Manager.Data
{
    public class ClassModel
    {
        public Guid ClassID { get; set; }

        [Required]
        [Display(Name = "Class name")]
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
    }
}