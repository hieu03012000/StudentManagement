using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class ClassStudent
    {
        public Guid ID { get; set; }
        public Guid ClassID { get; set; }
        public string StudentID { get; set; }
        public Student Student { get; set; }
        public Class Class { get; set; }

    }
}
