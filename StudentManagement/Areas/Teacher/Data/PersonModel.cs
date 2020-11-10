using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Teacher.Data
{
    public class PersonModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
        public string Role { get; set; }
        public string ClassID { get; set; }

    }
}