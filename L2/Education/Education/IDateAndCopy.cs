using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    interface IDateAndCopy
    {
        DateTime Date { get; set; }

        object DeepCopy();
    }
}
