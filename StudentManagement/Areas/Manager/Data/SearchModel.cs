using StudentManagement.Code;

namespace StudentManagement.Areas.Manager.Data
{
    public class SearchModel
    {
        public string SearchValue { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public SortedList<PersonModel> People { get; set; }
    }
}