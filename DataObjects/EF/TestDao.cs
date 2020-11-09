using AutoMapper;
using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace DataObjects.EF
{
    public class TestDao : ITestDao
    {
        static TestDao()
        {
            Mapper.CreateMap<TestEntity, Test>();
            Mapper.CreateMap<Test, TestEntity>();
            Mapper.CreateMap<Teacher, TestEntity>();
        }

        public List<Test> GetClassTestsForTeacher(string classID, string searchValue, int page, int pageSize, string sortExpression = "TestTitle ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.TestEntities.AsQueryable().Where(x => x.ClassID.ToString() == classID);
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.TestTitle.Contains(searchValue));
                }
                var tests = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<TestEntity>, List<Test>>(tests);
            }
        }

        public List<Test> GetClassTestsForTeacher(string classID, string searchValue, string sortExpression = "TestTitle ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.TestEntities.AsQueryable().Where(x => x.ClassID.ToString() == classID);
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.TestTitle.Contains(searchValue));
                }
                var tests = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<TestEntity>, List<Test>>(tests);
            }
        }

        public Test GetTest(string testID)
        {
            using (var context = new StudentManagementDBContext())
            {
                var test = context.TestEntities.FirstOrDefault(c => c.TestID.ToString() == testID) as TestEntity;
                return Mapper.Map<TestEntity, Test>(test);
            }
        }

        public List<Test> GetTestsForTeacher(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "TestTitle ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.TestEntities.AsQueryable().Where(x => x.TeacherID == teacherID);
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.TestTitle.Contains(searchValue));
                }
                var tests = query.OrderBy(sortExpression).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Mapper.Map<List<TestEntity>, List<Test>>(tests);
            }
        }

        public List<Test> GetTestsForTeacher(string teacherID, string searchValue, string sortExpression = "TestTitle ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.TestEntities.AsQueryable().Where(x => x.TeacherID == teacherID);
                if (!string.IsNullOrEmpty(searchValue))
                {
                    query = query.Where(s => s.TestTitle.Contains(searchValue));
                }
                var tests = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<TestEntity>, List<Test>>(tests);
            }
        }
        public void InactiveTest(string testID)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.TestEntities.SingleOrDefault(c => c.TestID.ToString().Equals(testID));
                entity.Status = 1;
                context.SaveChanges();
            }
        }

        public void EditTest(Test test)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.TestEntities.SingleOrDefault(m => m.TestID == test.TestID);
                entity.TestTitle = test.TestTitle;
                entity.Description = test.Description;
                entity.CreateDate = test.CreateDate;
                entity.EndDate = test.EndDate;
                entity.TeacherID = test.TeacherID;
                entity.ClassID = test.ClassID;
                entity.Status = test.Status == Status.Active ? 0 : 1;
                context.SaveChanges();
            }
        }

        public void AddTest(Test test)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = Mapper.Map<Test, TestEntity>(test);
                entity.Status = 0;
                entity.TestID = Guid.NewGuid();
                context.TestEntities.Add(entity);
                context.SaveChanges();
            }
        }
    }
}
