using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Auth.Data
{
    public class ChangeProfileModel
    {
        [Required(ErrorMessage = "Fullname is required.")]
        [StringLength(50, ErrorMessage = "Fullname can be at most 50 characters", MinimumLength = 3)]
        public string Fullname { get; set; }


        public Gender Gender { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        public string Address { get; set; }

    }
}