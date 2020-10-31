using DataObject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IDaoFactory
    {
        IStudentDao StudentDao { get; }
        ITeacherDao TeacherDao { get; }
        IManagerDao ManagerDao { get; }
        IClassDao ClassDao { get; }
        ITestDao TestDao { get; }
        IAnswerDao AnswerDao { get; }
    }
}
