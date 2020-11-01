using AutoMapper;
using ServiceObject;
using StudentManagement.Areas.Auth.Controllers;
using StudentManagement.Areas.Manager.Data;
using StudentManagement.Code.Sorting;
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
            Mapper.CreateMap<BusinessObjects.Teacher, TeacherModal>();
            Mapper.CreateMap<TeacherModal, BusinessObjects.Teacher>();
        }
        public ManagerController() : this(new Service()) { }

        public ManagerController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult Teachers(string sort = "Username", string order = "desc", string message = null)
        {
            var modal = new TeachersModal { Message = message };
            var teachers = service.GetTeachers(sort + " " + order);
            var teacherModels = Mapper.Map<List<BusinessObjects.Teacher>, List<TeacherModal>>(teachers);
            modal.Teachers = new SortedList<TeacherModal>(teacherModels, sort, order);
            return View(modal);
        }
    }
}