using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    [Couple("Student", 0.7, "Girl")]
    [Couple("Botan", 0.3, "SmartGirl")]
    class Girl : Human
    {
        public Girl()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }

        public Girl(string name, string surname, string fathersname)
        {
            Name = name;
            Surname = surname;
            FathersName = fathersname;
        }

        public override IEnumerable<object> CoupleTo()
        {
            Type type = typeof(Girl);
            object[] attributs = type.GetCustomAttributes(false);
            System.Collections.IEnumerator enumCouple = attributs.GetEnumerator();
            while (enumCouple.MoveNext())
            {
                yield return enumCouple.Current;
            }
        }
    }
}
