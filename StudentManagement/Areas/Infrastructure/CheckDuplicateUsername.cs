using ServiceObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class CheckDuplicateUsername : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value == null)
            {
                return true;
            }
            Service s = new Service();
            if (s.GetPersonByUsername(value.ToString()) != null)
            {
                return false;
            }
            return true;
        }
    }
}