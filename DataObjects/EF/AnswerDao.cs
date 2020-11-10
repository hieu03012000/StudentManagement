using AutoMapper;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace DataObjects.EF
{
    public class AnswerDao : IAnswerDao
    {
        static AnswerDao()
        {
            Mapper.CreateMap<AnswerEntity, Answer>();
            Mapper.CreateMap<Answer, AnswerEntity>();
        }
        public Answer GetAnswer(string answerID)
        {
            using (var context = new StudentManagementDBContext())
            {
                var answer = context.AnswerEntities.FirstOrDefault(c => c.AnswerID.ToString() == answerID) as AnswerEntity;
                return Mapper.Map<AnswerEntity, Answer>(answer);
            }
        }

        public List<Answer> GetAnswersForTeacher(string testID, string sortExpression = "AnswerTitle ASC")
        {
            using (var context = new StudentManagementDBContext())
            {
                var query = context.AnswerEntities.AsQueryable().Where(x => x.TestID.ToString() == testID && x.Status == 0);
                
                var answers = query.OrderBy(sortExpression).ToList();
                return Mapper.Map<List<AnswerEntity>, List<Answer>>(answers);
            }
        }

        public Answer GetAnswerForStudent(string testID, string studentID)
        {
            using (var context = new StudentManagementDBContext())
            {
                var answer = context.AnswerEntities.FirstOrDefault(c => c.TestID.ToString() == testID && c.StudentID == studentID) as AnswerEntity;
                return Mapper.Map<AnswerEntity, Answer>(answer);
            }
        }

        public void AddAnswer(Answer answer)
        {
            using (var context = new StudentManagementDBContext())
            {
                context.AnswerEntities.Add(new AnswerEntity
                {
                    AnswerID = Guid.NewGuid(),
                    AnswerTitle = answer.AnswerTitle,
                    Description = answer.Description,
                    File = answer.File,
                    CreateDate = DateTime.Now,
                    StudentID = answer.StudentID,
                    TestID = answer.TestID  ,
                    Status = 0
                });
                context.SaveChanges();
            }
        }


    }
}
