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
        public string Username { get; set; }

        [Required(ErrorMessage = "Fullname is required.")]
        [StringLength(50, ErrorMessage = "Fullname can be at most 50 characters")]
        public string Fullname { get; set; }


        public Gender Gender { get; set; }

        [Phone(ErrorMessage = "Please enter a valid Phone number")]
        public string Phone { get; set; }

        [StringLength(50, ErrorMessage = "Address can be at most 50 characters")]
        public string Address { get; set; }
        
        public string Image { get; set; }

        public HttpPostedFileBase File { get; set; }

    }
}