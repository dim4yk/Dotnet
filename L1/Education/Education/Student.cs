using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class Student
    {
        private Person StudentData;
        private Education FormOfEducation;
        private int Group;
        private Exam[] PassedExams;

        public Student()
        {
            StudentData = new Person();
            FormOfEducation = Education.Bachelor;
            Group = -1;
            PassedExams = new Exam[1];
        }

        public Student(Person studentData, Education formOfEducation, int group, Exam[] passedExams)
        {
            StudentData = studentData;
            FormOfEducation = formOfEducation;
            Group = group;
            PassedExams = passedExams;
        }

        public Person StudentDate {
            get => StudentData;
            set => StudentData = value;
        }

        public Education Form {
            get => FormOfEducation;
            set => FormOfEducation = value;
        }

        public int GroupNum {
            get => Group;
            set => Group = value;
        }

        public Exam[] PassedExamsList {
            get => PassedExams;
            set => PassedExams = value;
        }

        public Double Average {
            get {
                Double MultipleMarks = 0;
                foreach (Exam e in PassedExams) {
                    MultipleMarks = MultipleMarks + e.mark;
                }
                return MultipleMarks / PassedExams.Length;
            }
        }

        public Boolean this[Education e] {
            get {
                if (e.Equals(FormOfEducation)) {
                    return true;
                }
                else return false;
            }
        }

        public void AddExams(Exam[] exam) {
            int len = PassedExams.Length;
            Exam[] AddResult = new Exam[len + exam.Length];
            for (int i = 0; i < PassedExams.Length; i++) {
                AddResult[i] = PassedExams[i];
            }

            for (int i = len; i < len + exam.Length; i++) {
                AddResult[i] = exam[i-len];
            }

            PassedExams = AddResult;
        }

        public override string ToString()
        {
            string ExamList = "";
            if (PassedExams != null) {
                for (int i = 0; i < PassedExams.Length; i++) {
                    ExamList = ExamList + (i + 1) + ": " + PassedExams[i].ToString() + "; \n";
                }
            }
            return "Student data: \n" + StudentData.ToString() +
                "\n Form of Education: " + FormOfEducation +
                "\n Group: " + Group +
                "\n Passed Exams: \n" + ExamList; 
        }

        public virtual string ToShortString() {
            return "Student data: \n" + StudentData.ToString() +
                "\n Form of Education: " + FormOfEducation +
                "\n Group: " + Group +
                "\n Average mark: " + Average + ".";
        }
    }
}
