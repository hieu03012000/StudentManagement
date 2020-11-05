using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public interface IClassDao
    {
        Class GetClass(string Username);

        List<Class> GetClassesForManager(string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC");
        List<Class> GetClassesForManager(string searchValue, string sortExpression = "ClassName ASC");

        List<Class> GetTeacherClassesForManager(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC");
        List<Class> GetTeacherClassesForManager(string teacherID, string searchValue, string sortExpression = "ClassName ASC");

        List<Class> GetStudentClassesForManager(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC");
        List<Class> GetStudentClassesForManager(string teacherID, string searchValue, string sortExpression = "ClassName ASC");

        void InactiveClass(string classID);
        void EditClass(Class c);
    }
}
