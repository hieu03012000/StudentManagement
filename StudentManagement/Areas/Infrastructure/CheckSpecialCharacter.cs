using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class CheckSpecialCharacter : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string specialCharacters = "~`!@#$%^&*(){}[]:;/?><\\";
            for(int i = 0; i <specialCharacters.Length; i++)
            {   
                if(value == null)
                {
                    return true;
                }
                if (value.ToString().Contains(specialCharacters[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}