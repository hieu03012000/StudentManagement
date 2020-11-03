using AutoMapper;
using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.EF
{
    public class PersonDao : IPersonDao
    {
        static PersonDao()
        {
            Mapper.CreateMap<PersonEntity, Person>();
            Mapper.CreateMap<Person, PersonEntity>();
        }

        public bool GetPerson(string Username, string Password)
        {
            using (var context = new StudentManagementDBContext())
            {
                var result = context.PersonEntities.SingleOrDefault(c => c.Username == Username) as PersonEntity;
                if(result == null)
                {
                    return false;
                }
                if (result.Password.Equals(Password))
                {
                    return true;
                }
                return false;
            }
        }

        public Person GetPersonByUsername(string Username)
        {
            using (var context = new StudentManagementDBContext())
            {
                var result = context.PersonEntities.SingleOrDefault(c => c.Username == Username) as PersonEntity;
                return Mapper.Map<PersonEntity, Person>(result);
            }
        }

        public void ChangePassword(string username, string password)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.PersonEntities.SingleOrDefault(m => m.Username == username);
                entity.Password = password;

                context.SaveChanges();

            }
        }

        public void ChangeProfile(string username, string fullName, Gender gender, string phone, string address)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.PersonEntities.SingleOrDefault(m => m.Username == username);
                entity.Fullname = fullName;
                entity.Gender = gender == Gender.Male ? 0 : 1;
                entity.Phone = phone;
                entity.Address = address;

                context.SaveChanges();

            }
        }

        public void CreateAccount(string username, string password, string fullname, string phone, string address, Gender gender, string role)
        {
            using (var context = new StudentManagementDBContext())
            {
                context.PersonEntities.Add(new PersonEntity
                {
                    Username = username,
                    Password = password,
                    Fullname = fullname,
                    Phone = phone,
                    Address = address,
                    Gender = (gender == Gender.Male ? 0 : 1),
                    Discriminator = role,
                    Status = 0
                });
                context.SaveChanges();
            }
        }
    }
}
