using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Areas.Student.Data
{
    public class ShowAnswerModel
    {
        public TestModel Test { get; set; }
        public AnswerModel Answer { get; set; }

    }
}