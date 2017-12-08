using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    [Couple("Student", 0.2, "Girl")]
    [Couple("Botan", 0.5, "Book")]
    class SmartGirl : Human
    {
        public SmartGirl()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }

        public SmartGirl(string name, string surname, string fathersname)
        {
            Name = name;
            Surname = surname;
            FathersName = fathersname;
        }

        public override IEnumerable<object> CoupleTo()
        {
            Type type = typeof(SmartGirl);
            object[] attributs = type.GetCustomAttributes(false);
            System.Collections.IEnumerator enumCouple = attributs.GetEnumerator();
            while (enumCouple.MoveNext())
            {
                yield return enumCouple.Current;
            }
        }
    }
}
