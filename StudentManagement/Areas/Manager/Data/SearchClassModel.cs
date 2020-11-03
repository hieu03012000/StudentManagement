using BusinessObjects;
using StudentManagement.Code;

namespace StudentManagement.Areas.Manager.Data
{
    public class SearchClassModel
    {
        public string SearchValue { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public PersonModel Person { get; set; }
        public SortedList<ClassModel> Classes { get; set; }
    }
}