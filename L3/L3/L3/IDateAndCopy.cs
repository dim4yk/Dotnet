using System;
using System.Collections.Generic;
using System.Text;

namespace L3
{
    interface IDateAndCopy
    {
        DateTime Date { get; set; }

        object DeepCopy();
    }
}

