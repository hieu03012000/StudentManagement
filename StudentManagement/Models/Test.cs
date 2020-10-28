using StudentManagement.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Test
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TestID { get; set; }

        [Required]
        [Display(Name = "Title")]
        [StringLength(50, MinimumLength = 3)]
        public string TestTitle { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [ForeignKey("Teacher")]

        public string TeacherID { get; set; }

        [ForeignKey("Class")]
        public Guid ClassID { get; set; }
        public Status Status { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Class Class { get; set; }
        public virtual List<Answer> Answers { get; set; }

    }
}