using BusinessObjects.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{

    public class Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Status Status { get; set; }
        public string Discriminator { get; set; }
        public string Image { get; set; }
    }
}