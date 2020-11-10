

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

        public List<Student> GetClassStudents(string classID, string sortExpression)
        {
            return studentDao.GetClassStudents(classID, sortExpression);
        }
        public List<Student> GetAvailableClassStudents(List<Student> list)
        {
            return studentDao.GetAvailableClassStudents(list);
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

        public List<Teacher> GetTeachersForManager()
        {
            return teacherDao.GetTeachersForManager("Username desc");
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

        public void ChangeProfile(Person person)
        {
            personDao.ChangeProfile(person);
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
        public Class GetClass(string classID)
        {
            return classDao.GetClass(classID);
        }

        public List<Class> GetClassesForManager(string searchValue, string sortExpression, int page, int pageSize)
        {
            return classDao.GetClassesForManager(searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetClassesForManager(string searchValue, string sortExpression)
        {
            return classDao.GetClassesForManager(searchValue, sortExpression);
        }

        public List<Class> GetActiveTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression)
        {
            return classDao.GetActiveTeacherClasses(teacherID, searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetActiveTeacherClasses(string teacherID, string searchValue, string sortExpression)
        {
            return classDao.GetActiveTeacherClasses(teacherID, searchValue, sortExpression);
        }

        public List<Class> GetTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression)
        {
            return classDao.GetTeacherClasses(teacherID, searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetTeacherClasses(string teacherID, string searchValue, string sortExpression)
        {
            return classDao.GetTeacherClasses(teacherID, searchValue, sortExpression);
        }
        public List<Class> GetStudentClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression)
        {
            return classDao.GetStudentClasses(teacherID, searchValue, page, pageSize, sortExpression);
        }

        public List<Class> GetStudentClasses(string teacherID, string searchValue, string sortExpression)
        {
            return classDao.GetStudentClasses(teacherID, searchValue, sortExpression);
        }
        public void InactiveClass(string classID)
        {
            classDao.InactiveClass(classID);
        }
        public void EditClass(Class c)
        {
            classDao.EditClass(c);
        }
        public void AddClass(Class c)
        {
            classDao.AddClass(c);
        }
        public void AddStudentClass(ClassStudent classStudent)
        {
            classDao.AddStudentClass(classStudent);
        }
        public void RemoveStudentClass(ClassStudent classStudent)
        {
            classDao.RemoveStudentClass(classStudent);
        }

        //Test Services
        public Test GetTest(string testID)
        {
            return testDao.GetTest(testID);
        }
        public List<Test> GetTestsForTeacher(string teacherID, string searchValue, int page, int pageSize, string sortExpression)
        {
            return testDao.GetTestsForTeacher(teacherID, searchValue, page, pageSize, sortExpression);
        }
        public List<Test> GetTestsForTeacher(string teacherID, string searchValue, string sortExpression)
        {
            return testDao.GetTestsForTeacher(teacherID, searchValue, sortExpression);
        }
        public void InactiveTest(string testID)
        {
            testDao.InactiveTest(testID);
        }

        public List<Test> GetClassTestsForTeacher(string classID, string searchValue, string sortExpression)
        {
            return testDao.GetClassTestsForTeacher(classID, searchValue, sortExpression);
        }
        public List<Test> GetClassTestsForStudent(string classID)
        {
            return testDao.GetClassTestsForStudent(classID);
        }

        public void EditTest(Test test)
        {
            testDao.EditTest(test);
        }

        public void AddTest(Test test)
        {
            testDao.AddTest(test);
        }
        //Answer Services

        public Answer GetAnswer(string answerID)
        {
            return answerDao.GetAnswer(answerID);
        }

        public List<Answer> GetAnswersForTeacher(string testID)
        {
            return answerDao.GetAnswersForTeacher(testID);
        }

        public Answer GetAnswerForStudent(string testID, string studentID)
        {
            return answerDao.GetAnswerForStudent(testID, studentID);
        }

        public void AddAnswer(Answer answer)
        {
            answerDao.AddAnswer(answer);
        }

        public void UpdateMark(float mark, Guid answerID)
        {
            answerDao.UpdateMark(mark, answerID);
        }


    }
}