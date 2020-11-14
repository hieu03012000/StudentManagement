using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Teacher.Data
{
    public class SearchStudentModel
    {
        public string SearchValue { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public SortedList<PersonModel> People { get; set; }
        public ClassModel Class { get; set; }
    }
}