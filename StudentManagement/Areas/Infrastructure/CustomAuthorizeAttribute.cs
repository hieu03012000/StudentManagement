using BusinessObjects;
using DataObjects.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentManagement.Areas.Infrastructure
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (Person)httpContext.Session["USER_DTO"];
            if (user != null)
                using (var context = new StudentManagementDBContext())
                {
                    string userRole = user.Discriminator;
                    foreach (var role in allowedroles)
                    {
                        if (role == userRole) return true;
                    }
                }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("home");
        }
    }
}