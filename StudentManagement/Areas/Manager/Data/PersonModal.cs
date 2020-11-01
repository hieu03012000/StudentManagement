using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Manager.Data
{
    public class PersonModal
    {
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Full name")]
        [StringLength(50, MinimumLength = 3)]
        public string Fullname { get; set; }

        public Gender Gender { get; set; }

        public string Phone { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
    }
}