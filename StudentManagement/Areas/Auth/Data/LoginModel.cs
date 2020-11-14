using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Areas.Auth.Data
{
    public class LoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}