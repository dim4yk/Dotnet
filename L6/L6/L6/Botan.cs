using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    [Couple("Girl", 0.7, "SmartGirl")]
    [Couple("PrettyGirl", 1, "PrettyGirl")]
    [Couple("SmartGirl", 0.8, "Book")]
    class Botan : Human
    {
        public Botan()
        {
            Name = "";
            Surname = "";
            FathersName = "";
        }

        public Botan(string name, string surname, string fathersname)
        {
            Name = name;
            Surname = surname;
            FathersName = fathersname;
        }

        public override IEnumerable<object> CoupleTo()
        {
            Type type = typeof(Botan);
            object[] attributs = type.GetCustomAttributes(false);
            System.Collections.IEnumerator enumCouple = attributs.GetEnumerator();
            while (enumCouple.MoveNext())
            {
                yield return enumCouple.Current;
            }
        }
    }
}
