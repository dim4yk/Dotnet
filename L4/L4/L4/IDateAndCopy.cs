using System;
using System.Collections.Generic;
using System.Text;

namespace L4
{
    interface IDateAndCopy
    {
        DateTime Date { get; set; }

        object DeepCopy();
    }
}

