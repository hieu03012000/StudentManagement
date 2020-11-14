﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class DaoFactories
    {
        public static IDaoFactory GetFactory()
        {
            return new EF.DaoFactory();
        }
    }
}
