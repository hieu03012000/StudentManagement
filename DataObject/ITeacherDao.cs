using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.EF
{
    public interface ITeacherDao
    {
        Teacher GetTeacher(string Username);

        List<Teacher> GetTeachers(string sortExpression = "Username ASC");
    }
}
