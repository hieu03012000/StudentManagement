using BusinessObjects;
using BusinessObjects.Enums;
using DataObject;
using DataObject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceObject
{
    public class Service : IService
    {
        static readonly IDaoFactory factory = DaoFactories.GetFactory();

        static readonly ITeacherDao teacherDao = factory.TeacherDao;
        static readonly IStudentDao studentDao = factory.StudentDao;
        static readonly IManagerDao managerDao = factory.ManagerDao;
        static readonly IClassDao classDao = factory.ClassDao;
        static readonly ITestDao testDao = factory.TestDao;
        static readonly IAnswerDao answerDao = factory.AnswerDao;
        static readonly IPersonDao personDao = factory.PersonDao;



        //Student Services
        public Student GetStudent(string Username)
        {
            return studentDao.GetStudent(Username);
        }

        public List<Student> GetStudents(string searchValue, string sortExpression, int page, int pageSize)
        {
            return studentDao.GetStudents(searchValue, page, pageSize, sortExpression);
        }

        public List<Student> GetStudents(string searchValue, string sortExpression)
        {
            return studentDao.GetStudents(searchValue, sortExpression);
        }

        //Teacher Services
        public Teacher GetTeacher(string Username)
        {
            return teacherDao.GetTeacher(Username);
        }

        public List<Teacher> GetTeachers(string searchValue, string sortExpression, int page, int pageSize)
        {
            return teacherDao.GetTeachers(searchValue, page, pageSize, sortExpression);
        }

        public List<Teacher> GetTeachers(string searchValue, string sortExpression)
        {
            return teacherDao.GetTeachers(searchValue, sortExpression);
        }

        //Person Services
        public bool Login(string Username, string Password)
        {
            return personDao.GetPerson(Username, Password);
        }

        public Person GetPersonByUsername(string Username)
        {
            return personDao.GetPersonByUsername(Username);
        }

        public void ChangeProfile(string username, string fullName, Gender gender, string phone, string address)
        {
            personDao.ChangeProfile(username, fullName, gender, phone, address);
        }

        public void ChangePassword(string username, string password)
        {
            personDao.ChangePassword(username, password);
        }

        public void CreateAccount(string username, string password, string fullname, string phone, string address, Gender gender, string role)
        {
            personDao.CreateAccount(username, password, fullname, phone, address, gender, role);
        }

        //Class Services
        public Class GetClass(string ClassName)
        {
            return classDao.GetClass(ClassName);
        }

        public List<Class> GetClasses(string searchValue, string sortExpression, int page, int pageSize)
        {
            return classDao.GetClasses(searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetClasses(string searchValue, string sortExpression)
        {
            return classDao.GetClasses(searchValue, sortExpression);
        }

        public List<Class> GetTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression)
        {
            return classDao.GetTeacherClasses(teacherID, searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetTeacherClasses(string teacherID, string searchValue, string sortExpression)
        {
            return classDao.GetTeacherClasses(teacherID, searchValue, sortExpression);
        }


    }
}
