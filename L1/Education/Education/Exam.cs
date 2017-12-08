using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public enum Education { Master, Bachelor, SecondEducation }
    class Exam
    {
        public string subject;
        public int mark;
        public System.DateTime examinationDate;

        public Exam() {
            this.subject = "";
            this.mark = -1;
            this.examinationDate = new DateTime();
        }

        public Exam(string subject, int mark, DateTime examinationDate)
        {
            this.subject = subject;
            this.mark = mark;
            this.examinationDate = examinationDate;
        }

        public override string ToString()
        {
            return "Subject: " + subject + " Mark: " + mark + " Examination date: " + examinationDate;
        }
    }

}
