using AutoMapper;
using ServiceObject;
using StudentManagement.Areas.Auth.Controllers;
using StudentManagement.Areas.Manager.Data;
using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StudentManagement.Areas.Infrastructure;


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
            int pageSize = 1;
            var teachers = service.GetTeachers(searchValue, sort + " " + order, page, pageSize);
            int totalPages = (int)Math.Ceiling(service.GetTeachers(searchValue, sort + " " + order).Count / (double)pageSize);
            var model = new SearchModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            var list = Mapper.Map<List<BusinessObjects.Teacher>, List<PersonModel>>(teachers);
            model.People = new SortedList<PersonModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult SearchStudent(string searchValue = null, string sort = "Username", string order = "desc", int page = 1)
        {
            int pageSize = 1;
            var students = service.GetStudents(searchValue, sort + " " + order, page, pageSize);
            int totalPages = (int)Math.Ceiling(service.GetTeachers(searchValue, sort + " " + order).Count / (double)pageSize);
            var model = new SearchModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            var list = Mapper.Map<List<BusinessObjects.Student>, List<PersonModel>>(students);
            model.People = new SortedList<PersonModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult SearchClass(string searchValue = null, string sort = "ClassName", string order = "desc", int page = 1)
        {
            int pageSize = 1;
            var classes = service.GetClasses(searchValue, sort + " " + order, page, pageSize);
            int totalPages = (int)Math.Ceiling(service.GetClasses(searchValue, sort + " " + order).Count / (double)pageSize);
            var model = new SearchClassModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            var list = Mapper.Map<List<BusinessObjects.Class>, List<ClassModel>>(classes);
            model.Classes = new SortedList<ClassModel>(list, sort, order);
            return View(model);
        }
    }
}