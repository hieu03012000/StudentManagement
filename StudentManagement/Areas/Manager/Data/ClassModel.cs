using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace StudentManagement.Areas.Manager.Data
{
    public class ClassModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ClassID { get; set; }

        [Required(ErrorMessage = "Class name is required.")]
        [StringLength(100, ErrorMessage = "Class name can be at most 100 characters")]
        public string ClassName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public Status Status { get; set; }

        public string TeacherID { get; set; }

        public IEnumerable<SelectListItem> Teachers { get; set; }

        public PersonModel Teacher { get; set; }

    }
}