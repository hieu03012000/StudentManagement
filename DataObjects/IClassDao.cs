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
        Class GetClass(string classID);

        List<Class> GetClassesForManager(string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC");
        List<Class> GetClassesForManager(string searchValue, string sortExpression = "ClassName ASC");

        List<Class> GetActiveTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC");
        List<Class> GetActiveTeacherClasses(string teacherID, string searchValue, string sortExpression = "ClassName ASC");

        List<Class> GetTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC");
        List<Class> GetTeacherClasses(string teacherID, string searchValue, string sortExpression = "ClassName ASC");

        List<Class> GetStudentClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC");
        List<Class> GetStudentClasses(string teacherID, string searchValue, string sortExpression = "ClassName ASC");

        void InactiveClass(string classID);
        void EditClass(Class c);
        void AddClass(Class c);

        void AddStudentClass(ClassStudent classStudent);
        void RemoveStudentClass(ClassStudent classStudent);
    }
}
