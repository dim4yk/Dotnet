using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace L5
{
    [Serializable]
    public class Student : Person, IDateAndCopy, ISerializable
    {
        [XmlIgnore]
        public Education formOfEducation;
        [XmlIgnore]
        public int group;
        [XmlIgnore]
        public List<Exam> examsList;
        [XmlIgnore]
        public List<Test> testsList;

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

        [XmlIgnore]
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

        [XmlIgnore]
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


        [XmlIgnore]
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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", GetPersonObject.Name);
            info.AddValue("Surname", GetPersonObject.Surname);
            info.AddValue("Birthday", GetPersonObject.Birthday);

            info.AddValue("FormOfEducation", FormOfEducation);
            info.AddValue("Group", Group);
            info.AddValue("ExamsList", ExamsList);
            info.AddValue("TestsList", TestsList);
        }

        public Student(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            Surname = (string)info.GetValue("Surname", typeof(string));
            Birthday = (DateTime)info.GetValue("Birthday", typeof(DateTime));

            FormOfEducation = (Education)info.GetValue("FormOfEducation", typeof(Education));
            Group = (int)info.GetValue("Group", typeof(int));
            ExamsList = (List<Exam>)info.GetValue("ExamsList", typeof(List<Exam>));
            TestsList = (List<Test>)info.GetValue("TestsList", typeof(List<Test>));
        }

        public Student DeepCopy<T>()
        {
            using (var ms = new MemoryStream())
            {
                //var bf = new BinaryFormatter();
                //bf.Serialize(ms, this);
                var xml = new XmlSerializer(typeof(Student));
                xml.Serialize(ms, this);
                ms.Position = 0;
                return (Student)xml.Deserialize(ms);
                //return (Student)bf.Deserialize(ms);
            }
        }

        public bool Save(string filename)
        {
            if (this == null) {
                return false;
            }

            try
            {
                using (var stream = new FileStream(filename, FileMode.Create))
                {
                    var xml = new XmlSerializer(typeof(Student));
                    xml.Serialize(stream, this);
                    //var bf = new BinaryFormatter();
                    //bf.Serialize(stream, this);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return true;
        }

        public bool Load(string filename)
        {
            if (this == null)
            {
                return false;
            }

            try
            {
                Student student = new Student();
                using (var stream = new FileStream(filename, FileMode.Open))
                {
                    var xml = new XmlSerializer(typeof(Student));
                    student = (Student)xml.Deserialize(stream);
                    //var bf = new BinaryFormatter();
                    //student = (Student)bf.Deserialize(stream);
                    Name = student.Name;
                    Surname = student.Surname;
                    Date = student.Date;
                    FormOfEducation = student.FormOfEducation;
                    Group = student.Group;
                    ExamsList = student.ExamsList;
                    TestsList = student.TestsList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }

        public bool AddFromConsole()
        {
            Console.WriteLine("Add new exam, use format: subject, name, date; \n" +
                "Example: Math, 4, 10/1/2017;");

            string line = Console.ReadLine();

            string pattern = @"\s*([A-Z][A-za-z]+)\,\s([1-5])\,\s(\d{1,2})\/(\d{1,2})\/(\d{4})\;";
            Match m = Regex.Match(line, pattern);
            if (m.Success == true)
            {
                ExamsList.Add(new Exam(m.Groups[1].Value, Int32.Parse(m.Groups[2].Value),
                    new DateTime(Int32.Parse(m.Groups[5].Value), Int32.Parse(m.Groups[4].Value), Int32.Parse(m.Groups[3].Value))));
                return true;
            }
            Console.WriteLine("Invalid values! \n");
            return false;
        }


        public static bool Save(string filename, Student obj)
        {
            if (obj == null) {
                return false;
            }

            try
            {
                using (var stream = new FileStream(filename, FileMode.Create))
                {
                    var xml = new XmlSerializer(typeof(Student));
                    xml.Serialize(stream, obj);
                    //var bf = new BinaryFormatter();
                    //bf.Serialize(stream, obj);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return true;
        }

        public static bool Load(string filename, Student obj)
        {
            if (obj == null)
            {
                return false;
            }

            try
            {
                Student student = new Student();
                using (var stream = new FileStream(filename, FileMode.Open))
                {
                    var xml = new XmlSerializer(typeof(Student));
                    student = (Student)xml.Deserialize(stream);
                    //var bf = new BinaryFormatter();
                    //student = (Student)bf.Deserialize(stream);
                    obj.Name = student.Name;
                    obj.Surname = student.Surname;
                    obj.Date = student.Date;
                    obj.FormOfEducation = student.FormOfEducation;
                    obj.Group = student.Group;
                    obj.ExamsList = student.ExamsList;
                    obj.TestsList = student.TestsList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
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

        /*public override object DeepCopy()
        {
            Student dcopy = (Student)this.MemberwiseClone();
            dcopy.GetPersonObject = new Person(GetPersonObject.Name, GetPersonObject.Surname, GetPersonObject.Date);
            dcopy.FormOfEducation = FormOfEducation;
            dcopy.Group = Group;
            dcopy.ExamsList = ExamsList.Select(exam => new Exam(exam.Subject, exam.Mark, exam.Date)).ToList<Exam>();
            dcopy.TestsList = TestsList.Select(test => new Test(test.Subject, test.InfoTest)).ToList<Test>();

            return dcopy;
        }*/
    }
}

