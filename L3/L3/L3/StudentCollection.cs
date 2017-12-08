using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace L3
{
    class StudentCollection
    {
        private List<Student> studentsList= new List<Student>();

        public List<Student> StudentsList
        {
            get => studentsList;
            set => studentsList = value;
        }

        static Student InitStudent(int n) {
            Student obj = new Student();
            obj.Name = "StudentName" + n;
            obj.Surname = "StudentSurname" + n;
            obj.Date = new DateTime(19992020+n*100);
            int educ = 0;
            if (n % 2 == 0) { educ = 1; }
            else if (n % 3 == 0) { educ = 2; }
            obj.FormOfEducation = (Education)educ;
            obj.Group = new Random().Next(100,699);
            obj.ExamsList = new List<Exam>();
            obj.TestsList = new List<Test>();

            Exam[] listOfExams = new Exam[] {
                new Exam("Math", new Random().Next(1,5),new DateTime(2017,6,3)),
                new Exam("Computer science", new Random().Next(1,5), new DateTime(2017, 6, 9)),
                new Exam("Economy", new Random().Next(1,5),new DateTime(2017,6,3))};

            Test[] listOfTests = new Test[] {
                new Test("Math", false),
                new Test("English", true),
                new Test("Biology", false),
                new Test("Economy", true)};

            obj.AddExams(listOfExams);
            obj.AddTests(listOfTests);
            return obj;
        }

        public void AddDefaults(int n) {
            for (int i = 1; i <= n; i++) {
                Student obj = InitStudent(i);

                StudentsList.Add(obj);
            }
        }

        public void AddStudents(Student[] studarr) {
            foreach (Student stud in studarr)
            {
                StudentsList.Add(stud);
            }
        }

        public static StringBuilder ListToStringBuilder<T>(List<T> list)
        {
            StringBuilder SBList = new StringBuilder();
            if (list != null && list[0] != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    SBList.Append((i + 1) + ": " + list[i].ToString() + "; \n");
                }
            }
            else SBList.Append("Empty");

            return SBList;
        }

        public override string ToString() {
            StringBuilder SBAllStudentsInfo = new StringBuilder();
            foreach (Student stud in StudentsList) {
                SBAllStudentsInfo.Append(stud.GetPersonObject.ToString());
                SBAllStudentsInfo.Append("\nForm of Education: " + stud.FormOfEducation);
                SBAllStudentsInfo.Append("\nGroup: " + stud.Group);
                SBAllStudentsInfo.Append("\nExams: \n");
                SBAllStudentsInfo.Append(ListToStringBuilder(stud.ExamsList).ToString());
                SBAllStudentsInfo.Append("\nTest: \n");
                SBAllStudentsInfo.Append(ListToStringBuilder(stud.TestsList).ToString()+ "\n\n");
            }
            return SBAllStudentsInfo.ToString();
        }

        public string ToShortString() {
            StringBuilder SBAllStudentsInfo = new StringBuilder();
            foreach (Student stud in StudentsList)
            {
                SBAllStudentsInfo.Append(stud.GetPersonObject.ToString());
                SBAllStudentsInfo.Append("\nForm of Education: " + stud.FormOfEducation);
                SBAllStudentsInfo.Append("\nGroup: " + stud.Group);
                SBAllStudentsInfo.Append("\nAverage mark: " + stud.Average);
                SBAllStudentsInfo.Append("\nCount of Exams: " + stud.ExamsList.Count);
                SBAllStudentsInfo.Append("\nCount of Tests: " + stud.TestsList.Count + "\n\n");

            }
            return SBAllStudentsInfo.ToString();
        }

        public void SortBySurname() {
            StudentsList.Sort();
        }

        public void SortByBirthdays() {
            Person comparer = new Person();
            StudentsList.Sort(comparer);
        }

        public void SortByAverage() {
            StudentComparer comparer = new StudentComparer();
            StudentsList.Sort(comparer);
        }

        public double GetMaxAverage {
            get {
                if (StudentsList == null) {
                    return -1;
                }
                return StudentsList.Max(av=>av.Average);
            }
        }

        public IEnumerable<Student> StudentsWithFormMaster {
            get {
                return StudentsList.Where(fr => fr.FormOfEducation == Education.Master).ToList();
            }
        }

        public List<Student> AverageMarkGroup(double value) {
            List<Student> averageMarkList = null;
            var averageMarkSelect = from stud in StudentsList
                                    where stud.Average == value
                                    group stud by stud.Average;

            IEnumerable<Student> student = averageMarkSelect.SelectMany(group => group);
            averageMarkList = student.ToList();
            if (averageMarkList.Count == 0)
                return null;
            return averageMarkList;
        }
    }
}
