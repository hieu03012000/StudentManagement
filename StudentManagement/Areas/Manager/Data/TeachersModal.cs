using StudentManagement.Code.Sorting;

namespace StudentManagement.Areas.Manager.Data
{
    public class TeachersModal
    {
        public string Message { get; set; }

        // sortable list of members

        public SortedList<TeacherModal> Teachers { get; set; }
    }
}