using BusinessObjects.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessObjects
{
    public class Answer
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
        public Student Student { get; set; }
        public Test Test { get; set; }

    }
}