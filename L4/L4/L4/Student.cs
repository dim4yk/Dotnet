using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L4
{
    class Student : Person, IDateAndCopy
    {
        private Education formOfEducation;
        private int group;
        private List<Exam> examsList;
        private List<Test> testsList;

        public Student()
        {
            base.Name = "";
            base.Surname = "";
            base.Date = new DateTime();
            formOfEducation = Education.Bachelor;
            group = -1;
            examsList = new List<Exam>();
            testsList = new List<Test>();
        }

        public Student(Person p, Education e, int g)
        {
            base.Name = p.Name;
            base.Surname = p.Surname;
            base.Date = p.Date;
            formOfEducation = e;
            group = g;
            examsList = new List<Exam>();
            testsList = new List<Test>();
        }

        public Person GetPersonObject
        {
            get
            {
                Person obj = (Person)base.DeepCopy();
                return obj;
            }

            set
            {
                base.Name = value.Name;
                base.Surname = value.Surname;
                base.Date = value.Date;
            }
        }

        public Double Average
        {
            get
            {
                Double MultipleMarks = 0;
                if (ExamsList.Count != 0)
                {
                    foreach (Exam exam in ExamsList)
                    {
                        MultipleMarks = MultipleMarks + exam.Mark;
                    }
                    return MultipleMarks / ExamsList.Count;
                }
                else return 0;
            }
        }

        public Education FormOfEducation
        {
            get => formOfEducation;
            set => formOfEducation = value;
        }

        public int Group
        {
            get => group;
            set
            {
                if (value >= 100 && value < 699)
                    group = value;
                else throw new Exception("Invalid value");
            }
        }

        public List<Exam> ExamsList
        {
            get => examsList;
            set => examsList = value;
        }

        public List<Test> TestsList
        {
            get => testsList;
            set => testsList = value;
        }



        public Boolean this[Education e]
        {
            get
            {
                if (e.Equals(FormOfEducation))
                {
                    return true;
                }
                else return false;
            }
        }

        public void AddExams(Exam[] exams)
        {
            foreach (Exam exam in exams)
            {
                ExamsList.Add(exam);
            }
        }

        public void AddTests(Test[] tests)
        {
            foreach (Test test in tests)
            {
                TestsList.Add(test);
            }
        }

        public IEnumerable<object> Union()
        {
            foreach (Exam e in ExamsList)
            {
                bool equalsCond = false;
                foreach (Test t in TestsList)
                {
                    if (e.Subject.Equals(t.Subject))
                    {
                        equalsCond = true;
                        break;
                    }
                }
                if (equalsCond == false)
                    yield return e;
            }

            foreach (Test t in TestsList)
            {
                yield return t;
            }
        }

        public IEnumerable<Exam> MarkBiggerThen(int mark)
        {
            foreach (Exam e in ExamsList)
            {
                if (e.Mark > mark)
                    yield return e;
            }
        }

        public IEnumerable<object> Intersection()
        {
            IEnumerator<Exam> enumExam = ExamsList.GetEnumerator();
            IEnumerator<Test> enumTest = TestsList.GetEnumerator();
            while (enumExam.MoveNext())
            {

                while (enumTest.MoveNext())
                {
                    if (enumExam.Current.Subject == enumTest.Current.Subject)
                    {
                        yield return enumExam.Current;
                    }
                }
                enumTest.Reset();
            }
        }

        public IEnumerable<object> PassedTestsAndExams()
        {
            foreach (Exam e in ExamsList)
            {
                if (e.Mark > 2)
                {
                    yield return e;
                }
            }

            foreach (Test t in TestsList)
            {
                if (t.InfoTest)
                {
                    yield return t;
                }
            }
        }


        public IEnumerable<Test> PassedTests()
        {
            foreach (Test t in TestsList)
            {
                if (t.InfoTest)
                {
                    foreach (Exam e in ExamsList)
                    {
                        if (e.Subject.Equals(t.Subject) && (e.Mark > 2))
                            yield return t;
                    }
                }
            }
        }

        public static StringBuilder ListToStringBuilder<T>(List<T> list)
        {
            StringBuilder SBList = new StringBuilder();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    SBList.Append((i + 1) + ": " + list[i].ToString() + "; \n");
                }
            }
            else SBList.Append("Empty");

            return SBList;
        }

        public override string ToString()
        {
            return "Student data: \n" + base.ToString() +
                "\nForm of Education: " + FormOfEducation +
                "\nGroup: " + Group +
                "\nPassed Exams: \n" + ListToStringBuilder(ExamsList).ToString() +
                "\nTest: \n" + ListToStringBuilder(TestsList).ToString();
        }

        public override string ToShortString()
        {
            return "Student data: \n" + base.ToString() +
                "\nForm of Education: " + FormOfEducation +
                "\nGroup: " + Group +
                "\nAverage mark: " + Average + ".";
        }

        public override object DeepCopy()
        {
            Student dcopy = (Student)this.MemberwiseClone();
            dcopy.GetPersonObject = new Person(GetPersonObject.Name, GetPersonObject.Surname, GetPersonObject.Date);
            dcopy.FormOfEducation = FormOfEducation;
            dcopy.Group = Group;
            dcopy.ExamsList = ExamsList.Select(exam => new Exam(exam.Subject, exam.Mark, exam.Date)).ToList<Exam>();
            dcopy.TestsList = TestsList.Select(test => new Test(test.Subject, test.InfoTest)).ToList<Test>();

            return dcopy;
        }
    }
}

