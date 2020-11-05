using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Manager.Data
{
    public class PersonModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Not match with password")]
        public string Confirm { get; set; }

        [Required(ErrorMessage = "Fullname is required.")]
        [StringLength(100, ErrorMessage = "Fullname can be at most 100 characters")]
        public string Fullname { get; set; }

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address can be at most 100 characters")]
        public string Address { get; set; }

        public Status Status { get; set; }

        public string Role { get; set; }
    }
}