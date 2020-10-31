using System.Collections.Generic;

namespace BusinessObjects
{
    public class Student : Person
    {
        public List<Answer> Answers { get; set; }
        public List<Class> Classes { get; set; }

    }
}