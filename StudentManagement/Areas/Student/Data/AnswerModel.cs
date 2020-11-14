using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Student.Data
{
    public class AnswerModel
    {
        public Guid AnswerID { get; set; }

        [Required(ErrorMessage = "Class name is required.")]
        [StringLength(100, ErrorMessage = "Class name can be at most 100 characters")]
        public string AnswerTitle { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public HttpPostedFileBase FileName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }
        public float Mark { get; set; }
        public Status Status { get; set; }
        public string StudentID { get; set; }

        [Required(ErrorMessage = "File is unloaded.")]
        public Guid TestID { get; set; }
        public PersonModel Student { get; set; }
        public TestModel Test { get; set; }
    }
}