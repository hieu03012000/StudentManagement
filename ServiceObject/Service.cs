using BusinessObjects;
using BusinessObjects.Enums;
using DataObjects;
using System;
using System.Collections.Generic;

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

        public List<Student> GetStudentsForManager(string searchValue, string sortExpression, int page, int pageSize)
        {
            return studentDao.GetStudentsForManager(searchValue, page, pageSize, sortExpression);
        }

        public List<Student> GetStudentsForManager(string searchValue, string sortExpression)
        {
            return studentDao.GetStudentsForManager(searchValue, sortExpression);
        }

        public List<Student> GetClassStudentsForManager(string ClassName, string sortExpression)
        {
            return studentDao.GetClassStudentsForManager(ClassName, sortExpression);
        }

        //Teacher Services
        public Teacher GetTeacher(string Username)
        {
            return teacherDao.GetTeacher(Username);
        }

        public List<Teacher> GetTeachersForManager(string searchValue, string sortExpression, int page, int pageSize)
        {
            return teacherDao.GetTeachersForManager(searchValue, page, pageSize, sortExpression);
        }

        public List<Teacher> GetTeachersForManager(string searchValue, string sortExpression)
        {
            return teacherDao.GetTeachersForManager(searchValue, sortExpression);
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
        public void InactivePerson(string username)
        {
            personDao.InactivePerson(username);
        }
        public void EditPerson(Person person)
        {
            personDao.EditPerson(person);
        }

        //Class Services
        public Class GetClass(string ClassName)
        {
            return classDao.GetClass(ClassName);
        }

        public List<Class> GetClassesForManager(string searchValue, string sortExpression, int page, int pageSize)
        {
            return classDao.GetClassesForManager(searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetClassesForManager(string searchValue, string sortExpression)
        {
            return classDao.GetClassesForManager(searchValue, sortExpression);
        }

        public List<Class> GetTeacherClassesForManager(string teacherID, string searchValue, int page, int pageSize, string sortExpression)
        {
            return classDao.GetTeacherClassesForManager(teacherID, searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetTeacherClassesForManager(string teacherID, string searchValue, string sortExpression)
        {
            return classDao.GetTeacherClassesForManager(teacherID, searchValue, sortExpression);
        }

        public List<Class> GetStudentClassesForManager(string teacherID, string searchValue, int page, int pageSize, string sortExpression)
        {
            return classDao.GetStudentClassesForManager(teacherID, searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetStudentClassesForManager(string teacherID, string searchValue, string sortExpression)
        {
            return classDao.GetStudentClassesForManager(teacherID, searchValue, sortExpression);
        }

        
        public void InactiveClass(string classID)
        {
            classDao.InactiveClass(classID);
        }
        public void EditClass(Class c)
        {
            classDao.EditClass(c);
        }
    }
}