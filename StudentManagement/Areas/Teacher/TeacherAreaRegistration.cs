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
            context.MapRoute("", "editClasst", new { area = "Teacher", controller = "Teacher", action = "EditClass" });
            context.MapRoute("", "addClasst", new { area = "Teacher", controller = "Teacher", action = "AddClass" });

            context.MapRoute("", "studentst/{id}", new { area = "Teacher", controller = "Teacher", action = "SearchStudent" });
            context.MapRoute("", "studentst", new { area = "Teacher", controller = "Teacher", action = "SearchStudent" });
            context.MapRoute("", "showStudentDetail", new { area = "Teacher", controller = "Teacher", action = "ShowStudentDetail" });

            context.MapRoute("", "tests/{id}", new { area = "Teacher", controller = "Teacher", action = "SearchTest" });
            context.MapRoute("", "tests", new { area = "Teacher", controller = "Teacher", action = "SearchTest" });
            context.MapRoute("", "inactiveTest/{id}", new { area = "Teacher", controller = "Teacher", action = "InactiveTest" });
            context.MapRoute("", "editTest", new { area = "Teacher", controller = "Teacher", action = "EditTest" });
            context.MapRoute("", "addTest", new { area = "Teacher", controller = "Teacher", action = "AddTest" });

            context.MapRoute("", "answers/{id}", new { area = "Teacher", controller = "Teacher", action = "SearchAnswer" });
            context.MapRoute("", "answers", new { area = "Teacher", controller = "Teacher", action = "SearchAnswer" });
        }
    }
}