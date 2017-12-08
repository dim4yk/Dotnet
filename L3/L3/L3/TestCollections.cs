using System;
using System.Collections.Generic;
using System.Text;

namespace L3
{
    class TestCollections
    {
        public static Random random = new Random();
        private List<Person> personsList = new List<Person>();
        private List<string> stringList = new List<string>();
        private Dictionary<Person, Student> personSTDictionary = new Dictionary<Person, Student>();
        private Dictionary<string, Student> stringSTDictionary = new Dictionary<string, Student>();

        static Student CreateStudent(int n)
        {
            Student obj = new Student();
            obj.Name = "StudentName" + n;
            obj.Surname = "StudentSurname" + n;
            obj.Date = new DateTime(19992020 + n * 100);
            int educ = 0;
            if (n % 2 == 0) { educ = 1; }
            else if (n % 3 == 0) { educ = 2; }
            obj.FormOfEducation = (Education)educ;
            obj.Group = random.Next(100, 699);
            obj.ExamsList = new List<Exam>();
            obj.TestsList = new List<Test>();

            Exam[] listOfExams = new Exam[] {
                new Exam("Math", random.Next(1,5),new DateTime(2017,6,3)),
                new Exam("Computer science", random.Next(1,5), new DateTime(2017, 6, 9)),
                new Exam("Economy", random.Next(1,5),new DateTime(2017,6,3))};

            Test[] listOfTests = new Test[] {
                new Test("Math", false),
                new Test("English", true),
                new Test("Biology", false),
                new Test("Economy", true)};

            obj.AddExams(listOfExams);
            obj.AddTests(listOfTests);
            return obj;
        }

        public TestCollections(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Student obj = CreateStudent(i);
                Person personObj = obj.GetPersonObject;


                personsList.Add(personObj);

                personSTDictionary.Add(personObj,obj);

                stringList.Add(personObj.ToString());

                stringSTDictionary.Add(stringList[i-1], obj);
            }
        }

        public void ShowTime(Student stud)
        {
            TimeSpan span = new TimeSpan();
            DateTime startTime = new DateTime();
            if (personsList.Contains(stud.GetPersonObject))
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for List<Person>: " + span.Milliseconds + " and element found.\n");
            }
            else
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for List<Person>: " + span.Milliseconds + " and element wasn't found.\n");
            }

            startTime = new DateTime();
            if (stringList.Contains(stud.GetPersonObject.ToString()))
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for List<string>: " + span.Milliseconds + " and element found.\n");
            }
            else
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for List<string>: " + span.Milliseconds + " and element wasn't found.\n");
            }

            startTime = new DateTime();
            if (personSTDictionary.ContainsKey(stud.GetPersonObject))
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for Dictionary<Person,Student>: " + span.Milliseconds + " and element found.\n");
            }
            else
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for Dictionary<Person,Student>: " + span.Milliseconds + " and element wasn't found.\n");
            }

            startTime = new DateTime();
            if (stringSTDictionary.ContainsKey(stud.GetPersonObject.ToString()))
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for Dictionary<string,Student>: " + span.Milliseconds + " and element found.\n");
            }
            else
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for Dictionary<string,Student>: " + span.Milliseconds + " and element wasn't found.\n");
            }

            startTime = new DateTime();
            if (personSTDictionary.ContainsValue(stud))
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for Dictionary<Person,Student>: " + span.Milliseconds + " and element found.\n");
            }
            else
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for Dictionary<Person,Student>: " + span.Milliseconds + " and element wasn't found.\n");
            }

            startTime = new DateTime();
            if (stringSTDictionary.ContainsValue(stud))
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for Dictionary<string,Student>: " + span.Milliseconds + " and element found.\n");
            }
            else
            {
                span = DateTime.Now - startTime;
                Console.WriteLine("Time for Dictionary<string,Student>: " + span.Milliseconds + " and element wasn't found.\n");
            }

        }

        public Student GetStudentByN(int n) {
            int i = 0;
            foreach (Student stud in personSTDictionary.Values)
            {
                i++;
                if (i == n) return stud;
            }
            return null;
        }
    }
}
