using StudentManagement.Code;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentManagement.Areas.Manager.Data
{
    public class SearchModel
    {
        public string SearchValue { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public SortedList<PersonModel> People { get; set; }
        public ClassModel Class { get; set; }
        public StudentClassModel AddStudentToClass { get; set; }

    }
}