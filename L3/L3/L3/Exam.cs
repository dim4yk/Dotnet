using System;
using System.Collections.Generic;
using System.Text;

namespace L3
{
    public enum Education { Master, Bachelor, SecondEducation }
    class Exam : IDateAndCopy
    {
        private string subject;
        private int mark;
        private System.DateTime _examinationDate;


        public Exam()
        {
            this.subject = "";
            this.mark = -1;
            this._examinationDate = new DateTime();
        }

        public Exam(string subject, int mark, DateTime examinationDate)
        {
            this.subject = subject;
            this.mark = mark;
            this._examinationDate = examinationDate;
        }

        public string Subject
        {
            get => subject;
            set => subject = value;
        }

        public int Mark
        {
            get => mark;
            set => mark = value;
        }


        public DateTime Date { get => _examinationDate; set => _examinationDate = value; }

        public object DeepCopy()
        {
            Exam dcopy = (Exam)this.MemberwiseClone();
            dcopy.subject = new string(subject.ToCharArray());
            dcopy.mark = mark;
            dcopy._examinationDate = new DateTime(Date.Year, Date.Month, Date.Day);
            return dcopy;
        }

        public override string ToString()
        {
            return "Subject: " + subject + " Mark: " + mark + " Examination date: " + Date;
        }

    }
}
