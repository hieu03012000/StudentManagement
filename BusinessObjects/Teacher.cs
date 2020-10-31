using System.Collections.Generic;

namespace BusinessObjects
{
    public class Teacher : Person
    {
        public List<Test> Tests { get; set; }
        public List<Class> Classes { get; set; }
    }
}