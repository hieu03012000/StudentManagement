using AutoMapper;
using ServiceObject;
using StudentManagement.Areas.Manager.Data;
using StudentManagement.Code;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StudentManagement.Areas.Infrastructure;
using BusinessObjects;

namespace StudentManagement.Areas.Manager.Controllers
{
    [CustomAuthenticationFilter]
    public class ManagerController : Controller
    {
        IService service { get; set; }

        static ManagerController()
        {
            Mapper.CreateMap<BusinessObjects.Teacher, PersonModel>();
            Mapper.CreateMap<PersonModel, BusinessObjects.Teacher>();

            Mapper.CreateMap<BusinessObjects.Student, PersonModel>();
            Mapper.CreateMap<PersonModel, BusinessObjects.Student>(); 

            Mapper.CreateMap<Person, PersonModel>();
            Mapper.CreateMap<PersonModel, Person>();         
            
            Mapper.CreateMap<Person, PersonUpdateModel>();
            Mapper.CreateMap<PersonUpdateModel, Person>();

            Mapper.CreateMap<Class, ClassModel>();
            Mapper.CreateMap<ClassModel, Class>();

            Mapper.CreateMap<StudentClassModel, ClassStudent>();
            Mapper.CreateMap<ClassStudent, StudentClassModel>();
        }
        public ManagerController() : this(new Service()) { }

        public ManagerController(IService service)
        {
            this.service = service;
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult SearchTeacher(string searchValue = null, string sort = "Username", string order = "desc", int page = 1)
        {
            int pageSize = 10;
            var teachers = service.GetTeachersForManager(searchValue, sort + " " + order, page, pageSize);
            int totalPages = (int)Math.Ceiling(service.GetTeachersForManager(searchValue, sort + " " + order).Count / (double)pageSize);
            var model = new SearchModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            var list = Mapper.Map<List<BusinessObjects.Teacher>, List<PersonModel>>(teachers);
            list.ForEach(c => c.Role = "Teacher");
            model.People = new SortedList<PersonModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult SearchStudent(string searchValue = null, string sort = "Username", string order = "desc", int page = 1, string classID = null)
        {
            List<BusinessObjects.Student> students;
            int pageSize = 10;
            SearchModel model = new SearchModel();
            if (string.IsNullOrEmpty(classID))
            {
                students = service.GetStudentsForManager(searchValue, sort + " " + order, page, pageSize);
                int totalPages = (int)Math.Ceiling(service.GetStudentsForManager(searchValue, sort + " " + order).Count / (double)pageSize);
                model = new SearchModel { SearchValue = searchValue, Page = page, PageSize = pageSize, TotalPages = totalPages };
            }
            else
            {
                students = service.GetClassStudents(classID, sort + " " + order);
                var c = Mapper.Map<Class, ClassModel>(service.GetClass(classID));
                model.Class = c;
                model.Class.Teacher = Mapper.Map<BusinessObjects.Teacher, PersonModel>(service.GetTeacher(c.TeacherID));

            }
                
            var list = Mapper.Map<List<BusinessObjects.Student>, List<PersonModel>>(students);
            list.ForEach(c => c.Role = "Student");
            if (!string.IsNullOrEmpty(classID))
            {
                list.ForEach(c => c.ClassID = classID);
            }
            model.People = new SortedList<PersonModel>(list, sort, order);
            return View(model);
        }

        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult SearchClass(string searchValue = null, string sort = "ClassName", string order = "desc", int page = 1, string id = null, string? role = null)
        {
            int pageSize = 10;
            var classes = new List<Class>();
            int total = 0;
            var model = new SearchClassModel { SearchValue = searchValue, Page = page, PageSize = pageSize };
            if (!string.IsNullOrEmpty(role))
            {
                if (role.Equals("Teacher"))
                {
                    classes = service.GetActiveTeacherClasses(id, searchValue, page, pageSize, sort + " " + order);
                    total = service.GetActiveTeacherClasses(id, searchValue, sort + " " + order).Count;
                    var teacher = service.GetTeacher(id);
                    model.Person = Mapper.Map<BusinessObjects.Teacher, PersonModel>(teacher);
                }
                if (role.Equals("Student"))
                {
                    classes = service.GetStudentClasses(id, searchValue, page, pageSize, sort + " " + order);
                    total = service.GetStudentClasses(id, searchValue, sort + " " + order).Count;
                    var student = service.GetStudent(id);
                    model.Person = Mapper.Map<BusinessObjects.Student, PersonModel>(student);
                }
            } 
            else
            {
                classes = service.GetClassesForManager(searchValue, sort + " " + order, page, pageSize);
                total = service.GetClassesForManager(searchValue, sort + " " + order).Count;
            }
            int totalPages = (int)Math.Ceiling(total / (double)pageSize);
            model.TotalPages = totalPages;
            var list = Mapper.Map<List<Class>, List<ClassModel>>(classes);
            foreach (var item in list)
            {
                item.Teacher = Mapper.Map<BusinessObjects.Teacher, PersonModel>(service.GetTeacher(item.TeacherID));
            }
            model.Classes = new SortedList<ClassModel>(list, sort, order);
            return View(model);
        }

        //Create Account
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult CreateNewAccount()
        {
            PersonModel model = new PersonModel();
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Manager")]
        public ActionResult CreateNewAccount(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                
                service.CreateAccount(personModel.Username, personModel.Password, personModel.Fullname,
                                    personModel.Phone, personModel.Address, personModel.Gender, personModel.Role);
                Session.Add("CreateSuccess", "Create account successfully");
                return Redirect("home");
            }
            return View(personModel);
        }

        //Delete Class
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult InactiveClass(string id = null)
        {
            service.InactiveClass(id);
            return RedirectToAction("SearchClass");
        }

        //Delete Person
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult InactivePerson(string id = null, string role = null)
        {
            service.InactivePerson(id);
            string action = "";
            if (!string.IsNullOrEmpty(role))
            {
                if (role.Equals("Teacher"))
                {
                    action = "SearchTeacher";
                }
                if (role.Equals("Student"))
                {
                    action = "SearchStudent";
                }
            }
            return RedirectToAction(action);
        }

        //Edit Person
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult EditPerson(string id)
        {
            PersonUpdateModel model = new PersonUpdateModel();
            Person person = service.GetPersonByUsername(id);
            model = Mapper.Map<Person, PersonUpdateModel>(person);
            return View(model);
        }
        
        [HttpPost]
        [CustomAuthorize("Manager")]
        public ActionResult EditPerson(PersonUpdateModel changeModel)
        {
            if (ModelState.IsValid)
            {
                Person person = service.GetPersonByUsername(changeModel.Username);
                string role = person.Discriminator;
                service.EditPerson(Mapper.Map<PersonUpdateModel, Person>(changeModel));
                if (role.Equals("Teacher"))
                {
                    return Redirect("teachers");
                }
                if (role.Equals("Student"))
                {
                    return Redirect("students");
                }
            }
            return View(changeModel);
        }

        //Edit Class
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult EditClass(string id)
        {
            ClassModel model = new ClassModel();
            Class c = service.GetClass(id);
            model = Mapper.Map<Class, ClassModel>(c);
            var teachers = service.GetTeachersForManager();
            List<SelectListItem> list = new List<SelectListItem>();
            for(int i = 0; i < teachers.Count; i++)
            {
                list.Add(new SelectListItem { Value = teachers[i].Username, Text = teachers[i].Fullname });
            }
            model.Teachers = list;
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Manager")]
        public ActionResult EditClass(ClassModel changeModel)
        {
            if (ModelState.IsValid)
            {
                service.EditClass(Mapper.Map<ClassModel, Class>(changeModel));
                return Redirect("classes");
            }
            var teachers = service.GetTeachersForManager();
            List<SelectListItem> list = new List<SelectListItem>();
            for (int i = 0; i < teachers.Count; i++)
            {
                list.Add(new SelectListItem { Value = teachers[i].Username, Text = teachers[i].Fullname });
            }
            changeModel.Teachers = list;
            return View(changeModel);
        }

        //Add Class
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult AddClass()
        {
            ClassModel model = new ClassModel();
            var teachers = service.GetTeachersForManager();
            List<SelectListItem> list = new List<SelectListItem>();
            for (int i = 0; i < teachers.Count; i++)
            {
                list.Add(new SelectListItem { Value = teachers[i].Username, Text = teachers[i].Fullname });
            }
            model.Teachers = list;
            model.EndDate = DateTime.Now;
            model.StartDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        [CustomAuthorize("Manager")]
        public ActionResult AddClass(ClassModel newModel)
        {
            if (ModelState.IsValid)
            {
                service.AddClass(Mapper.Map<ClassModel, Class>(newModel));
                return Redirect("classes");
            }
            var teachers = service.GetTeachersForManager();
            List<SelectListItem> list = new List<SelectListItem>();
            for (int i = 0; i < teachers.Count; i++)
            {
                list.Add(new SelectListItem { Value = teachers[i].Username, Text = teachers[i].Fullname });
            }
            newModel.Teachers = list;
            newModel.EndDate = DateTime.Now;
            newModel.StartDate = DateTime.Now;
            return View(newModel);
        }


        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult AddStudentClass(string classID)
        {
            var model = new StudentClassModel();
            model.ClassID = classID;
            var students = service.GetClassStudents(classID, "Username asc");
            var availableStudents = service.GetAvailableClassStudents(students);
            List<SelectListItem> availableStudentsList = new List<SelectListItem>();
            for (int i = 0; i < availableStudents.Count; i++)
            {
                availableStudentsList.Add(new SelectListItem { Value = availableStudents[i].Username, Text = availableStudents[i].Fullname });
            }
            model.AvailableStudents = availableStudentsList;
            return View(model);
        }
        [HttpPost]
        [CustomAuthorize("Manager")]
        public ActionResult AddStudentClass(StudentClassModel newModel)
        {
            if (ModelState.IsValid)
            {
                service.AddStudentClass(Mapper.Map<StudentClassModel, ClassStudent>(newModel));
            }
            var students = service.GetClassStudents(newModel.ClassID, "Username asc");
            var availableStudents = service.GetAvailableClassStudents(students);
            List<SelectListItem> availableStudentsList = new List<SelectListItem>();
            for (int i = 0; i < availableStudents.Count; i++)
            {
                availableStudentsList.Add(new SelectListItem { Value = availableStudents[i].Username, Text = availableStudents[i].Fullname });
            }
            newModel.AvailableStudents = availableStudentsList;
            return RedirectToAction("SearchStudent", new { classID = newModel.ClassID });
        }
        [HttpGet]
        [CustomAuthorize("Manager")]
        public ActionResult RemoveStudentClass(string studentID, string classID)
        {
            var model = new StudentClassModel();
            model.ClassID = classID;
            model.StudentID = studentID;
            service.RemoveStudentClass(Mapper.Map<StudentClassModel, ClassStudent>(model));
            return RedirectToAction("SearchStudent", new { classID = classID });
        }
    }
}