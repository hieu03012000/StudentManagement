using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentManagement.Areas.Auth.Controllers
{
    public class BaseController : Controller
    {
        Context context;

        public BaseController()
        {
            context = new Context();
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Context context = new Context();
            var session = (Person)Session["USER_DTO"];
            //not login
            if(session == null)
            {
                filterContext.Result = new RedirectResult("login");
            }
            else
            {
                String originalPath = new Uri(HttpContext.Current.Request.Url.AbsoluteUri).OriginalString;
                String parentDirectory = originalPath.Substring(0, originalPath.LastIndexOf("/"));
                //ckeck role Maneger
                if (session.Discriminator.Equals("Manager"))
                {
                    //if()
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}