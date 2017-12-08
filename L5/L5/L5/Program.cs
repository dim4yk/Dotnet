using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace L5
{
    class Program
    {
        static void Main()
        {
            Person p1 = new Person("Simon", "Willson", new DateTime(1991, 3, 2));

            Exam[] listOfExams = new Exam[] {
                new Exam("Math",5,new DateTime(2017,6,3)),
                new Exam("Computer science", 4, new DateTime(2017, 6, 9)),
                new Exam("Economy",3,new DateTime(2017,6,4))};

            Test[] listOfTests = new Test[] {
                new Test("Math", false),
                new Test("English", true)};

            Student stud1 = new Student(p1, Education.Master, 222);
            stud1.AddExams(listOfExams);
            stud1.AddTests(listOfTests);

            Student copy = stud1.DeepCopy<Student>();

            Console.WriteLine("OBJECT: \n" + stud1.ToShortString() + "\n");
            Console.WriteLine("COPY: \n" + copy.ToShortString() + "\n");

            string filename = @"D:\STUDY\C4\NET\L5\L5\f.xml";

            stud1.Save(filename);
            Console.WriteLine("OBJECT WHICH HAS BEEN WRITTEN TO THE FILE \n");
            Console.WriteLine(stud1.ToString());
            

            if (File.Exists(filename))
            {
                stud1.Load(filename);
            }
            else {
                Console.WriteLine("File doesn't exist. It creates automatically.");
                File.Create(filename);
            }

            stud1.AddFromConsole();
            stud1.Save(filename);
            Console.WriteLine("OBJECT AFTER ADDING FROM CONSOLE");
            Console.WriteLine(stud1.ToString());


            Student.Load(filename, stud1);
            stud1.AddFromConsole();
            Student.Save(filename, stud1);

            Console.WriteLine("OBJECT AFTER PROCESSING STATIC METHODS");
            Console.WriteLine(stud1.ToString());

            Console.ReadKey();
        }
    }
}
