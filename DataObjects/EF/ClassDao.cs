using AutoMapper;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace DataObjects.EF
{
    public class ClassDao : IClassDao
    {
        static ClassDao()
        {
            Mapper.CreateMap<Class, ClassEntity>();
            Mapper.CreateMap<ClassEntity, Class>();

            Mapper.CreateMap<ClassStudent, ClassStudentEntity>();
            Mapper.CreateMap<ClassStudentEntity, ClassStudent>();
        }

        public Class GetClass(string ClassName)
        {
            using (var context = new StudentManagementDBContext())
            {
                var cs = context.ClassEntities.FirstOrDefault(c => c.ClassName == ClassName);
                return Mapper.Map<ClassEntity, Class>(cs);
            }
        }

        public List<Class> GetClasses(string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.ClassEntities.AsQueryable().Where(u => u.Status == 0);
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }

        public List<Class> GetClasses(string searchValue, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.ClassEntities.AsQueryable().Where(u => u.Status == 0);
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }

        public List<Class> GetTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.ClassEntities.AsQueryable().Where(u => (u.Status == 0 && u.TeacherID == teacherID));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }

        public List<Class> GetTeacherClasses(string teacherID, string searchValue, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.ClassEntities.AsQueryable().Where(u => (u.Status == 0 && u.TeacherID == teacherID));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).ToList();

                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }

        public List<Class> GetStudentClasses(string studentID, string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = from s in context.ClassEntities
                        from e in s.ClassStudents
                        where e.Person.Username == studentID && s.Status == 0
                        select s;
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }

        public List<Class> GetStudentClasses(string studentID, string searchValue, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = from s in context.ClassEntities
                            from e in s.ClassStudents
                            where e.Person.Username == studentID && s.Status == 0
                            select s;
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }

        public void DeleteClass(string classID)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.ClassEntities.SingleOrDefault(c => c.ClassID.ToString().Equals(classID));
                entity.Status = 1;
                context.SaveChanges();
            }
        }
    }
}
