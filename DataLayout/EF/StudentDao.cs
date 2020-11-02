using AutoMapper;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;


namespace DataObject.EF
{
    public class StudentDao : IStudentDao
    {
        static StudentDao()
        {
            Mapper.CreateMap<PersonEntity, Student>();
            Mapper.CreateMap<Student, PersonEntity>();
        }

        public Student GetStudent(string Username)
        {
            using (var context = new StudentManagementDBContext())
            {
                var student = context.PersonEntities.FirstOrDefault(c => c.Username == Username) as PersonEntity;
                return Mapper.Map<PersonEntity, Student>(student);
            }
        }

        public List<Student> GetStudents(string searchValue, int page, int pageSize, string sortExpression = "Username ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.PersonEntities.AsQueryable().Where(u => (u.Discriminator == "Student" && u.Status == 0));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.Username.Contains(searchValue) || s.Fullname.Contains(searchValue));
                }
                var students = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<PersonEntity>, List<Student>>(students);
            }
        }

        public List<Student> GetStudents(string searchValue, string sortExpression = "Username ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.PersonEntities.AsQueryable().Where(u => (u.Discriminator == "Student" && u.Status == 0));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.Username.Contains(searchValue) || s.Fullname.Contains(searchValue));
                }

                var students = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<PersonEntity>, List<Student>>(students);
            }
        }
    }
}
