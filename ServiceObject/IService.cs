using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;

namespace ServiceObject
{
    public interface IService
    {
        //User Repository
        bool Login(string Username, string Password);
        Person GetPersonByUsername(string Username);
        void ChangeProfile(Person person);
        void ChangePassword(string username, string password);
        void CreateAccount(string username, string password, string fullname, string phone, string address, Gender gender, string role);
        void InactivePerson(string username);
        void EditPerson(Person person);

        //Teacher Repository
        Teacher GetTeacher(string Username);

        List<Teacher> GetTeachersForManager(string searchValue, string sortExpression, int page, int pageSize);
        List<Teacher> GetTeachersForManager(string searchValue, string sortExpression);
        List<Teacher> GetTeachersForManager();

        //Student Repository
        Student GetStudent(string Username);

        List<Student> GetStudentsForManager(string searchValue, string sortExpression, int page, int pageSize);
        List<Student> GetStudentsForManager(string searchValue, string sortExpression);
        List<Student> GetClassStudents(string classID, string sortExpression);

        //Class Repository
        Class GetClass(string classID);

        List<Class> GetClassesForManager(string searchValue, string sortExpression, int page, int pageSize);
        List<Class> GetClassesForManager(string searchValue, string sortExpression);

        List<Class> GetTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression);
        List<Class> GetTeacherClasses(string teacherID, string searchValue, string sortExpression);

        List<Class> GetActiveTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression);
        List<Class> GetActiveTeacherClasses(string teacherID, string searchValue, string sortExpression);

        List<Class> GetStudentClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression);
        List<Class> GetStudentClasses(string teacherID, string searchValue, string sortExpression);
        void InactiveClass(string classID);
        void EditClass(Class c);
        void AddClass(Class c);


        //Test Repository
        Test GetTest(string testID);
        void InactiveTest(string testID);
        List<Test> GetTestsForTeacher(string teacherID, string searchValue, int page, int pageSize, string sortExpression);
        List<Test> GetTestsForTeacher(string teacherID, string searchValue, string sortExpression);
        List<Test> GetClassTestsForTeacher(string classID, string searchValue, string sortExpression);
        List<Test> GetClassTestsForStudent(string classID);
        void EditTest(Test test);
        void AddTest(Test test);

        //Answer Repository
        Answer GetAnswer(String answerID);
        List<Answer> GetAnswersForTeacher(string testID);
        Answer GetAnswerForStudent(string testID, string studentID);


    }
}