﻿
namespace DataObjects
{
    public interface IDaoFactory
    {
        IStudentDao StudentDao { get; }
        ITeacherDao TeacherDao { get; }
        IClassDao ClassDao { get; }
        ITestDao TestDao { get; }
        IAnswerDao AnswerDao { get; }
        IPersonDao PersonDao { get; }
    }
}
