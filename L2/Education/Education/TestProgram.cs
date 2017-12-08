using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class TestProgram
    {

        public static void Main()
        {

            Person p1 = new Person("Simon", "Willson", new DateTime(1991, 3, 2));
            Person p2 = new Person("Simon", "Willson", new DateTime(1991, 3, 2));

            Console.WriteLine("Reference Equals: " + ReferenceEquals(p1,p2));

            Console.WriteLine("Hash Code p1: " + p1.GetHashCode());
            Console.WriteLine("Hash Code p2: " + p2.GetHashCode()+"\n\n");


            Exam[] listOfExams = new Exam[] {
                new Exam("Math",5,new DateTime(2017,6,3)),
                new Exam("Computer science", 4, new DateTime(2017, 6, 9)),
                new Exam("Economy",3,new DateTime(2017,6,3))};

            Test[] listOfTests = new Test[] {
                new Test("Math", false),
                new Test("English", true),
                new Test("Biology", true),
                new Test("Economy", true)};

            Student stud1 = new Student(p1, Education.Master, 222);
            stud1.AddExams(listOfExams);
            stud1.AddTests(listOfTests);

            Console.WriteLine(stud1.ToString());

            Console.WriteLine("Test of Person data \n");

            Console.WriteLine("Name: "+ stud1.Name + "\n" +
                              "Surname:" + stud1.Surname + "\n" +
                              "Birthday: " + stud1.Birthday + "\n");



            Console.WriteLine("Deep Copy test.");

            Student copyStud1 = new Student();
               copyStud1 = (Student) stud1.DeepCopy();

            stud1.Name = "Jack";

            Console.WriteLine("stud1.Name = " + stud1.Name);
            Console.WriteLine("copyStud1.Name = " + copyStud1.Name);


            Console.WriteLine("\nTry/catch test. \n");

            try
            {
                Student st = new Student(new Person("Stue", "Richard", new DateTime(1985, 02, 15)), Education.Master, 150);
                st.Group = 10;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine("Value must be in range (100; 699)");
            }



            Console.WriteLine("\n\nIterator: Info about exams whiches marks > 3 \n");
            foreach (Exam e in stud1.MarkBiggerThen(3)) {
                Console.WriteLine(e.ToString());
            }

            //Additional tasks

            Console.WriteLine("\n\nIterator: Passed Tests and Exams \n");
            foreach (object elem in stud1.PassedTestsAndExams())
            {
                Console.WriteLine(elem.ToString());
            }


            Console.WriteLine("\n\nIterator: Passed Test\n");
            foreach (Test t in stud1.PassedTests())
            {
                Console.WriteLine(t.ToString());
            }

            Console.WriteLine("\n\nIterator: Tests and Exams intersection\n");
            foreach (object elem in stud1.Intersection())
            {
                Console.WriteLine(elem.ToString());
            }

            Console.ReadKey();
        }
    }
}
