using BusinessObjects;
using System.Collections.Generic;

namespace ServiceObject
{
    public interface IService
    {
        
        bool Login(string Username, string Password);

        Person GetPersonByUsername(string Username);

        void Logout();

        //Teacher respository
        Teacher GetTeacher(string Username);

        List<Teacher> GetTeachers(string searchValue, string sortExpression, int page, int pageSize);
        List<Teacher> GetTeachers(string searchValue, string sortExpression);
    }
}