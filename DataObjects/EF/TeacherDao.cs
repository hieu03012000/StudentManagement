using AutoMapper;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.EF
{
    public class TeacherDao : ITeacherDao
    {
        static TeacherDao()
        {
            Mapper.CreateMap<PersonEntity, Teacher>();
            Mapper.CreateMap<Teacher, PersonEntity>();
        }
        public Teacher GetTeacher(string Username)
        {
            using (var context = new StudentManagementDBContext())
            {
                var teacher = context.PersonEntities.FirstOrDefault(c => c.Username == Username) as PersonEntity;
                return Mapper.Map<PersonEntity, Teacher>(teacher);
            }
        }

        public List<Teacher> GetTeachers(string searchValue, int page, int pageSize, string sortExpression = "Username ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.PersonEntities.AsQueryable().Where(u => (u.Discriminator == "Teacher" && u.Status == 0));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.Username.Contains(searchValue) || s.Fullname.Contains(searchValue)); 
                }
                var teachers = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<PersonEntity>, List<Teacher>>(teachers);
            }
        }

        public List<Teacher> GetTeachers(string searchValue, string sortExpression = "Username ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.PersonEntities.AsQueryable().Where(u => (u.Discriminator == "Teacher" && u.Status == 0));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.Username.Contains(searchValue) || s.Fullname.Contains(searchValue));
                }

                var teachers = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<PersonEntity>, List<Teacher>>(teachers);
            }
        }
    }
}
