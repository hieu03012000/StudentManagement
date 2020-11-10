using AutoMapper;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;


namespace DataObjects.EF
{
    public class StudentDao : IStudentDao
    {
        static StudentDao()
        {
            Mapper.CreateMap<PersonEntity, Student>();
            Mapper.CreateMap<Student, PersonEntity>();

            Mapper.CreateMap<ClassStudent, ClassStudentEntity>();
            Mapper.CreateMap<ClassStudentEntity, ClassStudent>();
        }

        public Student GetStudent(string Username)
        {
            using (var context = new StudentManagementDBContext())
            {
                var student = context.PersonEntities.FirstOrDefault(c => c.Username == Username) as PersonEntity;
                return Mapper.Map<PersonEntity, Student>(student);
            }
        }

        public List<Student> GetStudentsForManager(string searchValue, int page, int pageSize, string sortExpression = "Username ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.PersonEntities.AsQueryable().Where(u => (u.Discriminator == "Student"));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.Username.Contains(searchValue) || s.Fullname.Contains(searchValue));
                }
                var students = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<PersonEntity>, List<Student>>(students);
            }
        }

        public List<Student> GetStudentsForManager(string searchValue, string sortExpression = "Username ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.PersonEntities.AsQueryable().Where(u => (u.Discriminator == "Student"));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.Username.Contains(searchValue) || s.Fullname.Contains(searchValue));
                }

                var students = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<PersonEntity>, List<Student>>(students);
            }
        }


        public List<Student> GetClassStudents(string classID, string sortExpression = "Username ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.PersonEntities.Where(x => x.ClassStudents.Any(c => c.ClassID.ToString() == classID) && x.Status == 0);
                var students = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<PersonEntity>, List<Student>>(students);
            }
        }

        public List<Student> GetAvailableClassStudents(List<Student> list)
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.PersonEntities.AsQueryable().Where(x => x.Status == 0 && x.Discriminator == "Student");
                var students = Mapper.Map<List<PersonEntity>, List<Student>>(query.OrderBy("Username ASC").ToList());
                foreach (var item in list)
                {
                    System.Diagnostics.Debug.WriteLine("list " + item.Username);
                }
                foreach (var item in students)
                {
                    System.Diagnostics.Debug.WriteLine("stu " + item.Username);
                }
                //Dong nay ko hd
                var s = students.Except(list).ToList();
                foreach (var item in s)
                {
                    System.Diagnostics.Debug.WriteLine("student " + item.Username);
                }
                return s;
            }
        }
    }
}
