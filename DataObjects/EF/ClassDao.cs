using AutoMapper;
using BusinessObjects;
using BusinessObjects.Enums;
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

        public Class GetClass(string classID)
        {
            using (var context = new StudentManagementDBContext())
            {
                var cs = context.ClassEntities.FirstOrDefault(c => c.ClassID.ToString() == classID);
                return Mapper.Map<ClassEntity, Class>(cs);
            }
        }

        public List<Class> GetClassesForManager(string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.ClassEntities.AsQueryable();
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }

        public List<Class> GetClassesForManager(string searchValue, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.ClassEntities.AsQueryable();
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }
        public List<Class> GetActiveTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.ClassEntities.AsQueryable().Where(u => (u.TeacherID == teacherID && u.Status == 0));
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.ClassName.Contains(searchValue));
                }
                var classes = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<ClassEntity>, List<Class>>(classes);
            }
        }

        public List<Class> GetActiveTeacherClasses(string teacherID, string searchValue, string sortExpression = "ClassName ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.ClassEntities.AsQueryable().Where(u => (u.TeacherID == teacherID && u.Status == 0));
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
                var query = context.ClassEntities.AsQueryable().Where(u => (u.TeacherID == teacherID));
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
                var query = context.ClassEntities.AsQueryable().Where(u => (u.TeacherID == teacherID));
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

        public void InactiveClass(string classID)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.ClassEntities.SingleOrDefault(c => c.ClassID.ToString().Equals(classID));
                entity.Status = 1;
                context.SaveChanges();
            }
        }
        public void EditClass(Class c)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.ClassEntities.SingleOrDefault(m => m.ClassID == c.ClassID);
                entity.ClassName = c.ClassName;
                entity.StartDate = c.StartDate;
                entity.EndDate = c.EndDate;
                entity.TeacherID = c.TeacherID;
                entity.Status = c.Status == Status.Active ? 0 : 1;
                context.SaveChanges();
            }
        }

        public void AddClass(Class c)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = Mapper.Map<Class, ClassEntity>(c);
                entity.Status = 0;
                entity.ClassID = Guid.NewGuid();
                context.ClassEntities.Add(entity);
                context.SaveChanges();
            }
        }

        public void AddStudentClass(ClassStudent classStudent)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = Mapper.Map<ClassStudent, ClassStudentEntity>(classStudent);
                entity.ID = Guid.NewGuid();
                context.ClassStudentEntities.Add(entity);
                context.SaveChanges();
            }
        }
        public void RemoveStudentClass(ClassStudent classStudent)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.ClassStudentEntities.SingleOrDefault(m => m.ClassID == classStudent.ClassID && m.StudentID == classStudent.StudentID);
                context.ClassStudentEntities.Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
