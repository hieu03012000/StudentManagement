using System.Web.Mvc;

namespace StudentManagement.Areas.Manager
{
    public class ManagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("", "teachers/{id}", new { area = "Manager", controller = "Manager", action = "Teacher" });
            context.MapRoute("", "teachers", new { area = "Manager", controller = "Manager", action = "Teachers" });
        }
    }
}