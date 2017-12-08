using System;
using System.Collections.Generic;
using System.Text;

namespace L5
{
    interface IDateAndCopy
    {
        DateTime Date { get; set; }

        object DeepCopy();
    }
}

