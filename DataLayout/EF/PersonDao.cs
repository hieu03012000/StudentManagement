using AutoMapper;
using BusinessObjects;
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
    }
}
