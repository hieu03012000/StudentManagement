using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;

namespace ServiceObject
{
    public interface IService
    {
        //User respository
        bool Login(string Username, string Password);
        Person GetPersonByUsername(string Username);
        void ChangeProfile(string username, string fullName, Gender gender, string phone, string address);
        void ChangePassword(string username, string password);
        void CreateAccount(string username, string password, string fullname, string phone, string address, Gender gender, string role);
        void InactivePerson(string username);

        //Teacher respository
        Teacher GetTeacher(string Username);

        List<Teacher> GetTeachersForManager(string searchValue, string sortExpression, int page, int pageSize);
        List<Teacher> GetTeachersForManager(string searchValue, string sortExpression);

        //Student respository
        Student GetStudent(string Username);

        List<Student> GetStudentsForManager(string searchValue, string sortExpression, int page, int pageSize);
        List<Student> GetStudentsForManager(string searchValue, string sortExpression);
        List<Student> GetClassStudents(string classID, string sortExpression);

        //Class respository
        Class GetClass(string classID);

        List<Class> GetClassesForManager(string searchValue, string sortExpression, int page, int pageSize);
        List<Class> GetClassesForManager(string searchValue, string sortExpression);

        List<Class> GetTeacherClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression);
        List<Class> GetTeacherClasses(string teacherID, string searchValue, string sortExpression);

        List<Class> GetTeacherClassesForManager(string teacherID, string searchValue, int page, int pageSize, string sortExpression);
        List<Class> GetTeacherClassesForManager(string teacherID, string searchValue, string sortExpression);

        List<Class> GetStudentClasses(string teacherID, string searchValue, int page, int pageSize, string sortExpression);
        List<Class> GetStudentClasses(string teacherID, string searchValue, string sortExpression);
        void InactiveClass(string classID);

    }
}