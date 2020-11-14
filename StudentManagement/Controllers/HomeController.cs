using AutoMapper;
using StudentManagement.Areas.Auth.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagement.Areas.Infrastructure;

namespace StudentManagement.Controllers
{
    [CustomAuthenticationFilter]
    public class HomeController : Controller
    {
        [CustomAuthorize("Manager", "Teacher", "Student")]
        public ActionResult Index()
        {
            return View();
        }
    }
}