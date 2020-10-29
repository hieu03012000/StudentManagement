namespace StudentManagement.Migrations
{
    using StudentManagement.Models;
    using StudentManagement.Models.Enum;
    using StudentSystem.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentManagement.DAL.StudentManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentManagement.DAL.StudentManagementContext context)
        {
            var students = new List<Student>
            {
                new Student
                {
                    Username = "phuongpt", Password = "123456",
                    Fullname = "Phạm Thanh Phương", Gender = Gender.Male,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                },
                new Student
                {
                    Username = "hieunt", Password = "123456",
                    Fullname = "Nguyễn Thị Hiếu", Gender = Gender.Male,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                },
                new Student
                {
                    Username = "tramdb", Password = "123456",
                    Fullname = "Đào Bảo Trâm", Gender = Gender.Female,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                }
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher
                {
                    Username = "phuongptt", Password = "123456",
                    Fullname = "Phạm Thanh Phương", Gender = Gender.Female,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                },
                new Teacher
                {
                    Username = "hieuntt", Password = "123456",
                    Fullname = "Nguyễn Thị Hiếu", Gender = Gender.Female,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                },
                new Teacher
                {
                    Username = "tramdbt", Password = "123456",
                    Fullname = "Đào Bảo Trâm", Gender = Gender.Male,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                }
            };
            teachers.ForEach(s => context.Teachers.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();

            var managers = new List<Manager>
            {
                new Manager
                {
                    Username = "phuongptmg", Password = "123456",
                    Fullname = "Phạm Thanh Phương", Gender = Gender.Female,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                },
                new Manager
                {
                    Username = "hieunttmg", Password = "123456",
                    Fullname = "Nguyễn Thị Hiếu", Gender = Gender.Male,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                },
                new Manager
                {
                    Username = "tramdbtmg", Password = "123456",
                    Fullname = "Đào Bảo Trâm", Gender = Gender.Male,
                    Address = "TP HCM", Phone = "0123456789", Status = Status.Active
                }
            };
            managers.ForEach(s => context.Managers.AddOrUpdate(p => p.Username, s));
            context.SaveChanges();
        }
    }
}
