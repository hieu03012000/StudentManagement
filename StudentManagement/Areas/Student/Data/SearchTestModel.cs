using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Student.Data
{
    public class SearchTestModel
    {
        public ClassModel Class { get; set; }
        public PersonModel Teacher { get; set; }
        public SortedList<TestModel> Tests { get; set; }
    }
}