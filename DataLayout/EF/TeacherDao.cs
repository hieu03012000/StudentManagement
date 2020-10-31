using AutoMapper;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.EF
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

        public List<Teacher> GetTeachers(string sortExpression = "Username ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var teachers = context.PersonEntities.AsQueryable().OrderBy(sortExpression).ToList();
                return Mapper.Map<List<PersonEntity>, List<Teacher>>(teachers);
            }
        }
    }
}
