using System.Web.Mvc;

namespace StudentManagement.Areas.Teacher
{
    public class TeacherAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Teacher";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("", "classest/{id}", new { area = "Teacher", controller = "Teacher", action = "SearchClass" });
            context.MapRoute("", "classest", new { area = "Teacher", controller = "Teacher", action = "SearchClass" });
            context.MapRoute("", "inactiveClasst/{id}", new { area = "Teacher", controller = "Teacher", action = "InactiveClass" });
            context.MapRoute("", "students/{id}", new { area = "Teacher", controller = "Teacher", action = "SearchStudent" });
            context.MapRoute("", "students", new { area = "Teacher", controller = "Teacher", action = "SearchStudent" });
        }
    }
}