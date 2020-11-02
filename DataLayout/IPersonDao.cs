using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IPersonDao
    {
        bool GetPerson(string Username, string Password);

        Person GetPersonByUsername(string Username);
    }
}
