using AutoMapper;
using BusinessObjects;
using ServiceObject;
using StudentManagement.Areas.Infrastructure;
using StudentManagement.Areas.Student.Data;
using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace StudentManagement.Areas.Student.Controllers
{
    [CustomAuthenticationFilter]
    public class StudentController : Controller
    {
        IService service { get; set; }
        static StudentController()
        {
            Mapper.CreateMap<BusinessObjects.Teacher, PersonModel>();
            Mapper.CreateMap<PersonModel, BusinessObjects.Teacher>();

            Mapper.CreateMap<BusinessObjects.Student, PersonModel>();
            Mapper.CreateMap<PersonModel, BusinessObjects.Student>();

            Mapper.CreateMap<Class, ClassModel>();
            Mapper.CreateMap<ClassModel, Class>();

            Mapper.CreateMap<Test, TestModel>();
            Mapper.CreateMap<TestModel, Test>();

            Mapper.CreateMap<Answer, AnswerModel>();
            Mapper.CreateMap<AnswerModel, Answer>();
        }
        public StudentController() : this(new Service()) { }

        public StudentController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [CustomAuthorize("Student")]
        public ActionResult SearchClass(string searchValue = null, string sort = "ClassName", string order = "desc", int page = 1)
        {
            int pageSize = 10;
            var s = (Person)Session["USER_DTO"];

            var classes = service.GetStudentClasses(s.Username, searchValue, page, pageSize, sort + " " + order);
            var total = service.GetStudentClasses(s.Username, searchValue, sort + " " + order).Count;

            int totalPages = (int)Math.Ceiling(total / (double)pageSize);
            var model = new SearchClassModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            var list = Mapper.Map<List<Class>, List<ClassModel>>(classes);
            foreach (var item in list)
            {
                item.Teacher = Mapper.Map<BusinessObjects.Teacher, PersonModel>(service.GetTeacher(item.TeacherID));
            }

            model.Classes = new SortedList<ClassModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Student")]
        public ActionResult SearchTest(string classID = null)
        {
            var tests = service.GetClassTestsForStudent(classID);
            var model = new SearchTestModel();
            var c = service.GetClass(classID);
            model.Class = Mapper.Map<Class, ClassModel>(c);
            var teacher = service.GetTeacher(c.TeacherID);
            model.Teacher = Mapper.Map<BusinessObjects.Teacher, PersonModel>(teacher);
            var list = Mapper.Map<List<Test>, List<TestModel>>(tests);
            model.Tests = new SortedList<TestModel>(list, "TestTitle", "asc");
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Student")]
        public ActionResult ShowAnswer(string testID = null)
        {
            var s = (Person)Session["USER_DTO"];
            var answer = service.GetAnswerForStudent(testID, s.Username);
            var model = new ShowAnswerModel();
            model.Answer = Mapper.Map<Answer, AnswerModel>(answer);
            var test = service.GetTest(testID);
            model.Test = Mapper.Map<Test, TestModel>(test);
            model.Test.Teacher = Mapper.Map<BusinessObjects.Teacher, PersonModel>(service.GetTeacher(test.TeacherID));
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Student")]
        public ActionResult AddAnswer(Guid testID)
        {
            AnswerModel model = new AnswerModel();
            model.TestID = testID;
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Student")]
        public ActionResult AddAnswer(AnswerModel answerModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (answerModel.FileName != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Assets/file/"), Path.GetFileName(answerModel.FileName.FileName));
                        answerModel.FileName.SaveAs(path);
                        answerModel.File = Path.GetFileName(answerModel.FileName.FileName);
                    }
                }
                catch
                {
                    return View(answerModel);
                }
                service.AddAnswer(Mapper.Map<AnswerModel, Answer>(answerModel));
                return Redirect("answer?testID=" + answerModel.TestID);
            }
            return View(answerModel);
        }
    }
}