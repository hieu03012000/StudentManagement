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
            context.MapRoute("", "teachers/{id}", new { area = "Manager", controller = "Manager", action = "SearchTeacher" });
            context.MapRoute("", "teachers", new { area = "Manager", controller = "Manager", action = "SearchTeacher" });

            context.MapRoute("", "students/{id}", new { area = "Manager", controller = "Manager", action = "SearchStudent" });
            context.MapRoute("", "students", new { area = "Manager", controller = "Manager", action = "SearchStudent" });

            context.MapRoute("", "classes/{id}", new { area = "Manager", controller = "Manager", action = "SearchClass" });
            context.MapRoute("", "classes", new { area = "Manager", controller = "Manager", action = "SearchClass" });
            context.MapRoute("", "deleteClass/{id}", new { area = "Manager", controller = "Manager", action = "DeleteClass" });

            context.MapRoute("", "createNewAccount", new { area = "Manager", controller = "Manager", action = "CreateNewAccount" });
            context.MapRoute("", "deletePerson/{id}", new { area = "Manager", controller = "Manager", action = "DeletePerson" });
        }
    }
}