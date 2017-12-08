using System;
using System.Collections.Generic;
using System.Text;

namespace L5
{
    class StudentComparer : IComparer<Student>
    {
        public int Compare(Student s1, Student s2)
        {
            return s1.Average.CompareTo(s2.Average);
        }
    }
}
