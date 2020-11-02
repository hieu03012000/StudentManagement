using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject
{
    public interface IClassDao
    {
        Class GetClass(string Username);

        List<Class> GetClasses(string searchValue, int page, int pageSize, string sortExpression = "ClassName ASC");
        List<Class> GetClasses(string searchValue, string sortExpression = "ClassName ASC");
    }
}
