using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudentManagement.Areas.Infrastructure;
using System.Web;

namespace StudentManagement.Areas.Manager.Data
{
    public class PersonModel
    {
        [Required]
        [CheckDuplicateUsername(ErrorMessage = "Duplicate username")]
        [RegularExpression("^[a-zA-Z0-9_]+$")]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Not match with password")]
        public string Confirm { get; set; }

        [Required]
        [Display(Name = "Full name")]
        [CheckSpecialCharacter(ErrorMessage = "Fullname can not contain special character")]
        [StringLength(50, MinimumLength = 3)]
        public string Fullname { get; set; }

        public Gender Gender { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public Status Status { get; set; }

        public string Role { get; set; }
    }
}