using System;

namespace L3
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection stCollection = new StudentCollection();
            stCollection.AddDefaults(4);

            Console.WriteLine(stCollection.ToString());

            Console.WriteLine("----------------SORT BY SURNAME---------------");

            stCollection.SortBySurname();
            Console.WriteLine(stCollection.ToShortString());

            Console.WriteLine("----------------SORT BY BIRTHDAY---------------");

            stCollection.SortByBirthdays();
            Console.WriteLine(stCollection.ToShortString());


            Console.WriteLine("----------------SORT BY AVERAGE MARK---------------");

            stCollection.SortByAverage();
            Console.WriteLine(stCollection.ToShortString());


            Console.WriteLine("Max Average from List: " + stCollection.GetMaxAverage.ToString());

            /*Console.WriteLine("Student with form Master:\n" + stCollection.StudentsWithFormMaster.ToString());*/
            Console.WriteLine("Student with form Master:\n");
           
            foreach (Student stud in stCollection.StudentsWithFormMaster)
            {
                Console.WriteLine(stud.ToString() + "\n");
            }
            
          

            /*Console.WriteLine("Groups by Average Mark:\n" + stCollection.AverageMarkGroup(4));*/
            Console.WriteLine("Groups by Average Mark:\n");

            if (stCollection.AverageMarkGroup(4) != null)
            {
                foreach (Student stud in stCollection.AverageMarkGroup(4))
                {
                    Console.WriteLine(stud.ToString());
                }
            }
            else {
                Console.WriteLine("This Average Mark doesn't exist.");
            }


            TestCollections testCollection = new TestCollections(101);

            Console.WriteLine("~~~~~~~~~~~~~~~Show Time ELEM FROM BEGIN~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Student s1 = testCollection.GetStudentByN(1);
            if (s1 != null) {
                testCollection.ShowTime(s1);
            }

            Console.WriteLine("~~~~~~~~~~~~~~~Show Time ELEM FROM MIDL~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Student s2 = testCollection.GetStudentByN(60);
            if (s2 != null)
            {
                testCollection.ShowTime(s2);
            }

            Console.WriteLine("~~~~~~~~~~~~~~~Show Time ELEM FROM END~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Student s3 = testCollection.GetStudentByN(101);
            if (s3 != null)
            {
                testCollection.ShowTime(s3);
            }

            Console.WriteLine("~~~~~~~~~~~~~~~Show Time ELEM OUT OF LIST~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
            Student s4 = new Student();
            Random random = new Random();
            s4.Name = "OutName";
            s4.Surname = "OutSurname";
            s4.Date = new DateTime(19992020);
            s4.FormOfEducation = (Education)(random.Next(0, 2));
            s4.Group = random.Next(100, 699);

            Exam[] listOfExams = new Exam[] {
                new Exam("Math", random.Next(1,5),new DateTime(2017,6,3)),
                new Exam("Computer science", random.Next(1,5), new DateTime(2017, 6, 9)),
                new Exam("Economy", random.Next(1,5),new DateTime(2017,6,3))};

            Test[] listOfTests = new Test[] {
                new Test("Math", true),
                new Test("English", false),
                new Test("Biology", true),
                new Test("Economy", false)};

            s4.AddExams(listOfExams);
            s4.AddTests(listOfTests);
            if (s4 != null)
            {
                testCollection.ShowTime(s4);
            }

            Console.ReadKey();
        }
    }
}
