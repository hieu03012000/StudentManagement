using AutoMapper;
using BusinessObjects;
using ServiceObject;
using StudentManagement.Areas.Infrastructure;
using StudentManagement.Areas.Teacher.Data;
using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            Mapper.CreateMap<Class, ClassModel>();
            Mapper.CreateMap<ClassModel, Class>();
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
            var c = service.GetClass(classID);
            model.Class = Mapper.Map<Class, ClassModel>(c);

            var list = Mapper.Map<List<BusinessObjects.Student>, List<PersonModel>>(students);
            model.People = new SortedList<PersonModel>(list, sort, order);
            return View(model);
        }
    }
}