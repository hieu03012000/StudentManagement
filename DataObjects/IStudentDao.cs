using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public interface IStudentDao
    {
        Student GetStudent(string Username);

        List<Student> GetStudents(string searchValue, int page, int pageSize, string sortExpression = "Username ASC");
        List<Student> GetStudents(string searchValue, string sortExpression = "Username ASC");

        List<Student> GetClassStudents(string ClassName, string sortExpression = "Username ASC");
    }
}
