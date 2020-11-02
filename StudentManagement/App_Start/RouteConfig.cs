using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentManagement
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("", "home", new { area = "", controller = "Home", action = "Index" });
            routes.MapRoute("", "showProfile", new { area = "", controller = "Home", action = "ShowProfile" });
        }
    }
}
