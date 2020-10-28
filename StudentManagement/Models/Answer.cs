using StudentManagement.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AnswerID { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 3)]
        public string AnswerTitle { get; set; }

        [DisplayFormat(NullDisplayText = "No Description")]

        public string? Description { get; set; }

        [DisplayFormat(NullDisplayText = "No File")]
        public string? File { get; set; }

        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Range(0, 10)]
        public float Mark { get; set; }
        public Status Status { get; set; }

        [ForeignKey("Student")]
        public string StudentID { get; set; }

        [ForeignKey("Test")]
        public Guid TestID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Test Test { get; set; }

    }
}