using BusinessObjects;
using System.Web.Mvc;

namespace StudentManagement.Areas.Auth
{
    public class AuthAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Auth";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //Login-logout
            context.MapRoute("", "", new { area = "Auth", controller = "Auth", action = "Index" });
            context.MapRoute("", "login", new { area = "Auth", controller = "Auth", action = "Index" });
            context.MapRoute("", "logout", new { area = "Auth", controller = "Auth", action = "Logout" });


        }
    }
}