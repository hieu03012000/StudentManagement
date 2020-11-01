using AutoMapper;
using BusinessObjects;
using DataObject.EF;
using ServiceObject;
using StudentManagement.Areas.Auth.Data;
using StudentManagement.Areas.Manager.Controllers;
using StudentManagement.Code.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Areas.Auth.Controllers
{
    public class AuthController : Controller
    {
        IService service { get; set; }

        static AuthController()
        {
            Mapper.CreateMap<BusinessObjects.Person, LoginModel>();
            Mapper.CreateMap<LoginModel, BusinessObjects.Person>();
        }
        public AuthController() : this(new Service()) { }

        public AuthController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        {
            LoginModel model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            var result = service.Login(model.Username, model.Password);
            if (ModelState.IsValid)
            {
                if (result)
                {
                    var person = service.GetPersonByUsername(model.Username);
                    Session.Add("USER_DTO", person);
                    return Redirect("home");
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Logout(LoginModel model)
        {
            Session.Remove("USER_DTO");
            return Redirect("login");
        }

    }
}