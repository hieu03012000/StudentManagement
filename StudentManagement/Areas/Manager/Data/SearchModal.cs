using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Manager.Data
{
    public class SearchModal
    {
        public string SearchValue { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public SortedList<TeacherModal> Teachers { get; set; }
    }
}