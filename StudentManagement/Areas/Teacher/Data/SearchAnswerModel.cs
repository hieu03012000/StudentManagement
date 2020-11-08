using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Teacher.Data
{
    public class SearchAnswerModel
    {
        public TestModel Test { get; set; }
        public SortedList<AnswerModel> Answers { get; set; }
    }
}