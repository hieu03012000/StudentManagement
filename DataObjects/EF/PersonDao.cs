using AutoMapper;
using AutoMapper.Internal;
using BusinessObjects;
using BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.EF
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
                if (result.Password.Equals(Password) && result.Status == 0)
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

        public void ChangeProfile(Person person)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.PersonEntities.SingleOrDefault(m => m.Username == person.Username);
                entity.Fullname = person.Fullname;
                entity.Gender = person.Gender == Gender.Male ? 0 : 1;
                entity.Phone = person.Phone;
                entity.Address = person.Address;
                entity.Image = person.Image;

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

        public void InactivePerson(string username)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.PersonEntities.SingleOrDefault(c => c.Username == username);
                entity.Status = 1;
                context.SaveChanges();
            }
        }

        public void EditPerson(Person person)
        {
            using (var context = new StudentManagementDBContext())
            {
                var entity = context.PersonEntities.SingleOrDefault(c => c.Username == person.Username);
                entity.Phone = person.Phone;
                entity.Address = person.Address;
                entity.Fullname = person.Fullname;
                entity.Gender = person.Gender == Gender.Male ? 0 : 1;
                entity.Status = person.Status == Status.Active ? 0 : 1;
                context.SaveChanges();
            }
        }
    }
}
