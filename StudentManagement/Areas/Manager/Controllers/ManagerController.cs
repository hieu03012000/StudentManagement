using AutoMapper;
using ServiceObject;
using StudentManagement.Areas.Manager.Data;
using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentManagement.Areas.Manager.Controllers
{
    public class ManagerController : Controller
    {
        IService service { get; set; }

        static ManagerController()
        {
            Mapper.CreateMap<BusinessObjects.Teacher, TeacherModal>();
            Mapper.CreateMap<TeacherModal, BusinessObjects.Teacher>();
        }
        public ManagerController() : this(new Service()) { }

        public ManagerController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult SearchTeacher(string searchValue = null, string sort = "Username", string order = "desc", int page = 1)
        {
            int pageSize = 1;
            var teachers = service.GetTeachers(searchValue, sort + " " + order, page, pageSize);
            int totalPages = (int)Math.Ceiling(service.GetTeachers(searchValue, sort + " " + order).Count / (double)pageSize);
            var model = new SearchModal { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            var list = Mapper.Map<List<BusinessObjects.Teacher>, List<TeacherModal>>(teachers);
            model.Teachers = new SortedList<TeacherModal>(list, sort, order);
            return View(model);
        }
    }
}