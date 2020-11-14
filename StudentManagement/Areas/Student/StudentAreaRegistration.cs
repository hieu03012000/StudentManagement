using System.Web.Mvc;

namespace StudentManagement.Areas.Student
{
    public class StudentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Student";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("", "classess/{id}", new { area = "Student", controller = "Student", action = "SearchClass" });
            context.MapRoute("", "classess", new { area = "Student", controller = "Student", action = "SearchClass" });

            context.MapRoute("", "testss/{id}", new { area = "Student", controller = "Student", action = "SearchTest" });
            context.MapRoute("", "testss", new { area = "Student", controller = "Student", action = "SearchTest" });

            context.MapRoute("", "answer", new { area = "Student", controller = "Student", action = "ShowAnswer" });

            context.MapRoute("", "addAnswer", new { area = "Student", controller = "Student", action = "AddAnswer" });
        }
    }
}