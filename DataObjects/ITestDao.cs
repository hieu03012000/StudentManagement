using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public interface ITestDao
    {
        Test GetTest(string testID);

        List<Test> GetTestsForTeacher(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "TestTitle ASC");
        List<Test> GetTestsForTeacher(string teacherID, string searchValue, string sortExpression = "TestTitle ASC");
        List<Test> GetClassTestsForTeacher(string classID, string searchValue, int page, int pageSize, string sortExpression = "TestTitle ASC");
        List<Test> GetClassTestsForTeacher(string classID, string searchValue, string sortExpression = "TestTitle ASC");
        List<Test> GetClassTestsForStudent(string classID);
        void InactiveTest(string testID);
        void EditTest(Test test);
        void AddTest(Test test);

    }
}
