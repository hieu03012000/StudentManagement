using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessObjects;
using ServiceObject;
using StudentManagement.Areas.Auth.Data;
using StudentManagement.Areas.Infrastructure;

namespace StudentManagement.Areas.Auth.Controllers
{
    [CustomAuthenticationFilter]
    public class UpdateController : Controller
    {
        IService service { get; set; }

        static UpdateController()
        {
            Mapper.CreateMap<Person, ChangeProfileModel>();
            Mapper.CreateMap<ChangeProfileModel, Person>();
        }
        public UpdateController() : this(new Service()) { }

        public UpdateController(IService service)
        {
            this.service = service;
        }

        // GET: Update
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorize("Manager", "Teacher", "Student")]
        public ActionResult ShowProfile()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorize("Manager", "Teacher", "Student")]
        public ActionResult ChangeProfile()
        {
            ChangeProfileModel model = new ChangeProfileModel();
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Manager", "Teacher", "Student")]
        public ActionResult ChangeProfile(ChangeProfileModel changeModel)
        {
            if (ModelState.IsValid)
            {
                var s = (Person)Session["USER_DTO"];
                service.ChangeProfile(s.Username, changeModel.Fullname, changeModel.Gender, changeModel.Phone, changeModel.Address);
                var person = service.GetPersonByUsername(s.Username);
                Session.Add("USER_DTO", person);
            }
            return View(changeModel);
        }

        [HttpGet]
        [CustomAuthorize("Manager", "Teacher", "Student")]
        public ActionResult ChangePassword()
        {
            ChangePasswordModel model = new ChangePasswordModel();
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Manager", "Teacher", "Student")]
        public ActionResult ChangePassword(ChangePasswordModel changeModel)
        {
            if (ModelState.IsValid)
            {
                var s = (Person)Session["USER_DTO"];
                service.ChangePassword(s.Username, changeModel.Password);
                var person = service.GetPersonByUsername(s.Username);
                Session.Add("USER_DTO", person);
                Session.Add("UpdateSuccess", "Reset password successfully");
                return Redirect("home");
            }
            return View(changeModel);
        }
    }
}