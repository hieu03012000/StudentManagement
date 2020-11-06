using StudentManagement.Code;

namespace StudentManagement.Areas.Manager.Data
{
    public class UpdateClassModel
    {
        public ClassModel Class { get; set; }

        public SortedList<PersonModel> Teachers { get; set; }
    }
}