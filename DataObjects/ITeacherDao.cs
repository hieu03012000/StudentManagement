﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public interface ITeacherDao
    {
        Teacher GetTeacher(string Username);

        List<Teacher> GetTeachersForManager(string searchValue, int page, int pageSize,  string sortExpression = "Username ASC");
        List<Teacher> GetTeachersForManager(string searchValue,  string sortExpression = "Username ASC");
        List<Teacher> GetTeachersForManager(string sortExpression = "Username ASC");
    }
}
