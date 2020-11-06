using AutoMapper;
using ServiceObject;
using StudentManagement.Areas.Auth.Controllers;
using StudentManagement.Areas.Manager.Data;
using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StudentManagement.Areas.Infrastructure;
using BusinessObjects;
using Microsoft.Ajax.Utilities;

namespace StudentManagement.Areas.Manager.Controllers
{
    [CustomAuthenticationFilter]
    public class ManagerController : Controller
    {
        IService service { get; set; }

        static ManagerController()
        {
            Mapper.CreateMap<BusinessObjects.Teacher, PersonModel>();
            Mapper.CreateMap<PersonModel, BusinessObjects.Teacher>();

            Mapper.CreateMap<BusinessObjects.Student, PersonModel>();
            Mapper.CreateMap<PersonModel, BusinessObjects.Student>();

            Mapper.CreateMap<Person, PersonModel>();
            Mapper.CreateMap<PersonModel, Person>();

            Mapper.CreateMap<Class, ClassModel>();
            Mapper.CreateMap<ClassModel, Class>();

        }
        public ManagerController() : this(new Service()) { }

        public ManagerController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult SearchTeacher(string searchValue = null, string sort = "Username", string order = "desc", int page = 1)
        {
            int pageSize = 10;
            var teachers = service.GetTeachersForManager(searchValue, sort + " " + order, page, pageSize);
            int totalPages = (int)Math.Ceiling(service.GetTeachersForManager(searchValue, sort + " " + order).Count / (double)pageSize);
            var model = new SearchModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            var list = Mapper.Map<List<BusinessObjects.Teacher>, List<PersonModel>>(teachers);
            list.ForEach(c => c.Role = "Teacher");
            model.People = new SortedList<PersonModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult SearchStudent(string searchValue = null, string sort = "Username", string order = "desc", int page = 1, string classID = null)
        {
            List<BusinessObjects.Student> students;
            int pageSize = 10;
            SearchModel model = new SearchModel();
            if (string.IsNullOrEmpty(classID))
            {
                students = service.GetStudentsForManager(searchValue, sort + " " + order, page, pageSize);
                int totalPages = (int)Math.Ceiling(service.GetTeachersForManager(searchValue, sort + " " + order).Count / (double)pageSize);
                model = new SearchModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            }
            else
            {
                students = service.GetClassStudents(classID, sort + " " + order);
                var c = service.GetClass(classID);
                model.Class = Mapper.Map<Class, ClassModel>(c);

            }
                
            var list = Mapper.Map<List<BusinessObjects.Student>, List<PersonModel>>(students);
            list.ForEach(c => c.Role = "Student");
            model.People = new SortedList<PersonModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult SearchClass(string searchValue = null, string sort = "ClassName", string order = "desc", int page = 1, string id = null, string? role = null)
        {
            int pageSize = 10;
            var classes = new List<Class>();
            int total = 0;
            var model = new SearchClassModel { SearchValue = searchValue, Page = page, PageSize = pageSize };
            if (!string.IsNullOrEmpty(role))
            {
                if (role.Equals("Teacher"))
                {
                    classes = service.GetTeacherClassesForManager(id, searchValue, page, pageSize, sort + " " + order);
                    total = service.GetTeacherClassesForManager(id, searchValue, sort + " " + order).Count;
                    var teacher = service.GetTeacher(id);
                    model.Person = Mapper.Map<BusinessObjects.Teacher, PersonModel>(teacher);
                }
                if (role.Equals("Student"))
                {
                    classes = service.GetStudentClasses(id, searchValue, page, pageSize, sort + " " + order);
                    total = service.GetStudentClasses(id, searchValue, sort + " " + order).Count;
                    var student = service.GetStudent(id);
                    model.Person = Mapper.Map<BusinessObjects.Student, PersonModel>(student);
                }
            } 
            else
            {
                classes = service.GetClassesForManager(searchValue, sort + " " + order, page, pageSize);
                total = service.GetClassesForManager(searchValue, sort + " " + order).Count;
            }
            int totalPages = (int)Math.Ceiling(total / (double)pageSize);
            model.TotalPages = totalPages;
            var list = Mapper.Map<List<Class>, List<ClassModel>>(classes);
            model.Classes = new SortedList<ClassModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult CreateNewAccount()
        {
            PersonModel model = new PersonModel();
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Manager")]
        public ActionResult CreateNewAccount(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                
                    service.CreateAccount(personModel.Username, personModel.Password, personModel.Fullname,
                                        personModel.Phone, personModel.Address, personModel.Gender, personModel.Role);
                    Session.Add("CreateSuccess", "Create account successfully");
            }
            return View(personModel);
        }

        //Delete Class
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult InactiveClass(string id = null)
        {
            service.InactiveClass(id);
            return RedirectToAction("SearchClass");
        }

        //Edit Class
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult EditClass(string id = null)
        {
            service.InactiveClass(id);
            return RedirectToAction("SearchClass");
        }

        //Delete Person
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult InactivePerson(string id = null, string role = null)
        {
            service.InactivePerson(id);
            string action = "";
            if (!string.IsNullOrEmpty(role))
            {
                if (role.Equals("Teacher"))
                {
                    action = "SearchTeacher";
                }
                if (role.Equals("Student"))
                {
                    action = "SearchStudent";
                }
            }
            return RedirectToAction(action);
        }

        //Edit Person
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult EditPerson(string id = null, string role = null)
        {
            service.InactivePerson(id);
            string action = "";
            if (!string.IsNullOrEmpty(role))
            {
                if (role.Equals("Teacher"))
                {
                    action = "SearchTeacher";
                }
                if (role.Equals("Student"))
                {
                    action = "SearchStudent";
                }
            }
            return RedirectToAction(action);
        }


    }
}