using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentManagement.Areas.Auth.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        
            var session = (Person)Session["USER_DTO"];
            if(session == null)
            {
                filterContext.Result = new RedirectResult("login");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}