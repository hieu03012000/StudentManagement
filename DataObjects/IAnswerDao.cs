using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public interface IAnswerDao
    {
        Answer GetAnswer(string answerID);

        List<Answer> GetAnswersForTeacher(string testID, string sortExpression = "AnswerTitle ASC");
        Answer GetAnswerForStudent(string testID, string studentID);
        void AddAnswer(Answer answer);

    }
}
