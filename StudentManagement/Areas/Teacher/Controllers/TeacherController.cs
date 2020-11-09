 using AutoMapper;
using BusinessObjects;
using Microsoft.Ajax.Utilities;
using ServiceObject;
using StudentManagement.Areas.Infrastructure;
using StudentManagement.Areas.Teacher.Data;
using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentManagement.Areas.Teacher.Controllers
{
    [CustomAuthenticationFilter]
    public class TeacherController : Controller
    {
        IService service { get; set; }
        static TeacherController()
        {
            Mapper.CreateMap<BusinessObjects.Teacher, PersonModel>();
            Mapper.CreateMap<PersonModel, BusinessObjects.Teacher>();

            Mapper.CreateMap<BusinessObjects.Student, PersonModel>();
            Mapper.CreateMap<PersonModel, BusinessObjects.Student>();

            Mapper.CreateMap<List<BusinessObjects.Teacher>, LinkedList<PersonModel>>();
            Mapper.CreateMap<LinkedList<PersonModel>, List<BusinessObjects.Teacher>>();

            Mapper.CreateMap<Class, ClassModel>();
            Mapper.CreateMap<ClassModel, Class>();

            Mapper.CreateMap<Test, TestModel>();
            Mapper.CreateMap<TestModel, Test>();

            Mapper.CreateMap<Answer, AnswerModel>();
            Mapper.CreateMap<AnswerModel, Answer>();
        }
        public TeacherController() : this(new Service()) { }

        public TeacherController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult SearchClass(string searchValue = null, string sort = "ClassName", string order = "desc", int page = 1)
        {
            int pageSize = 10;
            var s = (Person)Session["USER_DTO"];

            var classes = service.GetTeacherClasses(s.Username, searchValue, page, pageSize, sort + " " + order);
            var total = service.GetTeacherClasses(s.Username, searchValue, sort + " " + order).Count;

            int totalPages = (int)Math.Ceiling(total / (double)pageSize);
            var model = new SearchClassModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            var list = Mapper.Map<List<Class>, List<ClassModel>>(classes);
            foreach (var c in list)
            {
                c.TotalStudents = service.GetClassStudents(c.ClassID.ToString(), "Username " + order).Count;
            }
            model.Classes = new SortedList<ClassModel>(list, sort, order);
            return View(model);
        }

        //Delete Class
        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult InactiveClass(string id = null)
        {
            service.InactiveClass(id);
            return RedirectToAction("SearchClass");
        }

        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult SearchStudent(string sort = "Username", string order = "desc", string classID = null)
        {
            List<BusinessObjects.Student> students;
            SearchStudentModel model = new SearchStudentModel();
            
            students = service.GetClassStudents(classID, sort + " " + order);
            var c = Mapper.Map < Class, ClassModel> (service.GetClass(classID));
            c.Teacher = Mapper.Map<BusinessObjects.Teacher, PersonModel>(service.GetTeacher(c.TeacherID));
            model.Class = c;

            var list = Mapper.Map<List<BusinessObjects.Student>, List<PersonModel>>(students);
            model.People = new SortedList<PersonModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult SearchTest(string searchValue = null, string sort = "TestTitle", string order = "desc", int page = 1, string? classID = null)
        {
            int pageSize = 10;
            var s = (Person)Session["USER_DTO"];
            List<Test> tests;
            int total = 0;
            SearchTestModel model;
            if (!string.IsNullOrEmpty(classID))
            {
                tests = service.GetClassTestsForTeacher(classID, searchValue, sort + " " + order);
                model = new SearchTestModel { SearchValue = searchValue };
                var c = service.GetClass(classID);
                model.Class = Mapper.Map<Class, ClassModel>(c);
            }
            else
            {
                tests = service.GetTestsForTeacher(s.Username, searchValue, page, pageSize, sort + " " + order);
                total = service.GetTestsForTeacher(s.Username, searchValue, sort + " " + order).Count;
                int totalPages = (int)Math.Ceiling(total / (double)pageSize);
                model = new SearchTestModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            }
            var list = Mapper.Map<List<Test>, List<TestModel>>(tests);
            model.Tests = new SortedList<TestModel>(list, sort, order);
            return View(model);
        }
        //Delete Test
        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult InactiveTest(string id = null)
        {
            service.InactiveTest(id);
            return RedirectToAction("SearchTest");
        }

        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult ShowStudentDetail(string username)
        {
            var student = service.GetStudent(username);
            var model = Mapper.Map<BusinessObjects.Student, PersonModel>(student);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult SearchAnswer(string testID = null)
        {
            var answers = service.GetAnswersForTeacher(testID);
            var test = service.GetTest(testID);
            var model = new SearchAnswerModel();
            model.Test = Mapper.Map<Test, TestModel>(test);
            var teacher = Mapper.Map<BusinessObjects.Teacher, PersonModel>(service.GetTeacher(test.TeacherID));
            model.Test.Teacher = teacher;
            var c = Mapper.Map<Class, ClassModel>(service.GetClass(test.ClassID.ToString()));
            model.Test.Class = c;
            var list = Mapper.Map<List<Answer>, List<AnswerModel>>(answers);
            foreach (var a in list)
            {
                a.Student = Mapper.Map<BusinessObjects.Student, PersonModel >(service.GetStudent(a.StudentID));
            }

            model.Answers = new SortedList<AnswerModel>(list, "AnswerTitle", "desc");
            return View(model);
        }


        //Add Class
        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult AddClass()
        {
            ClassModel model = new ClassModel();
            model.EndDate = DateTime.Now;
            model.StartDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Teacher")]
        public ActionResult AddClass(ClassModel newModel)
        {
            if (ModelState.IsValid)
            {
                var s = (Person)Session["USER_DTO"];
                newModel.TeacherID = s.Username;
                service.AddClass(Mapper.Map<ClassModel, Class>(newModel));
                return Redirect("classest");
            }
            newModel.EndDate = DateTime.Now;
            newModel.StartDate = DateTime.Now;
            return View(newModel);
        }

        //Edit Class
        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult EditClass(string id)
        {
            ClassModel model = new ClassModel();
            Class c = service.GetClass(id);
            model = Mapper.Map<Class, ClassModel>(c);
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Teacher")]
        public ActionResult EditClass(ClassModel changeModel)
        {
            if (ModelState.IsValid)
            {
                var s = (Person)Session["USER_DTO"];
                changeModel.TeacherID = s.Username;
                service.EditClass(Mapper.Map<ClassModel, Class>(changeModel));
                return Redirect("classest");
            }
            return View(changeModel);
        }

        //Add Test
        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult AddTest(Guid classID)
        {
            TestModel model = new TestModel();
            model.ClassID = classID;
            model.EndDate = DateTime.Now;
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Teacher")]
        public ActionResult AddTest(TestModel newModel)
        {
            var s = (Person)Session["USER_DTO"];
            if (ModelState.IsValid)
            {
                newModel.TeacherID = s.Username;
                service.AddTest(Mapper.Map<TestModel, Test>(newModel));
                return RedirectToAction("SearchTest", new { classID = newModel.ClassID });
            }
            newModel.EndDate = DateTime.Now;
            newModel.CreateDate = DateTime.Now;
            return View(newModel);
        }

        //Edit Test
        [HttpGet]
        [CustomAuthorize("Teacher")]
        public ActionResult EditTest(string id)
        {
            TestModel model = new TestModel();
            Test t = service.GetTest(id);
            model = Mapper.Map<Test, TestModel>(t);
            model.EndDate = DateTime.Now;
            model.CreateDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Teacher")]
        public ActionResult EditTest(TestModel changeModel)
        {
            var s = (Person)Session["USER_DTO"];
            if (ModelState.IsValid)
            {
                changeModel.TeacherID = s.Username;
                service.EditTest(Mapper.Map<TestModel, Test>(changeModel));
                return Redirect("tests");
            }
            changeModel.EndDate = DateTime.Now;
            changeModel.CreateDate = DateTime.Now;
            return View(changeModel);
        }
    }
}