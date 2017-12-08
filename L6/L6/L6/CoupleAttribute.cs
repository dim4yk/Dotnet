using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    class CoupleAttribute : Attribute
    {
        public string Pair { get; set; }
        public double Probability { get; set; }
        public string ChildType { get; set; }

        public CoupleAttribute(string pair, double probability, string childType)
        {
            Pair = pair;
            Probability = probability;
            ChildType = childType;
        }
    }
}
