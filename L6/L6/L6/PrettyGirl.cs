using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    [Couple("Student", 0.4, "PrettyGirl")]
    [Couple("Botan", 0.1, "PrettyGirl")]
    class PrettyGirl : Human
    {
        public PrettyGirl()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }

        public PrettyGirl(string name, string surname, string fathersname)
        {
            Name = name;
            Surname = surname;
            FathersName = fathersname;
        }

        public override IEnumerable<object> CoupleTo()
        {
            Type type = typeof(PrettyGirl);
            object[] attributs = type.GetCustomAttributes(false);
            System.Collections.IEnumerator enumCouple = attributs.GetEnumerator();
            while (enumCouple.MoveNext())
            {
                yield return enumCouple.Current;
            }
        }
    }
}
