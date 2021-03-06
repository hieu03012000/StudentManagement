﻿using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Threading.Tasks;

namespace DataObjects
{
    public interface IPersonDao
    {
        bool GetPerson(string Username, string Password);

        Person GetPersonByUsername(string Username);

        void ChangeProfile(Person person);

        void ChangePassword(string username, string password);

        void CreateAccount(string username, string password, string fullname, string phone, string address, Gender gender, string role);
        void InactivePerson(string username);
        void EditPerson(Person person);
    }
}
