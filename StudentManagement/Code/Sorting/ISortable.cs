
﻿using System.Collections;
using System.Collections.Generic;

namespace StudentManagement.Code
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
