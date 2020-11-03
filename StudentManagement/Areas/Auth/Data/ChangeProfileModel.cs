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
        [StringLength(100, ErrorMessage = "Fullname can be at most 100 characters")]
        public string Fullname { get; set; }


        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Please enter a valid Phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(100, ErrorMessage = "Address can be at most 100 characters")]
        public string Address { get; set; }

    }
}