using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Views.Shared
{
    public interface ISortable : IEnumerable
    {
        string Sort { get; }
        string Order { get; }
    }

    // generic form of ISortable interface.

    public interface ISortable<T> : ISortable, IEnumerable<T>
    {
        // No members..
    }
}
