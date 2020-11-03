using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Auth.Data
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Old password is required.")]
        [DataType(DataType.Password)]
        [Compare("OldPassword", ErrorMessage = "Not match with old password")]
        public string CheckOldPassword { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, ErrorMessage = "Must be between 6 and 50 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm passrord is required.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Comfirm { get; set; }
    }
}