using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.EF
{
    public class DaoFactory : IDaoFactory
    {
        public IStudentDao StudentDao { get { return new StudentDao(); } }

        public ITeacherDao TeacherDao { get { return new TeacherDao(); } }

        public IManagerDao ManagerDao { get { return new ManagerDao(); } }

        public IClassDao ClassDao { get { return new ClassDao(); } }

        public ITestDao TestDao { get { return new TestDao(); } }

        public IAnswerDao AnswerDao { get { return new AnswerDao(); } }
    }
}
