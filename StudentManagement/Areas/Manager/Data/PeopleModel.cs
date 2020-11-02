using StudentManagement.Code;

namespace StudentManagement.Areas.Manager.Data
{
    public class PeopleModel
    {
        public string Message { get; set; }

        // sortable list of members

        public SortedList<PersonModel> People { get; set; }
    }
}