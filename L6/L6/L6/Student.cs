using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    [Couple("Girl", 0.7, "Girl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.5, "Girl")]
    class Student : Human
    {
        public Student()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }

        public Student(string n, string sn, string fn)
        {
            Name = n;
            Surname = sn;
            FathersName = fn;
        }

        public override IEnumerable<object> CoupleTo()
        {
            Type type = typeof(Student);
            object[] attributs = type.GetCustomAttributes(false);
            System.Collections.IEnumerator enumCouple = attributs.GetEnumerator();
            while (enumCouple.MoveNext())
            {
                yield return enumCouple.Current;
            }
        }
    }
}
