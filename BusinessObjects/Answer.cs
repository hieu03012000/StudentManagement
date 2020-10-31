using BusinessObjects.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Answer
    {
        public Guid AnswerID { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 3)]
        public string AnswerTitle { get; set; }

        [DisplayFormat(NullDisplayText = "No Description")]

        public string Description { get; set; }

        [DisplayFormat(NullDisplayText = "No File")]
        public string File { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Range(0, 10)]
        public float Mark { get; set; }
        public Status Status { get; set; }

        public string StudentID { get; set; }

        public Guid TestID { get; set; }

        public Student Student { get; set; }
        public Test Test { get; set; }

    }
}