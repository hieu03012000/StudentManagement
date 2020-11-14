using BusinessObjects.Enums;
using System;

namespace StudentManagement.Areas.Teacher.Data
{
    public class AnswerModel
    {
        public Guid AnswerID { get; set; }
        public string AnswerTitle { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public DateTime CreateDate { get; set; }
        public float Mark { get; set; }
        public Status Status { get; set; }
        public string StudentID { get; set; }
        public Guid TestID { get; set; }
        public PersonModel Student { get; set; }
        public TestModel Test { get; set; }
    }
}