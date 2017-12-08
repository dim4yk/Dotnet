using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    class Attraction
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Like { get; set; }

        public Attraction()
        {
            Name = "Empty";
            Type = "Empty";
            Like = false;
        }

        public static Attraction Couple(Human human1, Human human2)
        {
            Attraction attraction = new Attraction();
            string child = "";

            bool human1like = false;
            bool human2like = false;

            foreach (CoupleAttribute h1 in human1.CoupleTo())
            {
                foreach (CoupleAttribute h2 in human2.CoupleTo())
                {
                    if ((h1.Pair == human2.GetType().Name) && (h2.Pair == human1.GetType().Name))
                    {
                        if (h1.Probability >= 0.5)
                        {
                            human1like = true;
                            child = h1.ChildType;
                        }

                        if (h2.Probability >= 0.5)
                        {
                            human2like = true;
                        }
                    }
                }

            }

            SortedSet<string> bookSet = new SortedSet<string>();
            bookSet.Add("Botan");
            bookSet.Add("SmartGirl");

            if (bookSet.Contains(human1.GetType().Name) && (bookSet.Contains(human2.GetType().Name)))
            {
                attraction.Name = "Book";
                attraction.Type = "Book";
                attraction.Like = false;

                return attraction;
            }
            else
            {
                if ((human1like == true) && (human2like == true))
                {
                    System.Reflection.PropertyInfo propertyInfo;
                    Type type = typeof(Human);
                    propertyInfo = type.GetProperty("Name");
                    string name = (string)propertyInfo.GetValue(human2);

                    string ChildType = child;
                    type = System.Type.GetType("L6." + ChildType);
                    var obj = Activator.CreateInstance(type);


                    string GirlName = (string)propertyInfo.GetValue(human1);
                    propertyInfo = type.GetProperty("Name");
                    propertyInfo.SetValue(obj, GirlName);

                    SortedSet<string> male = new SortedSet<string>();
                    male.Add("Student");
                    male.Add("Botan");

                    string fathersName = "";
                    if (male.Contains(ChildType))
                    {
                        if (name[name.Length - 1] == 'o')
                        {
                            fathersName = name + "вич";
                        }
                        else
                        {
                            fathersName = name + "ович";
                        }
                    }


                    propertyInfo = type.GetProperty("Surname");
                    string fathersSurname = (string)propertyInfo.GetValue(human2);


                    if (!male.Contains(ChildType))
                    {
                        if (fathersSurname.Contains("ий"))
                        {
                            fathersSurname = fathersSurname.Remove(fathersSurname.Length - 2);
                            fathersSurname = fathersSurname + "a";
                        }
                    }

                    propertyInfo = type.GetProperty("Surname");
                    propertyInfo.SetValue(obj, fathersSurname);

                    propertyInfo = type.GetProperty("FathersName");
                    propertyInfo.SetValue(obj, fathersName);

                    attraction.Name = GirlName;
                    attraction.Type = ChildType;
                    attraction.Like = true;
                    return attraction;
                }
                else
                {
                    child = "";
                    attraction.Name = "Empty";
                    attraction.Type = "Empty";
                    attraction.Like = false;
                    return attraction;
                }
            }
        }

        public override string ToString()
        {
            return "ChildName: " + Name + " Type: " + Type + " Like:" + Like;
        }
    }

}
