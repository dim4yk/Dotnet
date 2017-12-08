using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FathersName { get; set; }

        public virtual IEnumerable<object> CoupleTo() {
            Type type = typeof(Human);
            object[] attributs = type.GetCustomAttributes(false);
            System.Collections.IEnumerator enumCouple = attributs.GetEnumerator();
            while (enumCouple.MoveNext())
            {
                yield return enumCouple.Current;
            }
        }

        public override string ToString()
        {
            return "Name: " + Name + " Surname: " + Surname + " Fathersname: " + FathersName;
        }
    }
}
