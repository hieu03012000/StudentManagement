using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudentManagement.Areas.Infrastructure;
using System.Web;
using BusinessObjects;
namespace StudentManagement.Areas.Manager.Data
{
    public class PersonUpdateModel
    {
        public string Username { get; set; }

        [Required]
        [CheckSpecialCharacter(ErrorMessage = "Fullname can not contain special character")]
        [StringLength(50, MinimumLength = 3)]
        public string Fullname { get; set; }

        public Gender Gender { get; set; }

        [Phone(ErrorMessage = "Please enter a valid Phone number")]
        public string Phone { get; set; }

        [StringLength(100, ErrorMessage = "Address can be at most 100 characters")]
        public string Address { get; set; }

        public Status Status { get; set; }

    }
}