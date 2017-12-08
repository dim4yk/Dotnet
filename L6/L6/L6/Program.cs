using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6
{
    class Program
    {
        static void Main()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                Environment.Exit(0);
            }

            StreamReader streamReader = new StreamReader("D:\\STUDY\\C4\\NET\\L6\\L6\\men.txt");
            string menline = "";
            List<string> menlist = new List<string>();
            while (menline != null)
            {
                menline = streamReader.ReadLine();
                if (menline != null)
                {
                    menlist.Add(menline);
                }
            }
            streamReader.Close();

            streamReader = new StreamReader("D:\\STUDY\\C4\\NET\\L6\\L6\\women.txt");
            string womenline = "";
            List<string> womenlist = new List<string>();
            while (womenline != null)
            {
                womenline = streamReader.ReadLine();
                if (womenline != null)
                {
                    womenlist.Add(womenline);
                }
            }
            streamReader.Close();

            List<string> WomenClasses = new List<string>();
            WomenClasses.Add("Girl");
            WomenClasses.Add("SmartGirl");
            WomenClasses.Add("PrettyGirl");


            List<string> MenClasses = new List<string>();
            MenClasses.Add("Student");
            MenClasses.Add("Botan");

            foreach (string strMan in menlist)
            {
                foreach (string strWoman in womenlist)
                {
                    string[] strmanMas = strMan.Split();
                    string[] strwomanMas = strWoman.Split();

                    Random rand = new Random();
                    int manRand = rand.Next(0, 2);

                    int womanRand = rand.Next(0, 3);


                    Type type = Type.GetType("L6." + MenClasses[manRand]);
                    var Man = Activator.CreateInstance(type);

                    System.Reflection.PropertyInfo propertyInfo;
                    type = typeof(Human);
                    propertyInfo = type.GetProperty("Name");
                    propertyInfo.SetValue(Man, strmanMas[0]);

                    propertyInfo = type.GetProperty("Surname");
                    propertyInfo.SetValue(Man, strmanMas[1]);

                    propertyInfo = type.GetProperty("FathersName");
                    propertyInfo.SetValue(Man, strmanMas[2]);



                    type = Type.GetType("L6." + WomenClasses[womanRand]);
                    var Woman = Activator.CreateInstance(type);

                    type = typeof(Human);
                    propertyInfo = type.GetProperty("Name");
                    propertyInfo.SetValue(Woman, strwomanMas[0]);

                    propertyInfo = type.GetProperty("Surname");
                    propertyInfo.SetValue(Woman, strwomanMas[1]);

                    propertyInfo = type.GetProperty("FathersName");
                    propertyInfo.SetValue(Woman, strwomanMas[2]) ;

                    Attraction attraction = Attraction.Couple((Human)Woman, (Human)Man);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Woman: " + Woman.ToString());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Man: " + Man.ToString());
                    Console.ForegroundColor = ConsoleColor.Blue
                        
                        ;
                    Console.WriteLine(attraction.ToString()+"\n");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Press Eny Button to continue (or Q|F10 to exit)\n");
                    ConsoleKey ckey = Console.ReadKey(true).Key;
                    if ((ckey == ConsoleKey.Q)||(ckey == ConsoleKey.F10))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.ResetColor();
                        continue;
                    }

                }
            }
        }
    }
}
